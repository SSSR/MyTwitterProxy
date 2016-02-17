using DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Tweetinvi;
using Tweetinvi.Core.Credentials;
using Tweetinvi.Core.Interfaces;
using Tweetinvi.Core.Parameters;
using Tweetinvi.Credentials;
using TwitterProxy.Models;

namespace TwitterProxy.Controllers
{
    public class HomeController : Controller
    {       
        private readonly string CONSUMER_KEY = "HnFalucDUpTXZpZp4q2NrZ5te";
        private readonly string CONSUMER_SECRET = "x1A3Jx1mRMnXKeJfVjGluVusTHOFtOkOHgTBQgGDIWJSgZiOKo";
        private string ACCESS_TOKEN = "4904594866-cBGMe5XoUpr5zzxIVx7qsU1GpoLEcGsA8QLiFcV";
        private string ACCESS_TOKEN_SECRET = "GOaAHMhRsgx6hxkO5RY3pYldT0TfkrrMPyaCOepAlLQ1e";
        private IBaseAccessor _accessor;

        public HomeController()
        {
            Auth.SetUserCredentials(CONSUMER_KEY, CONSUMER_SECRET, ACCESS_TOKEN, ACCESS_TOKEN_SECRET);
            _accessor = BaseAccessor.GetInstance();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult History()
        {
           
            return View( _accessor.GetTweets());
        }

        public ActionResult Delete(Guid id)
        {
            _accessor.RemoveTweet(id);
            return RedirectToAction("History");
        }

        [HttpPost]
        public ActionResult Twitter(TwitterRequest query)
        {
            if(query == null || string.IsNullOrEmpty(query.HashTag) || string.IsNullOrWhiteSpace(query.HashTag))
            {              
                return PartialView("_Tweets", new List<ITweet>());
            }
            
            var tweets = Tweetinvi.Search.SearchTweets(new TweetSearchParameters(query.HashTag)
            { 
                SearchQuery = query.HashTag                   
            }).Select(t=> new DAL.Tweet{
                CreatedAt = t.CreatedAt.ToString("s"),
                Text = t.Text,
                Author = t.CreatedBy.Name,
                QueryKey = query.HashTag
          
            });
            Task.Run(() => { _accessor.InsertTweets(tweets); });
           

            return PartialView("_Tweets",tweets);
        }

    }
}