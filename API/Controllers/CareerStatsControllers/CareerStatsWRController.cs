﻿using Models.CareerStatsWR;
using Services.CareerStats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.Controllers.CareerStatsControllers
{
    [Authorize]
    [RoutePrefix("api/CareerStatsWR")]
    public class CareerStatsWRController : ApiController
    {
        [Route("create")]
        [HttpPost]
        public IHttpActionResult Post(CareerStatsWRCreate career)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CareerStatsWRService careerService = new CareerStatsWRService();

            if (!careerService.CreateCareerStatsWR(career))
                return InternalServerError();

            return Ok();
        }

        [Route("all")]
        [HttpGet]
        public IHttpActionResult GetAllCareerWRs()
        {
            CareerStatsWRService careerService = new CareerStatsWRService();
            var career = careerService.GetCareerWRs();
            return Ok(career);
        }

        [Route("{playerId}")]
        [HttpGet]
        public IHttpActionResult GetCareerStatTotals(int playerId)
        {
            CareerStatsWRService careerService = new CareerStatsWRService();
            var career = careerService.GetCareerStatTotals(playerId);
            return Ok(career);
        }

        [Route("update")]
        [HttpPut]
        public IHttpActionResult Put(CareerStatsWREdit careerStatsWR)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CareerStatsWRService careerService = new CareerStatsWRService();

            if (!careerService.UpdateCareerStatsWR(careerStatsWR))
                return InternalServerError();

            return Ok();
        }

        [Route("{careerId}")]
        [HttpDelete]
        public IHttpActionResult Delete(int careerId)
        {
            CareerStatsWRService careerService = new CareerStatsWRService();

            if (!careerService.DeleteCareerStatsWR(careerId))
                return InternalServerError();

            return Ok();
        }
    }
}