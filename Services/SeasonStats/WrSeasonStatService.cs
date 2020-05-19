using Data;
using Data.SeasonStats;
using Models.SeasonStatsWr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class WrSeasonStatService
    {
        //CREATE
        public bool WrCreateSeason(WrSeasonStatCreate season)
        {
            var playerSeason = new SeasonStatWr()
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
                ctx.WrSeasonStats.Add(playerSeason);
                return ctx.SaveChanges() == 1;
            }
        }

        //GET BY SEASON ID
        public WrSeasonStatDetail GetWrSeasonBySeasonId(int seasonId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var season =
                    ctx
                        .WrSeasonStats
                        .Single(s => s.WrSeasonId == seasonId);
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
                        Touchdowns = season.Touchdowns
                    };
            }
        }

        //UPDATE
        public bool UpdateWrSeasonStats(WrSeasonStatEdit season)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .WrSeasonStats
                        .Single(s => s.WrSeasonId == season.WrSeasonId);

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
        public bool DeleteWrSeasonStat(int season)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .WrSeasonStats
                        .Single(s => s.WrSeasonId == season);

                ctx.WrSeasonStats.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
