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
        public IHttpActionResult Get()
        {
            PlayerService playerService = CreatePlayerService();
            var players = playerService.GetPlayers();
            return Ok(players);
        }

        public IHttpActionResult Post(PlayerCreate player)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePlayerService();

            if (!service.CreatePlayer(player))
                return InternalServerError();

            return Ok();
        }

        private PlayerService CreatePlayerService()
        {
            var playerId = Guid.Parse(User.Identity.GetUserId());
            var playerService = new PlayerService(playerId);
            return playerService;
        }

        public IHttpActionResult Get(string name)
        {
            PlayerService playerService = CreatePlayerService();
            var player = playerService.GetPlayerByName(name);
            return Ok();
        }

        public IHttpActionResult Put(PlayerEdit player)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePlayerService();

            if (!service.UpdatePlayer(player))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(string name)
        {
            var service = CreatePlayerService();

            if (!service.DeletePlayer(name))
                return InternalServerError();

            return Ok();
        }
    }
}
