using Models.CareerStatsTE;
using Services.CareerStats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.Controllers.CareerStatsControllers
{
    [Authorize]
    [RoutePrefix("api/CareerStatsTE")]
    public class CareerStatsTEController : ApiController
    {
        [Route("create")]
        [HttpPost]
        public IHttpActionResult Post(CareerStatsTECreate career)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CareerStatsTEService careerService = new CareerStatsTEService();

            if (!careerService.CreateCareerStatsTE(career))
                return InternalServerError();

            return Ok();
        }

        [Route("{all}")]
        [HttpGet]
        public IHttpActionResult GetAllCareerQBs()
        {
            CareerStatsTEService careerService = new CareerStatsTEService();
            var career = careerService.GetCareerTEs();
            return Ok(career);
        }

        [Route("{playerId}")]
        [HttpGet]
        public IHttpActionResult GetCareerStatTotals(int playerId)
        {
            CareerStatsTEService careerService = new CareerStatsTEService();
            var career = careerService.GetCareerStatTotals(playerId);
            return Ok(career);
        }

        [Route("update")]
        [HttpPut]
        public IHttpActionResult Put(CareerStatsTEEdit careerStatsTE)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CareerStatsTEService careerService = new CareerStatsTEService();

            if (!careerService.UpdateCareerStatsTE(careerStatsTE))
                return InternalServerError();

            return Ok();
        }

        [Route("{careerId}")]
        [HttpDelete]
        public IHttpActionResult Delete(int careerId)
        {
            CareerStatsTEService careerService = new CareerStatsTEService();

            if (!careerService.DeleteCareerStatsTE(careerId))
                return InternalServerError();

            return Ok();
        }
    }
}