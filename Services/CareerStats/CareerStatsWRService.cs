using Data;
using Data.CareerStats;
using Models.CareerStatsWR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Services.CareerStats
{
    public class CareerStatsWRService
    {
        public bool CreateCareerStatsWR(CareerStatsWRCreate career)
        {
            var playerCareer = new CareerStatsWR()
            {
                PlayerId = career.PlayerId,
                Receptions = career.Receptions,
                Targets = career.Targets,
                Drops = career.Drops,
                ReceivingYards = career.ReceivingYards,
                YardsAfterCatch = career.YardsAfterCatch,
                Touchdowns = career.Touchdowns,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.CareerStatsWRs.Add(playerCareer);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CareerStatsWRDetail> GetCareerStatTotals(int playerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Players
                        .Where(p => p.PlayerId == playerId)
                        .Select(
                            p => new CareerStatsWRDetail
                            {                                
                                Receptions = ctx.WrSeasonStats.Where(s => s.PlayerId == p.PlayerId).Sum(s => s.Receptions),
                                Targets = ctx.WrSeasonStats.Where(s => s.PlayerId == p.PlayerId).Sum(s => s.Targets),
                                Drops = ctx.WrSeasonStats.Where(s => s.PlayerId == p.PlayerId).Sum(s => s.Drops),
                                ReceivingYards = ctx.WrSeasonStats.Where(s => s.PlayerId == p.PlayerId).Sum(s => s.ReceivingYards),
                                YardsAfterCatch = ctx.WrSeasonStats.Where(s => s.PlayerId == p.PlayerId).Sum(s => s.YardsAfterCatch),
                                Touchdowns = ctx.WrSeasonStats.Where(s => s.PlayerId == p.PlayerId).Sum(s => s.Touchdowns)
                            }
                        );

                return query.ToArray();
            }
        }

        public bool UpdateCareerStatsWR(CareerStatsWREdit career)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CareerStatsWRs
                        .Single(c => c.CareerWRId == career.CareerWRId);

                entity.PlayerId = career.PlayerId;
                entity.Receptions = career.Receptions;
                entity.Targets = career.Targets;
                entity.Drops = career.Drops;
                entity.ReceivingYards = career.ReceivingYards;
                entity.YardsAfterCatch = career.YardsAfterCatch;
                entity.Touchdowns = career.Touchdowns;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCareerStatsWR(int career)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CareerStatsWRs
                        .Single(c => c.CareerWRId == career);

                ctx.CareerStatsWRs.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
