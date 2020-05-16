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
    public class RbSeasonStatController : ApiController
    {
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

        [HttpGet]
        public IHttpActionResult GetRbSeasonById(int seasonId)
        {
            RbSeasonStatService seasonService = new RbSeasonStatService();
            var season = seasonService.GetRbSeasonBySeasonId(seasonId);
            return Ok(season);
        }

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
