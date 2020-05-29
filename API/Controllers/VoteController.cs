using Data;
using Microsoft.AspNet.Identity;
using Models;
using Models.VoteClasses;
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
    [RoutePrefix("api/vote")]
    public class VoteController : ApiController
    {
        [Route("create")]
        [HttpPost]
        public IHttpActionResult Post(VoteCreate vote)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            VoteService voteService = new VoteService();

            if (!voteService.CreateVote(vote))
                return InternalServerError();

            return Ok();
        }

        [Route("userId/{userId}")]
        [HttpGet]
        public IHttpActionResult GetAllVotesByUser(string userId)
        {
            VoteService voteService = new VoteService();
            var votes = voteService.GetVotesByUser(userId);
            return Ok(votes);
        }

        [Route("playerId/{playerId}")]
        [HttpGet]
        public IHttpActionResult GetAllVotesByPlayerId(int playerId)
        {
            VoteService voteService = new VoteService();
            var votes = voteService.GetVotesByPlayerId(playerId);
            return Ok(votes);
        }

        [Route("rankings")]
        [HttpGet]
        public IHttpActionResult GetRankingsByVotes()
        {
            VoteService voteService = new VoteService();
            var rankings = voteService.GetRankings();
            return Ok(rankings);
        }

        [Route("delete")]
        [HttpPut]
        public IHttpActionResult DeleteVote(VoteEdit vote)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            VoteService voteService = new VoteService();

            if (!voteService.DeleteVoteById(vote))
                return InternalServerError();

            return Ok();
        }

        [Route("reactivate")]
        [HttpPut]
        public IHttpActionResult ReactivateVoteById(VoteEdit vote)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            VoteService voteService = new VoteService();

            if (!voteService.ReactivateVoteById(vote))
                return InternalServerError();

            return Ok();
        }
    }
}
