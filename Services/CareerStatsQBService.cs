using Data;
using Models;
using Models.CareerStatsQBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CareerStatsQBService
    {
        public bool CreateCareerStatsQB(CareerStatsQBCreate career)
        {
            var entity = new CareerStatsQB()
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
                ctx.careerStatsQBs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CareerStatsQBListItem> GetCareerStatsQBs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                       .careerStatsQBs
                       .Select(e => new CareerStatsQBListItem
                       {
                           PlayerId = e.PlayerId,                           
                       });
                return query.ToArray();
            }
        }

        public CareerStatsQBDetail GetCareerStatsQBById(int careerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .careerStatsQBs
                        .Single(e => e.PlayerId == careerId);
                return new CareerStatsQBDetail
                {
                    PlayerId = entity.PlayerId,
                    PassingYards = entity.PassingYards,
                    RushingYards = entity.RushingYards,
                    Completions = entity.Completions,
                    Attempts = entity.Attempts,
                    PassingTouchdowns = entity.PassingTouchdowns,
                    RushingTouchdowns = entity.RushingTouchdowns,
                    Interceptions = entity.Interceptions,
                };
            }
        }

        public bool UpdateCareerStatsQB(CareerStatsQBEdit career)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .careerStatsQBs
                        .Single(e => e.PlayerId == career.PlayerId);

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

        public bool DeleteCareerStatsQB(int playerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .careerStatsQBs
                        .Single(e => e.PlayerId == playerId);

                ctx.careerStatsQBs.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
