using Data;
using Models;
using Models.VoteClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public class VoteService
    { 
        public VoteService()
        {
            
        }

        public bool CreateVote(VoteCreate vote)
        {
            var entity =
                new Vote()
                {
                    PlayerId = vote.PlayerId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Votes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<VoteListItem> GetVotesByUser(string userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Votes
                        .Where(vote => vote.UserId == userId && !vote.IsDeleted)
                        .Select(
                            e =>
                                new VoteListItem
                                {
                                    VoteId = e.VoteId,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<VoteListItem> GetVotesByPlayerId(int playerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Votes
                        .Where(vote => vote.PlayerId == playerId && !vote.IsDeleted)
                        .Select
                        (p => new VoteListItem
                        {
                            VoteId = p.VoteId,
                            CreatedUtc = p.CreatedUtc
                        });

                return query.ToArray();
            }
        }

        

        public bool DeleteVoteById(VoteEdit vote)
        {
            using(var ctx = new ApplicationDbContext())
            {
                    var entity =
                        ctx
                            .Votes
                            .Single(e => e.VoteId == vote.VoteId);

                    if (!entity.IsDeleted)
                    {
                        entity.IsDeleted = true;
                        entity.ModifiedUtc = DateTimeOffset.UtcNow;
                    }
                    return ctx.SaveChanges() == 1;
            }
        }

        public bool ReactivateVoteById(VoteEdit vote)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Votes
                        .Single(e => e.VoteId == vote.VoteId);

                if (entity.IsDeleted)
                {
                    entity.IsDeleted = false;
                    entity.ModifiedUtc = DateTimeOffset.UtcNow;
                }
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
