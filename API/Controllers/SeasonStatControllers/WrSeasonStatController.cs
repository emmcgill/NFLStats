using Models.SeasonStatsWr;
using Services;
using System.Web.Http;

namespace API.Controllers.SeasonStatControllers
{
    public class WrSeasonStatController : ApiController
    {
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

        [HttpGet]
        public IHttpActionResult GetWrSeasonById(int seasonId)
        {
            WrSeasonStatService seasonService = new WrSeasonStatService();
            var season = seasonService.GetWrSeasonBySeasonId(seasonId);
            return Ok(season);
        }

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
