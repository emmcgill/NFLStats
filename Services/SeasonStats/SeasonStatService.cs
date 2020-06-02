using Data;
using Models;
using Models.SeasonStatsQB;
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
                Interceptions = season.Interceptions,
                PlayerNumber = season.PlayerNumber,
                Team = season.Team
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
                        .Single(s => s.SeasonId == seasonId && s.IsDeleted == false);
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
                        Interceptions = season.Interceptions,
                        PlayerNumber = season.PlayerNumber,
                        Team = season.Team
                    };
            }
        }

        //GET ALL PLAYER SEASONS
        public IEnumerable<SeasonStatListItem> GetQbSeasonsByPlayerId(int playerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .SeasonStats
                        .Where(s => s.PlayerId == playerId && s.IsDeleted == false)
                        .Select(
                        s =>

                    new SeasonStatListItem
                    {
                        Year = s.Year,
                        PassingYards = s.PassingYards,
                        RushingYards = s.RushingYards,
                        Completions = s.Completions,
                        Attempts = s.Attempts,
                        PassingTouchdowns = s.PassingTouchdowns,
                        RushingTouchdowns = s.RushingTouchdowns,
                        Interceptions = s.Interceptions,
                        PlayerNumber = s.PlayerNumber,
                        Team = s.Team
                    }

                    );
                return query.ToArray();
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
                        .Single(s => s.SeasonId == season.SeasonId && s.IsDeleted == false);

                entity.PlayerId = season.PlayerId;
                entity.Year = season.Year;
                entity.PassingYards = season.PassingYards;
                entity.RushingYards = season.RushingYards;
                entity.Completions = season.Completions;
                entity.Attempts = season.Attempts;
                entity.PassingTouchdowns = season.PassingTouchdowns;
                entity.RushingTouchdowns = season.RushingTouchdowns;
                entity.Interceptions = season.Interceptions;
                entity.PlayerNumber = season.PlayerNumber;
                entity.Team = season.Team;

                return ctx.SaveChanges() == 1;
            }
        }

        //DELETE
        public bool DeleteSeasonStat(int seasonId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .SeasonStats
                        .Single(s => s.SeasonId == seasonId);

                if (!entity.IsDeleted)
                {
                    entity.IsDeleted = true;
                }
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
