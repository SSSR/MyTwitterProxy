using BLToolkit.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BaseAccessor : DataAccessor, IBaseAccessor
    {
        [SprocName("GetTweets")]
        public abstract IList<TweetDto> GetTweets(int count, int offset);

        [SprocName("InsertTweets")]
        public void InsertTweets(ICollection<TweetDto> tweets)
        {
            throw new NotImplementedException();
        }
    }
}
