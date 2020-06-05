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
    [RoutePrefix("api/CareerStatsRB")]
    public class CareerStatsRBController : ApiController
    {
        [Route("create")]
        [HttpPost]
        public IHttpActionResult Post(CareerStatsRBCreate career)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CareerStatsRBService careerService = new CareerStatsRBService();

            if (!careerService.CreateCareerStatsRB(career))
                return InternalServerError();

            return Ok();
        }

        [Route("all")]
        [HttpGet]
        public IHttpActionResult GetAllCareerRBs()
        {
            CareerStatsRBService careerService = new CareerStatsRBService();
            var career = careerService.GetCareerRBs();
            return Ok(career);
        }

        [Route("{playerId}")]
        [HttpGet]
        public IHttpActionResult GetCareerStatTotals(int playerId)
        {
            CareerStatsRBService careerService = new CareerStatsRBService();
            var career = careerService.GetCareerStatTotals(playerId);
            return Ok(career);
        }

        [Route("update")]
        [HttpPut]
        public IHttpActionResult Put(CareerStatsRBEdit careerStatsRB)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CareerStatsRBService careerService = new CareerStatsRBService();

            if (!careerService.UpdateCareerStatsRB(careerStatsRB))
                return InternalServerError();

            return Ok();
        }

        [Route("{careerId}")]
        [HttpDelete]
        public IHttpActionResult Delete(int careerId)
        {
            CareerStatsRBService careerService = new CareerStatsRBService();

            if (!careerService.DeleteCareerStatsRB(careerId))
                return InternalServerError();

            return Ok();
        }
    }
}