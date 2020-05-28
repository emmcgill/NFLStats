using Data;
using Data.SeasonStats;
using Models.SeasonStatsTe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TeSeasonStatService
    {
        //CREATE
        public bool TeCreateSeason(TeSeasonStatCreate season)
        {
            var playerSeason = new SeasonStatTe()
            {

                PlayerId = season.PlayerId,
                Year = season.Year,
                Receptions = season.Receptions,
                Targets = season.Targets,
                Drops = season.Drops,
                ReceivingYards = season.ReceivingYards,
                YardsAfterCatch = season.YardsAfterCatch,
                Touchdowns = season.Touchdowns

            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.TeSeasonStats.Add(playerSeason);
                return ctx.SaveChanges() == 1;
            }
        }

        //GET BY SEASON ID
        public TeSeasonStatDetail GetTeSeasonBySeasonId(int seasonId)
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
                        Touchdowns = season.Touchdowns
                    };
            }
        }

        //GET ALL PLAYER SEASONS
        public IEnumerable<TeSeasonStatListItem> GetTeSeasonsByPlayerId(int playerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .TeSeasonStats
                        .Where(s => s.PlayerId == playerId && s.IsDeleted == false)
                        .Select(
                        s =>

                    new TeSeasonStatListItem
                    {
                        Year = s.Year,
                        Receptions = s.Receptions,
                        Targets = s.Targets,
                        Drops = s.Drops,
                        ReceivingYards = s.ReceivingYards,
                        YardsAfterCatch = s.YardsAfterCatch,
                        Touchdowns = s.Touchdowns
                    }

                    );
                return query.ToArray();
            }
        }

        //UPDATE
        public bool UpdateTeSeasonStats(TeSeasonStatEdit season)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .TeSeasonStats
                        .Single(s => s.TeSeasonId == season.TeSeasonId && s.IsDeleted == false);

                entity.PlayerId = season.PlayerId;
                entity.Year = season.Year;
                entity.Receptions = season.Receptions;
                entity.Targets = season.Targets;
                entity.Drops = season.Drops;
                entity.ReceivingYards = season.ReceivingYards;
                entity.YardsAfterCatch = season.YardsAfterCatch;
                entity.Touchdowns = season.Touchdowns;

                return ctx.SaveChanges() == 1;
            }
        }

        //DELETE
        public bool DeleteTeSeasonStat(int seasonId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .TeSeasonStats
                        .Single(s => s.TeSeasonId == seasonId);

                if (!entity.IsDeleted)
                {
                    entity.IsDeleted = true;
                }
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
