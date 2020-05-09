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
        private CareerStatsQBService CreateCareerStatsQBService()
        {
            var careerStatsService = new CareerStatsQBService();
            return careerStatsService;
        }

        public IHttpActionResult Get()
        {
            CareerStatsQBService careerStatsService = CreateCareerStatsQBService();
            var stats = careerStatsService.GetCareerStatsQBs();
            return Ok(stats);
        }

        public IHttpActionResult Post(CareerStatsQBCreate careerStats)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCareerStatsQBService();

            if (!service.CreateCareerStatsQB(careerStats))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            CareerStatsQBService statsService = CreateCareerStatsQBService();
            var stats = statsService.GetCareerStatsQBById(id);
            return Ok(stats);
        }

        public IHttpActionResult Put(CareerStatsQBEdit careerStatsQB)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCareerStatsQBService();

            if (!service.UpdateCareerStatsQB(careerStatsQB))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateCareerStatsQBService();

            if (!service.DeleteCareerStatsQB(id))
                return InternalServerError();

            return Ok();
        }
    }
}
