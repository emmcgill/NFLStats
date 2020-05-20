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
    public class CareerStatsTEController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post(CareerStatsTECreate career)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CareerStatsTEService service = new CareerStatsTEService();

            if (!service.CreateCareerStatsTE(career))
                return InternalServerError();

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetCareerStatsTEById(int careerId)
        {
            CareerStatsTEService careerService = new CareerStatsTEService();
            var career = careerService.GetCareerStatsTEById(careerId);
            return Ok(career);
        }

        [HttpPut]
        public IHttpActionResult Put(CareerStatsTEEdit careerStatsTE)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CareerStatsTEService service = new CareerStatsTEService();

            if (!service.UpdateCareerStatsTE(careerStatsTE))
                return InternalServerError();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int careerId)
        {
            CareerStatsTEService service = new CareerStatsTEService();

            if (!service.DeleteCareerStatsTE(careerId))
                return InternalServerError();

            return Ok();
        }
    }
}