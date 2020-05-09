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
    public class PlayerController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post(PlayerCreate player)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            PlayerService service = new PlayerService();

            if (!service.CreatePlayer(player))
                return InternalServerError();

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetIndividualPlayerByName(string name)
        {
            PlayerService playerService = new PlayerService();
            var player = playerService.GetPlayerByName(name);
            return Ok(player);
        }

        [HttpGet]
        public IHttpActionResult GetAllPlayers()
        {
            PlayerService playerService = new PlayerService();
            var players = playerService.GetPlayers();
            return Ok(players);
        }

        [HttpPut]
        public IHttpActionResult Put(PlayerEdit player)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            PlayerService service = new PlayerService();

            if (!service.UpdatePlayer(player))
                return InternalServerError();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(string name)
        {
            PlayerService service = new PlayerService();

            if (!service.DeletePlayer(name))
                return InternalServerError();

            return Ok();
        }
    }
}
