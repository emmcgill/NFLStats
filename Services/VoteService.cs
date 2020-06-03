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
            var newVote =
                new Vote()
                {
                    PlayerId = vote.PlayerId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Votes.Add(newVote);
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
                    var voteToDelete =
                        ctx
                            .Votes
                            .Single(e => e.VoteId == vote.VoteId);

                    if (!voteToDelete.IsDeleted)
                    {
                        voteToDelete.IsDeleted = true;
                        voteToDelete.ModifiedUtc = DateTimeOffset.UtcNow;
                    }
                    return ctx.SaveChanges() == 1;
            }
        }

        public bool ReactivateVoteById(VoteEdit vote)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var voteToReactivate =
                    ctx
                        .Votes
                        .Single(e => e.VoteId == vote.VoteId);

                if (voteToReactivate.IsDeleted)
                {
                    voteToReactivate.IsDeleted = false;
                    voteToReactivate.ModifiedUtc = DateTimeOffset.UtcNow;
                }
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
