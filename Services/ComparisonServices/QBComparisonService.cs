using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ComparisonServices
{
    public class QBComparisonService
    {
        public List<SeasonStatDetail> Get2QbSeasonStatsById(int seasonId1, int seasonId2)
        {
            List<SeasonStatDetail> compareSeasonStats = new List<SeasonStatDetail>();
            SeasonStatDetail playerSeasonStat1 = GetQbSeasonStatForComparison(seasonId1);
            compareSeasonStats.Add(playerSeasonStat1);
            SeasonStatDetail playerSeasonStat2 = GetQbSeasonStatForComparison(seasonId2);
            compareSeasonStats.Add(playerSeasonStat2);

            return compareSeasonStats;
        }

        public List<SeasonStatDetail> DisplayQbStatComparison(List<SeasonStatDetail> playerSeasonStats)
        {
            foreach (SeasonStatDetail stats in playerSeasonStats)
            {
                SeasonStatDetail playerStats = new SeasonStatDetail();
                playerStats.Year = stats.Year;
                playerStats.PassingYards = stats.PassingYards;
                playerStats.RushingYards = stats.RushingYards;
                playerStats.Completions = stats.Completions;
                playerStats.Attempts = stats.Attempts;
                playerStats.PassingTouchdowns = stats.PassingTouchdowns;
                playerStats.RushingTouchdowns = stats.RushingTouchdowns;
                playerStats.Interceptions = stats.Interceptions;

                return playerSeasonStats;

            }
            return null;
        }



        public SeasonStatDetail GetQbSeasonStatForComparison(int seasonId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var season =
                    ctx
                        .SeasonStat
                        .Single(s => s.SeasonId == seasonId && s.IsDeleted == false);
                return
                    new SeasonStatDetail()
                    {
                        PlayerId = season.PlayerId,
                        Year = season.Year,
                        PassingYards = season.PassingYards,
                        RushingYards = season.RushingYards,
                        Completions = season.Completions,
                        Attempts = season.Attempts,
                        PassingTouchdowns = season.PassingTouchdowns,
                        RushingTouchdowns = season.RushingTouchdowns,
                        Interceptions = season.Interceptions,
                        PlayerNumber = season.PlayerNumber,
                        Team = season.Team
                    };
            }
        }
    }
}
