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
                ctx.careerStatsQBs.Add(playerCareer);
                return ctx.SaveChanges() == 1;
            }
        }
       

        public CareerStatsQBDetail GetCareerStatsQBById(int careerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var career =
                    ctx
                        .careerStatsQBs
                        .Single(c => c.CareerQBId == careerId);
                return new CareerStatsQBDetail
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
            }
        }

        public bool UpdateCareerStatsQB(CareerStatsQBEdit career)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .careerStatsQBs
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
                        .careerStatsQBs
                        .Single(c => c.CareerQBId == career);

                ctx.careerStatsQBs.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
