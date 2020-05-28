using Models.SeasonStatsWr;
using Services;
using System.Web.Http;

namespace API.Controllers.SeasonStatControllers
{
    [Authorize]
    [RoutePrefix("api/wrseason")]
    public class WrSeasonStatController : ApiController
    {
        [Route("create")]
        [HttpPost]
        public IHttpActionResult Post(WrSeasonStatCreate season)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            WrSeasonStatService service = new WrSeasonStatService();

            if (!service.WrCreateSeason(season))
                return InternalServerError();

            return Ok();
        }

        [Route("season/{seasonId}")]
        [HttpGet]
        public IHttpActionResult GetWrSeasonById(int seasonId)
        {
            WrSeasonStatService seasonService = new WrSeasonStatService();
            var season = seasonService.GetWrSeasonBySeasonId(seasonId);
            return Ok(season);
        }

        [Route("allseasons/{playerId}")]
        [HttpGet]
        public IHttpActionResult GetAllWrSeasons(int playerId)
        {
            WrSeasonStatService seasonService = new WrSeasonStatService();
            var seasons = seasonService.GetWrSeasonsByPlayerId(playerId);
            return Ok(seasons);
        }

        [Route("updateseason")]
        [HttpPut]
        public IHttpActionResult Put(WrSeasonStatEdit season)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            WrSeasonStatService service = new WrSeasonStatService();

            if (!service.UpdateWrSeasonStats(season))
                return InternalServerError();

            return Ok();
        }

        [Route("deleteseason/{seasonId}")]
        [HttpDelete]
        public IHttpActionResult Delete(int seasonId)
        {
            WrSeasonStatService service = new WrSeasonStatService();

            if (!service.DeleteWrSeasonStat(seasonId))
                return InternalServerError();

            return Ok();
        }
    }
}
