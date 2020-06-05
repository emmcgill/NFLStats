using Data;
using Models;
using Models.CareerStatsQB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CareerStatsQBService
    {
        public bool CreateCareerStatsQB(CareerStatsQBCreate career)
        {
            var playerCareer = new CareerStatsQB()
            {
                PlayerId = career.PlayerId,
                Name = career.Name,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.CareerStatsQBs.Add(playerCareer);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CareerStatsQBListItem> GetCareerQBs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .CareerStatsQBs
                        .Select(
                            c => new CareerStatsQBListItem
                            {
                                PlayerId = c.PlayerId,
                                Name = c.Name
                            }
                        );

                return query.ToArray();
            }
        }

        public IEnumerable<CareerStatsQBDetail> GetCareerStatTotals(int playerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Players
                        .Where(p => p.PlayerId == playerId)
                        .Select(
                            p => new CareerStatsQBDetail
                            {
                                PlayerId = p.PlayerId,
                                Name = p.Name,
                                PassingYards = ctx.SeasonStat.Where(s => s.PlayerId == p.PlayerId).Sum(s => s.PassingYards),
                                RushingYards = ctx.SeasonStat.Where(s => s.PlayerId == p.PlayerId).Sum(s => s.RushingYards),
                                Completions = ctx.SeasonStat.Where(s => s.PlayerId == p.PlayerId).Sum(s => s.Completions),
                                Attempts = ctx.SeasonStat.Where(s => s.PlayerId == p.PlayerId).Sum(s => s.Attempts),
                                PassingTouchdowns = ctx.SeasonStat.Where(s => s.PlayerId == p.PlayerId).Sum(s => s.PassingTouchdowns),
                                RushingTouchdowns = ctx.SeasonStat.Where(s => s.PlayerId == p.PlayerId).Sum(s => s.RushingTouchdowns),
                                Interceptions = ctx.SeasonStat.Where(s => s.PlayerId == p.PlayerId).Sum(s => s.Interceptions)
                            }
                        );

                return query.ToArray();
            }
        }

        public bool UpdateCareerStatsQB(CareerStatsQBEdit career)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CareerStatsQBs
                        .Single(c => c.CareerQBId == career.CareerQBId);

                entity.PlayerId = career.PlayerId;
                entity.Name = career.Name;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCareerStatsQB(int careerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CareerStatsQBs
                        .Single(c => c.CareerQBId == careerId);

                ctx.CareerStatsQBs.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
