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
    [RoutePrefix("api/rank")]
    public class RankController : ApiController
    {
        [Route("GetRankings")]
        [HttpGet]
        public IHttpActionResult GetRankingsByVotes()
        {
            RankService rankService = new RankService();
            var rankings = rankService.GetRankings();
            return Ok(rankings);
        }
    }
}
