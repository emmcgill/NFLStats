using Data;
using Models;
using Models.SeasonStatsRB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RbSeasonStatService
    {
        //CREATE
        public bool RbCreateSeason(RbSeasonStatCreate season)
        {
            var playerSeason = new SeasonStatRb()
            {

                PlayerId = season.PlayerId,
                Year = season.Year,
                RushingYards = season.RushingYards,
                RushingAttempts = season.RushingAttempts,
                ReceivingYards = season.ReceivingYards,
                Receptions = season.Receptions,
                RushingTouchdowns = season.RushingTouchdowns,
                ReceivingTouchdowns = season.ReceivingTouchdowns,
                Fumbles = season.Fumbles

            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.RbSeasonStats.Add(playerSeason);
                return ctx.SaveChanges() == 1;
            }
        }

        //GET BY SEASON ID
        public RbSeasonStatDetail GetRbSeasonBySeasonId(int seasonId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var season =
                    ctx
                        .RbSeasonStats
                        .Single(s => s.RbSeasonId == seasonId);
                return
                    new RbSeasonStatDetail()
                    {
                        PlayerId = season.PlayerId,
                        Year = season.Year,
                        RushingYards = season.RushingYards,
                        RushingAttempts = season.RushingAttempts,
                        ReceivingYards = season.ReceivingYards,
                        Receptions = season.Receptions,
                        RushingTouchdowns = season.RushingTouchdowns,
                        ReceivingTouchdowns = season.ReceivingTouchdowns,
                        Fumbles = season.Fumbles
                    };
            }
        }

        //UPDATE
        public bool UpdateRbSeasonStats(RbSeasonStatEdit season)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .RbSeasonStats
                        .Single(s => s.RbSeasonId == season.RbSeasonId);

                entity.PlayerId = season.PlayerId;
                entity.Year = season.Year;
                entity.RushingYards = season.RushingYards;
                entity.RushingAttempts = season.RushingAttempts;
                entity.ReceivingYards = season.ReceivingYards;
                entity.Receptions = season.Receptions;
                entity.RushingTouchdowns = season.RushingTouchdowns;
                entity.ReceivingTouchdowns = season.ReceivingTouchdowns;
                entity.Fumbles = season.Fumbles;



                return ctx.SaveChanges() == 1;
            }
        }

        //DELETE
        public bool DeleteRbSeasonStat(int season)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .RbSeasonStats
                        .Single(s => s.RbSeasonId == season);

                ctx.RbSeasonStats.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
