using Services.ComparisonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers.ComparisonControllers
{
    public class SSComparisonController : ApiController
    {
        //QB Season Stat Comparison
        [Route("api/qbseasoncomparison")]
        [HttpGet]
        public IHttpActionResult GetQbSeasonComparisonById(int seasonId1, int seasonId2)
        {
            QBComparisonService comparison = new QBComparisonService();
            var season = comparison.Get2QbSeasonStatsById(seasonId1, seasonId2);
            comparison.DisplayQbStatComparison(season);
            return Ok(season);
        }

        //RB Season Stat Comparison
        [Route("api/rbseasoncomparison")]
        [HttpGet]
        public IHttpActionResult GetRbSeasonComparisonById(int seasonId1, int seasonId2)
        {
            RBComparisonService comparison = new RBComparisonService();
            var season = comparison.Get2RbSeasonStatsById(seasonId1, seasonId2);
            comparison.DisplayRbStatComparison(season);
            return Ok(season);
        }

        //WR Season Stat Comparison
        [Route("api/wrseasoncomparison")]
        [HttpGet]
        public IHttpActionResult GetWrSeasonComparisonById(int seasonId1, int seasonId2)
        {
            WRComparisonService comparison = new WRComparisonService();
            var season = comparison.Get2WrSeasonStatsById(seasonId1, seasonId2);
            comparison.DisplayWrStatComparison(season);
            return Ok(season);
        }

        //TE Season Stat Comparison
        [Route("api/teseasoncomparison")]
        [HttpGet]
        public IHttpActionResult GetTeSeasonComparisonById(int seasonId1, int seasonId2)
        {
            TEComparisonService comparison = new TEComparisonService();
            var season = comparison.Get2TeSeasonStatsById(seasonId1, seasonId2);
            comparison.DisplayTeStatComparison(season);
            return Ok(season);
        }
    }
}
