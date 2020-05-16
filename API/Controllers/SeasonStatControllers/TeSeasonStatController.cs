using Models.SeasonStatsTe;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers.SeasonStatControllers
{
    public class TeSeasonStatController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post(TeSeasonStatCreate season)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            TeSeasonStatService service = new TeSeasonStatService();

            if (!service.TeCreateSeason(season))
                return InternalServerError();

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetTeSeasonById(int seasonId)
        {
            TeSeasonStatService seasonService = new TeSeasonStatService();
            var season = seasonService.GetTeSeasonBySeasonId(seasonId);
            return Ok(season);
        }

        [HttpPut]
        public IHttpActionResult Put(TeSeasonStatEdit season)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            TeSeasonStatService service = new TeSeasonStatService();

            if (!service.UpdateTeSeasonStats(season))
                return InternalServerError();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int seasonId)
        {
            TeSeasonStatService service = new TeSeasonStatService();

            if (!service.DeleteTeSeasonStat(seasonId))
                return InternalServerError();

            return Ok();
        }
    }
}
