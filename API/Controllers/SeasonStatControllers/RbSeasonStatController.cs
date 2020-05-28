using Models;
using Models.SeasonStatsRB;
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
    [RoutePrefix("api/rbseason")]
    public class RbSeasonStatController : ApiController
    {
        [Route("create")]
        [HttpPost]
        public IHttpActionResult Post(RbSeasonStatCreate season)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            RbSeasonStatService service = new RbSeasonStatService();

            if (!service.RbCreateSeason(season))
                return InternalServerError();

            return Ok();
        }

        [Route("season/{seasonId}")]
        [HttpGet]
        public IHttpActionResult GetRbSeasonById(int seasonId)
        {
            RbSeasonStatService seasonService = new RbSeasonStatService();
            var season = seasonService.GetRbSeasonBySeasonId(seasonId);
            return Ok(season);
        }

        [Route("allseasons/{playerId}")]
        [HttpGet]
        public IHttpActionResult GetAllRbSeasons(int playerId)
        {
            RbSeasonStatService seasonService = new RbSeasonStatService();
            var seasons = seasonService.GetRbSeasonsByPlayerId(playerId);
            return Ok(seasons);
        }

        [Route("updateseason")]
        [HttpPut]
        public IHttpActionResult Put(RbSeasonStatEdit season)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            RbSeasonStatService service = new RbSeasonStatService();

            if (!service.UpdateRbSeasonStats(season))
                return InternalServerError();

            return Ok();
        }

        [Route("deleteseason/{seasonId}")]
        [HttpDelete]
        public IHttpActionResult Delete(int seasonId)
        {
            RbSeasonStatService service = new RbSeasonStatService();

            if (!service.DeleteRbSeasonStat(seasonId))
                return InternalServerError();

            return Ok();
        }
    }
}
