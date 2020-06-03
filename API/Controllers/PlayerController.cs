using Data;
using Microsoft.AspNet.Identity;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    [Authorize]
    [RoutePrefix("api/player")]
    public class PlayerController : ApiController
    {
        [Route("create")]
        [HttpPost]
        public IHttpActionResult Post(PlayerCreate player)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            PlayerService playerService = new PlayerService();

            if (!playerService.CreatePlayer(player))
                return InternalServerError();

            return Ok();
        }

        [Route("{Name}")]
        [HttpGet]
        public IHttpActionResult GetIndividualPlayerByName(string name)
        {
            PlayerService playerService = new PlayerService();
            var player = playerService.GetPlayerByName(name);
            return Ok(player);
        }

        [Route("all")]
        [HttpGet]
        public IHttpActionResult GetAllPlayers()
        {
            PlayerService playerService = new PlayerService();
            var players = playerService.GetPlayers();
            return Ok(players);
        }

        [Route("rankings")]
        [HttpGet]
        public IHttpActionResult GetRankingsByVotes()
        {
            PlayerService playerService = new PlayerService();
            var rankings = playerService.GetPlayerByRankings();
            return Ok(rankings);
        }

        [Route("update")]
        [HttpPut]
        public IHttpActionResult Put(PlayerEdit player)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            PlayerService playerService = new PlayerService();

            if (!playerService.UpdatePlayer(player))
                return InternalServerError();

            return Ok();
        }

        [Route("{name}")]
        [HttpDelete]
        public IHttpActionResult Delete(string name)
        {
            PlayerService playerService = new PlayerService();

            if (!playerService.DeletePlayer(name))
                return InternalServerError();

            return Ok();
        }
    }
}
