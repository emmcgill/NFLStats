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
    [RoutePrefix("api/qbseason")]
    public class SeasonStatController : ApiController
    {
        [Route("create")]
        [HttpPost]
        public IHttpActionResult Post(SeasonStatCreate season)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            SeasonStatService service = new SeasonStatService();

            if (!service.CreateSeason(season))
                return InternalServerError();

            return Ok();
        }

        [Route("season/{seasonId}")]
        [HttpGet]
        public IHttpActionResult GetSeasonById(int seasonId)
        {
            SeasonStatService seasonService = new SeasonStatService();
            var season = seasonService.GetSeasonBySeasonId(seasonId);
            return Ok(season);
        }

        [Route("allseasons/{playerId}")]
        [HttpGet]
        public IHttpActionResult GetAllQbSeasons(int playerId)
        {
            SeasonStatService seasonService = new SeasonStatService();
            var seasons = seasonService.GetQbSeasonsByPlayerId(playerId);
            return Ok(seasons);
        }

        [Route("updateseason")]
        [HttpPut]
        public IHttpActionResult Put(SeasonStatEdit season)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            SeasonStatService service = new SeasonStatService();

            if (!service.UpdateSeasonStats(season))
                return InternalServerError();

            return Ok();
        }

        [Route("deleteseason/{seasonId}")]
        [HttpDelete]
        public IHttpActionResult Delete(int seasonId)
        {
            SeasonStatService service = new SeasonStatService();

            if (!service.DeleteSeasonStat(seasonId))
                return InternalServerError();

            return Ok();
        }



    }
}
