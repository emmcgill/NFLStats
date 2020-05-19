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
                 Name = player.Name,
                 PlayerNumber = player.PlayerNumber,
                 PlayerPosition = player.PlayerPosition,
                 Team = player.Team
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
                            Name = p.Name,
                            PlayerNumber = p.PlayerNumber,
                            PlayerPosition = p.PlayerPosition,
                            Team = p.Team,
                            PlayerId = p.PlayerId
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
                        .Single(p => p.Name == name);
                return
                    new PlayerDetail
                    {
                        Name = entity.Name,
                        PlayerNumber = entity.PlayerNumber,
                        PlayerPosition = entity.PlayerPosition,
                        Team = entity.Team,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
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
                        .Single(p => p.Name == player.Name);
                entity.Name = player.Name;
                entity.PlayerNumber = player.PlayerNumber;
                entity.PlayerPosition = player.PlayerPosition;
                entity.Team = player.Team;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

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
                        .Single(p => p.Name == name);

                ctx.Players.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
