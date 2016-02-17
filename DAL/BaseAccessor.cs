using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BaseAccessor : IBaseAccessor
    {
        private MasterEntities _context;
        private BaseAccessor()
        {
            _context = new MasterEntities();
        }

        private readonly static BaseAccessor _accessor = new BaseAccessor();

        public static BaseAccessor GetInstance()
        {
            return _accessor;
        }
        public IQueryable<Tweet> GetTweets()
        {
            return _context.Tweets.AsQueryable().OrderByDescending(el => el.Date);
        }

        public void InsertTweets(IEnumerable<Tweet> tweets)
        {
            using (var scope = new System.Transactions.TransactionScope())
            {

                MasterEntities context = null;
                try
                {
                    context = CreateContext();

                    int count = 0;
                    foreach (var entityToInsert in tweets)
                    {
                        ++count;
                        entityToInsert.Id =Guid.NewGuid();
                        entityToInsert.Date = DateTime.Now;
                        context = AddToContext(context, entityToInsert, count, 50, false);
                    }

                    context.SaveChanges();
                }
                finally
                {
                    if (context != null)
                        context.Dispose();
                }

                scope.Complete();
            }
        }

        private MasterEntities AddToContext(MasterEntities context, Tweet entity, int count,
                                                        int commitCount, bool recreateContext)
        {
            context.Tweets.Add(entity);

            if (count % commitCount == 0)
            {
                context.SaveChanges();
                if (recreateContext)
                {
                    context.Dispose();
                    context = CreateContext();
                }
            }

            return context;
        }

        private MasterEntities CreateContext()
        {
            var context = new MasterEntities();

            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;
            return context;
        }



        public void RemoveTweet(Guid model)
        {
            var tweet = _context.Tweets.FirstOrDefault(e=>e.Id ==model);
            if(tweet != null)
            {
                _context.Tweets.Remove(tweet);
                _context.SaveChanges();
            }
          
        }
    }
}
