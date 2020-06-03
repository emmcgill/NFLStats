using Data;
using Models;
using Models.CareerStatsQBModels;
using Models.SeasonStatsQB;
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
                PassingYards = career.PassingYards,
                RushingYards = career.RushingYards,
                Completions = career.Completions,
                Attempts = career.Attempts,
                PassingTouchdowns = career.PassingTouchdowns,
                RushingTouchdowns = career.RushingTouchdowns,
                Interceptions = career.Interceptions,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.CareerStatsQBs.Add(playerCareer);
                return ctx.SaveChanges() == 1;
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
                entity.PassingYards = career.PassingYards;
                entity.RushingYards = career.RushingYards;
                entity.Completions = career.Completions;
                entity.Attempts = career.Attempts;
                entity.PassingTouchdowns = career.PassingTouchdowns;
                entity.RushingTouchdowns = career.RushingTouchdowns;
                entity.Interceptions = career.Interceptions;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCareerStatsQB(int career)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CareerStatsQBs
                        .Single(c => c.CareerQBId == career);

                ctx.CareerStatsQBs.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }               
    }
}
