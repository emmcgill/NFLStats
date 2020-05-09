using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PlayerService
    { 
        public bool CreatePlayer(PlayerCreate player)
        {
            var entity = new Player()
            {
                 name = player.Name,
                 playerNumber = player.PlayerNumber,
                 playerPosition = player.PlayerPosition,
                 team = player.Team
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Players.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PlayerListItem> GetPlayers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Players
                    .Select(
                        p => new PlayerListItem
                        {
                            Name = p.name,
                            PlayerNumber = p.playerNumber,
                            PlayerPosition = p.playerPosition,
                            Team = p.team
                        }
                    );
                return query.ToArray();
            }
        }

        public PlayerDetail GetPlayerByName(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Players
                        .Single(p => p.name == name);
                return
                    new PlayerDetail
                    {
                        Name = entity.name,
                        PlayerNumber = entity.playerNumber,
                        PlayerPosition = entity.playerPosition,
                        Team = entity.team,
                        CreatedUtc = entity.createdUtc,
                        ModifiedUtc = entity.modifiedUtc
                    };
            }
        }

        public bool UpdatePlayer(PlayerEdit player)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Players
                        .Single(p => p.name == player.Name);
                entity.name = player.Name;
                entity.playerNumber = player.PlayerNumber;
                entity.playerPosition = player.PlayerPosition;
                entity.team = player.Team;
                entity.modifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePlayer(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Players
                        .Single(p => p.name == name);

                ctx.Players.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
