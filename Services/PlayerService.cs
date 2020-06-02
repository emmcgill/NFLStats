using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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
                 PlayerPosition = player.PlayerPosition,
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
                            PlayerPosition = p.PlayerPosition,
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
                        PlayerPosition = entity.PlayerPosition,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public IEnumerable<PlayerListItem> GetPlayerByRankings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Players
                        .Select(
                            p => new PlayerListItem
                            {
                                PlayerId = p.PlayerId,
                                Name = p.Name,
                                TotalVotes = ctx.Votes.Where(v => v.PlayerId == p.PlayerId).Count()
                            })
                        .OrderByDescending(p => p.TotalVotes);
                

                return query.ToArray();
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
                entity.PlayerPosition = player.PlayerPosition;
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
