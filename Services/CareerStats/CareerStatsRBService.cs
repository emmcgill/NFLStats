using Data;
using Models.CareerStatsRB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CareerStats
{
    public class CareerStatsRBService
    {
        public bool CreateCareerStatsRB(CareerStatsRBCreate career)
        {
            var playerCareer = new CareerStatsRB()
            {
                PlayerId = career.PlayerId,
                RushingYards = career.RushingYards,
                RushingAttempts = career.RushingAttempts,
                ReceivingYards = career.ReceivingYards,
                Receptions = career.Receptions,
                RushingTouchdowns = career.RushingTouchdowns,
                ReceivingTouchdowns = career.ReceivingTouchdowns,
                Fumbles = career.Fumbles,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.CareerStatsRBs.Add(playerCareer);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CareerStatsRBDetail> GetCareerStatTotals()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Players
                        .Select(
                            p => new CareerStatsRBDetail
                            {
                                PlayerId = p.PlayerId,
                                RushingYards = ctx.RbSeasonStats.Where(s => s.PlayerId == p.PlayerId).Sum(s => s.RushingYards),
                                RushingAttempts = ctx.RbSeasonStats.Where(s => s.PlayerId == p.PlayerId).Sum(s => s.RushingAttempts),
                                ReceivingYards = ctx.RbSeasonStats.Where(s => s.PlayerId == p.PlayerId).Sum(s => s.ReceivingYards),
                                Receptions = ctx.RbSeasonStats.Where(s => s.PlayerId == p.PlayerId).Sum(s => s.Receptions),
                                RushingTouchdowns = ctx.RbSeasonStats.Where(s => s.PlayerId == p.PlayerId).Sum(s => s.RushingTouchdowns),
                                ReceivingTouchdowns = ctx.RbSeasonStats.Where(s => s.PlayerId == p.PlayerId).Sum(s => s.ReceivingTouchdowns),
                                Fumbles = ctx.RbSeasonStats.Where(s => s.PlayerId == p.PlayerId).Sum(s => s.Fumbles)
                            }
                        );

                return query.ToArray();
            }
        }

        public bool UpdateCareerStatsRB(CareerStatsRBEdit career)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CareerStatsRBs
                        .Single(c => c.CareerRBId == career.CareerRBId);

                entity.PlayerId = career.PlayerId;
                entity.RushingYards = career.RushingYards;
                entity.RushingAttempts = career.RushingAttempts;
                entity.ReceivingYards = career.ReceivingYards;
                entity.Receptions = career.Receptions;
                entity.RushingTouchdowns = career.RushingTouchdowns;
                entity.ReceivingTouchdowns = career.ReceivingTouchdowns;
                entity.Fumbles = career.Fumbles;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCareerStatsRB(int career)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CareerStatsRBs
                        .Single(c => c.CareerRBId == career);

                ctx.CareerStatsRBs.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
