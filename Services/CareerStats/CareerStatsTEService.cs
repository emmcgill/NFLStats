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
                Receptions = career.Receptions,
                Targets = career.Targets,
                Drops = career.Drops,
                ReceivingYards = career.ReceivingYards,
                YardsAfterCatch = career.YardsAfterCatch,
                Touchdowns = career.Touchdowns,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.careerStatsTEs.Add(playerCareer);
                return ctx.SaveChanges() == 1;
            }
        }

        public CareerStatsTEDetail GetCareerStatsTEById(int careerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var career =
                    ctx
                        .careerStatsTEs
                        .Single(c => c.CareerTEId == careerId);
                return new CareerStatsTEDetail
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

        public bool UpdateCareerStatsTE(CareerStatsTEEdit career)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .careerStatsTEs
                        .Single(c => c.CareerTEId == career.CareerTEId);

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

        public bool DeleteCareerStatsTE(int career)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .careerStatsTEs
                        .Single(c => c.CareerTEId == career);

                ctx.careerStatsTEs.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
