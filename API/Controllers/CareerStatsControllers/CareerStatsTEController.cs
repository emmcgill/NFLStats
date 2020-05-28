﻿using Models.CareerStatsTE;
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

            CareerStatsTEService service = new CareerStatsTEService();

            if (!service.CreateCareerStatsTE(career))
                return InternalServerError();

            return Ok();
        }

        [Route("{careerId}")]
        [HttpGet]
        public IHttpActionResult GetCareerStatsTEById(int careerId)
        {
            CareerStatsTEService careerService = new CareerStatsTEService();
            var career = careerService.GetCareerStatsTEById(careerId);
            return Ok(career);
        }

        [Route("update")]
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

        [Route("{careerId}")]
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