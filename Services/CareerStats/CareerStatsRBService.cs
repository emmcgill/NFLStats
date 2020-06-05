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
                Name = career.Name,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.CareerStatsRBs.Add(playerCareer);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CareerStatsRBListItem> GetCareerRBs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .CareerStatsRBs
                        .Select(
                            c => new CareerStatsRBListItem
                            {
                                PlayerId = c.PlayerId,
                                Name = c.Name,
                            }
                        );

                return query.ToArray();
            }
        }

        public IEnumerable<CareerStatsRBDetail> GetCareerStatTotals(int playerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Players
                        .Where(p => p.PlayerId == playerId)
                        .Select(
                            p => new CareerStatsRBDetail
                            {
                                PlayerId = p.PlayerId,
                                Name = p.Name,
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
                entity.Name = career.Name;

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
