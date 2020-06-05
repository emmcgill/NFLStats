using Data;
using Models.SeasonStatsTe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ComparisonServices
{
    public class TEComparisonService
    {
        public List<TeSeasonStatDetail> Get2TeSeasonStatsById(int seasonId1, int seasonId2)
        {
            List<TeSeasonStatDetail> compareSeasonStats = new List<TeSeasonStatDetail>();
            TeSeasonStatDetail playerSeasonStat1 = GetTeSeasonStatForComparison(seasonId1);
            compareSeasonStats.Add(playerSeasonStat1);
            TeSeasonStatDetail playerSeasonStat2 = GetTeSeasonStatForComparison(seasonId2);
            compareSeasonStats.Add(playerSeasonStat2);

            return compareSeasonStats;
        }

        public List<TeSeasonStatDetail> DisplayTeStatComparison(List<TeSeasonStatDetail> playerSeasonStats)
        {
            foreach (TeSeasonStatDetail stats in playerSeasonStats)
            {
                TeSeasonStatDetail playerStats = new TeSeasonStatDetail();
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



        public TeSeasonStatDetail GetTeSeasonStatForComparison(int seasonId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var season =
                    ctx
                        .TeSeasonStats
                        .Single(s => s.TeSeasonId == seasonId && s.IsDeleted == false);
                return
                    new TeSeasonStatDetail()
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
