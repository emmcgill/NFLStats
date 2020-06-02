using Data;
using Data.SeasonStats;
using Models.SeasonStatsWr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class WrSeasonStatService
    {
        //CREATE
        public bool WrCreateSeason(WrSeasonStatCreate season)
        {
            var playerSeason = new SeasonStatWr()
            {

                PlayerId = season.PlayerId,
                Year = season.Year,
                Receptions = season.Receptions,
                Targets = season.Targets,
                Drops = season.Drops,
                ReceivingYards = season.ReceivingYards,
                YardsAfterCatch = season.YardsAfterCatch,
                Touchdowns = season.Touchdowns,
                PlayerNumber = season.PlayerNumber,
                Team = season.Team
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.WrSeasonStats.Add(playerSeason);
                return ctx.SaveChanges() == 1;
            }
        }

        //GET BY SEASON ID
        public WrSeasonStatDetail GetWrSeasonBySeasonId(int seasonId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var season =
                    ctx
                        .WrSeasonStats
                        .Single(s => s.WrSeasonId == seasonId && s.IsDeleted == false);
                return
                    new WrSeasonStatDetail()
                    {
                        PlayerId = season.PlayerId,
                        Year = season.Year,
                        Receptions = season.Receptions,
                        Targets = season.Targets,
                        Drops = season.Drops,
                        ReceivingYards = season.ReceivingYards,
                        YardsAfterCatch = season.YardsAfterCatch,
                        Touchdowns = season.Touchdowns,
                        PlayerNumber = season.PlayerNumber,
                        Team = season.Team
                    };
            }
        }

        //GET ALL PLAYER SEASONS
        public IEnumerable<WrSeasonStatListItem> GetWrSeasonsByPlayerId(int playerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .WrSeasonStats
                        .Where(s => s.PlayerId == playerId && s.IsDeleted == false)
                        .Select(
                        s =>

                    new WrSeasonStatListItem
                    {
                        Year = s.Year,
                        Receptions = s.Receptions,
                        Targets = s.Targets,
                        Drops = s.Drops,
                        ReceivingYards = s.ReceivingYards,
                        YardsAfterCatch = s.YardsAfterCatch,
                        Touchdowns = s.Touchdowns,
                        PlayerNumber = s.PlayerNumber,
                        Team = s.Team
                    }

                    );
                return query.ToArray();
            }
        }

        //UPDATE
        public bool UpdateWrSeasonStats(WrSeasonStatEdit season)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .WrSeasonStats
                        .Single(s => s.WrSeasonId == season.WrSeasonId && s.IsDeleted == false);

                entity.PlayerId = season.PlayerId;
                entity.Year = season.Year;
                entity.Receptions = season.Receptions;
                entity.Targets = season.Targets;
                entity.Drops = season.Drops;
                entity.ReceivingYards = season.ReceivingYards;
                entity.YardsAfterCatch = season.YardsAfterCatch;
                entity.Touchdowns = season.Touchdowns;
                entity.PlayerNumber = season.PlayerNumber;
                entity.Team = season.Team;

                return ctx.SaveChanges() == 1;
            }
        }

        //DELETE
        public bool DeleteWrSeasonStat(int seasonId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .WrSeasonStats
                        .Single(s => s.WrSeasonId == seasonId);

                if (!entity.IsDeleted)
                {
                    entity.IsDeleted = true;
                }
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
