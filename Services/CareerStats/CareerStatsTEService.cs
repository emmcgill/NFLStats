using Data;
using Data.CareerStats;
using Models.CareerStatsRB;
using Models.CareerStatsTE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Services.CareerStats
{
    public class CareerStatsTEService
    {
        public bool CreateCareerStatsTE(CareerStatsTECreate career)
        {
            var playerCareer = new CareerStatsTE()
            {
                PlayerId = career.PlayerId,
                Name = career.Name,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.CareerStatsTEs.Add(playerCareer);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CareerStatsTEListItem> GetCareerTEs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .CareerStatsTEs
                        .Select(
                            c => new CareerStatsTEListItem
                            {
                                PlayerId = c.PlayerId,
                                Name = c.Name,
                            }
                        );

                return query.ToArray();
            }
        }

        public IEnumerable<CareerStatsTEDetail> GetCareerStatTotals(int playerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Players
                        .Where(p => p.PlayerId == playerId)
                        .Select(
                            p => new CareerStatsTEDetail
                            {
                                PlayerId = p.PlayerId,
                                Name = p.Name,
                                Receptions = ctx.TeSeasonStats.Where(s => s.PlayerId == p.PlayerId).Sum(s => s.Receptions),
                                Targets = ctx.TeSeasonStats.Where(s => s.PlayerId == p.PlayerId).Sum(s => s.Targets),
                                Drops = ctx.TeSeasonStats.Where(s => s.PlayerId == p.PlayerId).Sum(s => s.Drops),
                                ReceivingYards = ctx.TeSeasonStats.Where(s => s.PlayerId == p.PlayerId).Sum(s => s.ReceivingYards),
                                YardsAfterCatch = ctx.TeSeasonStats.Where(s => s.PlayerId == p.PlayerId).Sum(s => s.YardsAfterCatch),
                                Touchdowns = ctx.TeSeasonStats.Where(s => s.PlayerId == p.PlayerId).Sum(s => s.Touchdowns)
                            }
                        );

                return query.ToArray();
            }
        }

        public bool UpdateCareerStatsTE(CareerStatsTEEdit career)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CareerStatsTEs
                        .Single(c => c.CareerTEId == career.CareerTEId);

                entity.PlayerId = career.PlayerId;
                entity.Name = career.Name;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCareerStatsTE(int career)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CareerStatsTEs
                        .Single(c => c.CareerTEId == career);

                ctx.CareerStatsTEs.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
