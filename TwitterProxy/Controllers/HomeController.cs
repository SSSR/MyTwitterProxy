using BLToolkit.DataAccess;
using DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
            _accessor = DataAccessor.CreateInstance<BaseAccessor>();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult History()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Twitter(TwitterRequest query)
        {
            if(query == null || string.IsNullOrEmpty(query.HashTag))
            {
                ModelState.AddModelError("query key is required!", new ArgumentException());
                return PartialView("_Tweets", new List<ITweet>());
            }
            
            var tweets = Tweetinvi.Search.SearchTweets(new TweetSearchParameters(query.HashTag)
            { 
                SearchQuery = query.HashTag,
                MaximumNumberOfResults = query.Limit,                
            });

            return PartialView("_Tweets",tweets);
        }

    }
}