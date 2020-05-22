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
                ctx.careerStatsRBs.Add(playerCareer);
                return ctx.SaveChanges() == 1;
            }
        }

        public CareerStatsRBDetail GetCareerStatsRBById(int careerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var career =
                    ctx
                        .careerStatsRBs
                        .Single(c => c.CareerRBId == careerId);
                return new CareerStatsRBDetail
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
            }
        }

        public bool UpdateCareerStatsRB(CareerStatsRBEdit career)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .careerStatsRBs
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
                        .careerStatsRBs
                        .Single(c => c.CareerRBId == career);

                ctx.careerStatsRBs.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
