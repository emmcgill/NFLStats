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
                Fumbles = season.Fumbles,
                PlayerNumber = season.PlayerNumber,
                Team = season.Team

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
                        .Single(s => s.RbSeasonId == seasonId && s.IsDeleted == false);
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
                        Fumbles = season.Fumbles,
                        PlayerNumber = season.PlayerNumber,
                        Team = season.Team
                    };
            }
        }


        //GET ALL PLAYER SEASONS
        public IEnumerable<RbSeasonStatListItem> GetRbSeasonsByPlayerId(int playerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .RbSeasonStats
                        .Where(s => s.PlayerId == playerId && s.IsDeleted == false)
                        .Select(
                        s =>

                    new RbSeasonStatListItem
                    {
                        Year = s.Year,
                        RushingYards = s.RushingYards,
                        RushingAttempts = s.RushingAttempts,
                        ReceivingYards = s.ReceivingYards,
                        Receptions = s.Receptions,
                        RushingTouchdowns = s.RushingTouchdowns,
                        ReceivingTouchdowns = s.ReceivingTouchdowns,
                        Fumbles = s.Fumbles,
                        PlayerNumber = s.PlayerNumber,
                        Team = s.Team
                    }

                    );
                return query.ToArray();
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
                        .Single(s => s.RbSeasonId == season.RbSeasonId && s.IsDeleted == false);

                entity.PlayerId = season.PlayerId;
                entity.Year = season.Year;
                entity.RushingYards = season.RushingYards;
                entity.RushingAttempts = season.RushingAttempts;
                entity.ReceivingYards = season.ReceivingYards;
                entity.Receptions = season.Receptions;
                entity.RushingTouchdowns = season.RushingTouchdowns;
                entity.ReceivingTouchdowns = season.ReceivingTouchdowns;
                entity.Fumbles = season.Fumbles;
                entity.PlayerNumber = season.PlayerNumber;
                entity.Team = season.Team;


                return ctx.SaveChanges() == 1;
            }
        }

        //DELETE
        public bool DeleteRbSeasonStat(int seasonId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .RbSeasonStats
                        .Single(s => s.RbSeasonId == seasonId);

                if (!entity.IsDeleted)
                {
                    entity.IsDeleted = true;
                }
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
