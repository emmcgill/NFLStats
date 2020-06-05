using Data;
using Models.SeasonStatsRB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ComparisonServices
{
    public class RBComparisonService
    {
        public List<RbSeasonStatDetail> Get2RbSeasonStatsById(int seasonId1, int seasonId2)
        {
            List<RbSeasonStatDetail> compareSeasonStats = new List<RbSeasonStatDetail>();
            RbSeasonStatDetail playerSeasonStat1 = GetRbSeasonStatForComparison(seasonId1);
            compareSeasonStats.Add(playerSeasonStat1);
            RbSeasonStatDetail playerSeasonStat2 = GetRbSeasonStatForComparison(seasonId2);
            compareSeasonStats.Add(playerSeasonStat2);

            return compareSeasonStats;
        }

        public List<RbSeasonStatDetail> DisplayRbStatComparison(List<RbSeasonStatDetail> playerSeasonStats)
        {
            foreach (RbSeasonStatDetail stats in playerSeasonStats)
            {
                RbSeasonStatDetail playerStats = new RbSeasonStatDetail();
                playerStats.Year = stats.Year;
                playerStats.RushingYards = stats.RushingYards;
                playerStats.RushingAttempts = stats.RushingAttempts;
                playerStats.ReceivingYards = stats.ReceivingYards;
                playerStats.Receptions = stats.Receptions;
                playerStats.RushingTouchdowns = stats.RushingTouchdowns;
                playerStats.ReceivingTouchdowns = stats.ReceivingTouchdowns;
                playerStats.Fumbles = stats.Fumbles;

                return playerSeasonStats;

            }
            return null;
        }



        public RbSeasonStatDetail GetRbSeasonStatForComparison(int seasonId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var season =
                    ctx
                        .RbSeasonStats
                        .Single(s => s.RbSeasonId == seasonId && s.IsDeleted == false);
                return
                    new RbSeasonStatDetail()
                    {
                        PlayerId = season.PlayerId,
                        Year = season.Year,
                        RushingYards = season.RushingYards,
                        RushingAttempts = season.RushingAttempts,
                        ReceivingYards = season.ReceivingYards,
                        Receptions = season.Receptions,
                        RushingTouchdowns = season.RushingTouchdowns,
                        ReceivingTouchdowns = season.ReceivingTouchdowns,
                        Fumbles = season.Fumbles,
                        PlayerNumber = season.PlayerNumber,
                        Team = season.Team
                    };
            }
        }
    }
}
