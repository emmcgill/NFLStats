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
                ctx.careerStatsWRs.Add(playerCareer);
                return ctx.SaveChanges() == 1;
            }
        }

        public CareerStatsWRDetail GetCareerStatsWRById(int careerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var career =
                    ctx
                        .careerStatsWRs
                        .Single(c => c.CareerWRId == careerId);
                return new CareerStatsWRDetail
                {
                    PlayerId = career.PlayerId,
                    Receptions = career.Receptions,
                    Targets = career.Targets,
                    Drops = career.Drops,
                    ReceivingYards = career.ReceivingYards,
                    YardsAfterCatch = career.YardsAfterCatch,
                    Touchdowns = career.Touchdowns,
                };
            }
        }

        public bool UpdateCareerStatsWR(CareerStatsWREdit career)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .careerStatsWRs
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
                        .careerStatsWRs
                        .Single(c => c.CareerWRId == career);

                ctx.careerStatsWRs.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
