using Data;
using Models.CareerStatsQB;
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
    [RoutePrefix("api/CareerStatsQB")]
    public class CareerStatsQBController : ApiController
    {
        [Route("create")]
        [HttpPost]
        public IHttpActionResult Post(CareerStatsQBCreate career)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CareerStatsQBService careerService = new CareerStatsQBService();

            if (!careerService.CreateCareerStatsQB(career))
                return InternalServerError();

            return Ok();
        }

        [Route("{all}")]
        [HttpGet]
        public IHttpActionResult GetAllCareerQBs()
        {
            CareerStatsQBService careerService = new CareerStatsQBService();
            var career = careerService.GetCareerQBs();
            return Ok(career);
        }
        
        [Route("{playerId}")]
        [HttpGet]
        public IHttpActionResult GetCareerStatTotals(int playerId)
        {
            CareerStatsQBService careerService = new CareerStatsQBService();
            var career = careerService.GetCareerStatTotals(playerId);
            return Ok(career);
        }

        [Route("update")]
        [HttpPut]
        public IHttpActionResult Put(CareerStatsQBEdit careerStatsQB)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CareerStatsQBService careerService = new CareerStatsQBService();

            if (!careerService.UpdateCareerStatsQB(careerStatsQB))
                return InternalServerError();

            return Ok();
        }

        [Route("{careerId}")]
        [HttpDelete]
        public IHttpActionResult Delete(int careerId)
        {
            CareerStatsQBService careerService = new CareerStatsQBService();

            if (!careerService.DeleteCareerStatsQB(careerId))
                return InternalServerError();

            return Ok();
        }

    }
}
