using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IBaseAccessor
    {
        IQueryable<Tweet> GetTweets();
        void InsertTweets(IEnumerable<Tweet> tweets);

        void RemoveTweet(Guid id);
    }
}
