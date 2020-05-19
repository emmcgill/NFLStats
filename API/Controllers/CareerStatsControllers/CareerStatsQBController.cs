using Models.CareerStatsQBModels;
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
    public class CareerStatsQBController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post(CareerStatsQBCreate career)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CareerStatsQBService service = new CareerStatsQBService();

            if (!service.CreateCareerStatsQB(career))
                return InternalServerError();

            return Ok();
        }
        
        [HttpGet]
        public IHttpActionResult GetCareerStatsQBById(int careerId)
        {
            CareerStatsQBService careerService = new CareerStatsQBService();
            var career = careerService.GetCareerStatsQBById(careerId);
            return Ok(career);
        }

        [HttpPut]
        public IHttpActionResult Put(CareerStatsQBEdit careerStatsQB)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CareerStatsQBService service = new CareerStatsQBService();

            if (!service.UpdateCareerStatsQB(careerStatsQB))
                return InternalServerError();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int careerId)
        {
            CareerStatsQBService service = new CareerStatsQBService();

            if (!service.DeleteCareerStatsQB(careerId))
                return InternalServerError();

            return Ok();
        }

    }
}
