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
                Name = career.Name,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.CareerStatsWRs.Add(playerCareer);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CareerStatsWRListItem> GetCareerWRs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .CareerStatsWRs
                        .Select(
                            c => new CareerStatsWRListItem
                            {
                                PlayerId = c.PlayerId,
                                Name = c.Name
                            }
                        );

                return query.ToArray();
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
                                PlayerId = p.PlayerId,
                                Name = p.Name,
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
                entity.Name = career.Name;

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
