using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RankService
    {
        public bool CreateRank(RankCreate rank)
        {
            var entity = new Rank()
            {
                RankId = rank.RankId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Rankings.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RankListItem> GetRankings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = 
                    ctx
                        .Rankings
                        .Select(
                            e => 
                                new RankListItem
                                {
                                    RankId = e.RankId,
                                    PlayerId = e.PlayerId,
                                    Name = e.Name,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
