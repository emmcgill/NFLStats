using Data;
using Models.SeasonStatsWr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ComparisonServices
{
    public class WRComparisonService
    {
        public List<WrSeasonStatDetail> Get2WrSeasonStatsById(int seasonId1, int seasonId2)
        {
            List<WrSeasonStatDetail> compareSeasonStats = new List<WrSeasonStatDetail>();
            WrSeasonStatDetail playerSeasonStat1 = GetWrSeasonStatForComparison(seasonId1);
            compareSeasonStats.Add(playerSeasonStat1);
            WrSeasonStatDetail playerSeasonStat2 = GetWrSeasonStatForComparison(seasonId2);
            compareSeasonStats.Add(playerSeasonStat2);

            return compareSeasonStats;
        }

        public List<WrSeasonStatDetail> DisplayWrStatComparison(List<WrSeasonStatDetail> playerSeasonStats)
        {
            foreach (WrSeasonStatDetail stats in playerSeasonStats)
            {
                WrSeasonStatDetail playerStats = new WrSeasonStatDetail();
                playerStats.Year = stats.Year;
                playerStats.Receptions = stats.Receptions;
                playerStats.Targets = stats.Targets;
                playerStats.Drops = stats.Drops;
                playerStats.ReceivingYards = stats.ReceivingYards;
                playerStats.YardsAfterCatch = stats.YardsAfterCatch;
                playerStats.Touchdowns = stats.Touchdowns;

                return playerSeasonStats;

            }
            return null;
        }



        public WrSeasonStatDetail GetWrSeasonStatForComparison(int seasonId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var season =
                    ctx
                        .WrSeasonStats
                        .Single(s => s.WrSeasonId == seasonId && s.IsDeleted == false);
                return
                    new WrSeasonStatDetail()
                    {
                        PlayerId = season.PlayerId,
                        Year = season.Year,
                        Receptions = season.Receptions,
                        Targets = season.Targets,
                        Drops = season.Drops,
                        ReceivingYards = season.ReceivingYards,
                        YardsAfterCatch = season.YardsAfterCatch,
                        Touchdowns = season.Touchdowns,
                        PlayerNumber = season.PlayerNumber,
                        Team = season.Team
                    };
            }
        }
    }
}
