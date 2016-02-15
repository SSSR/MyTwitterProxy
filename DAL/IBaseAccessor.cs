using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IBaseAccessor
    {
        ICollection<TweetDto> GetTweets(int count, int offset);
        void InsertTweets(ICollection<TweetDto> tweets);
    }
}
