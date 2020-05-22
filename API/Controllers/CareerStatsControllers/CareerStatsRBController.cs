using Models.CareerStatsRB;
using Services.CareerStats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Http;

namespace API.Controllers.CareerStatsControllers
{
    [Authorize]
    public class CareerStatsRBController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post(CareerStatsRBCreate career)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CareerStatsRBService service = new CareerStatsRBService();

            if (!service.CreateCareerStatsRB(career))
                return InternalServerError();

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetCareerStatsRBById(int careerId)
        {
            CareerStatsRBService careerService = new CareerStatsRBService();
            var career = careerService.GetCareerStatsRBById(careerId);
            return Ok(career);
        }

        [HttpPut]
        public IHttpActionResult Put(CareerStatsRBEdit careerStatsRB)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CareerStatsRBService service = new CareerStatsRBService();

            if (!service.UpdateCareerStatsRB(careerStatsRB))
                return InternalServerError();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int careerId)
        {
            CareerStatsRBService service = new CareerStatsRBService();

            if (!service.DeleteCareerStatsRB(careerId))
                return InternalServerError();

            return Ok();
        }
    }
}