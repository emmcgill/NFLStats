using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SeasonStatService
    {
        //CREATE
        public bool CreateSeason(SeasonStatCreate season)
        {
            var playerSeason = new SeasonStat()
            {
               
                PlayerId = season.PlayerId,
                Year = season.Year,
                PassingYards = season.PassingYards,
                RushingYards = season.RushingYards,
                Completions = season.Completions,
                Attempts = season.Attempts,
                PassingTouchdowns = season.PassingTouchdowns,
                RushingTouchdowns = season.RushingTouchdowns,
                Interceptions = season.Interceptions
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.SeasonStats.Add(playerSeason);
                return ctx.SaveChanges() == 1;
            }
        }

        //GET BY SEASON ID
        public SeasonStatDetail GetSeasonBySeasonId(int seasonId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var season =
                    ctx
                        .SeasonStats
                        .Single(s => s.SeasonId == seasonId);
                return
                    new SeasonStatDetail()
                    {
                        PlayerId = season.PlayerId,
                        Year = season.Year,
                        PassingYards = season.PassingYards,
                        RushingYards = season.RushingYards,
                        Completions = season.Completions,
                        Attempts = season.Attempts,
                        PassingTouchdowns = season.PassingTouchdowns,
                        RushingTouchdowns = season.RushingTouchdowns,
                        Interceptions = season.Interceptions
                    };
            }
        }

        //UPDATE
        public bool UpdateSeasonStats(SeasonStatEdit season)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .SeasonStats
                        .Single(s => s.SeasonId == season.SeasonId);

                entity.PlayerId = season.PlayerId;
                entity.Year = season.Year;
                entity.PassingYards = season.PassingYards;
                entity.RushingYards = season.RushingYards;
                entity.Completions = season.Completions;
                entity.Attempts = season.Attempts;
                entity.PassingTouchdowns = season.PassingTouchdowns;
                entity.RushingTouchdowns = season.RushingTouchdowns;
                entity.Interceptions = season.Interceptions;
  

                return ctx.SaveChanges() == 1;
            }
        }

        //DELETE
        public bool DeleteSeasonStat(int season)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .SeasonStats
                        .Single(s => s.SeasonId == season );

                ctx.SeasonStats.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
