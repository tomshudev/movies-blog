using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Mvc;
using Tweetinvi;

namespace OurMoviesBlog.Controllers
{
    public class TwitterController : Controller
    {
        private const string TWITTER_CONSUMER_ID = "97segLtHcO97zISHMh6VPNKOQ";
        private const string TWITTER_CONSUMER_SECRET = "rQj57YltiOWNuEdR2gXjPyeIoyd4cbBK06YroUme3U1ZJqXxzN";
        private const string TWITTER_ACCESS_TOKEN = "1058689648057311232-oKh4R0EUN2KGQFLjYocmUIhZTf7Rd4";
        private const string TWITTER_ACCESS_TOKEN_SECRET = "PQ0YSBhJw8yBggJXQURHsSdiuRswQiZLMxxk6q1XT4Kld";

        // GET: Twitter/Tweet
        [Authorize(Users = "Admin")]
        public ActionResult TweetPage()
        {
            return View("~/Views/Admin/Tweet.cshtml");
        }

        // POST Twitter/Tweet
        [HttpPost]
        [Authorize(Users = "Admin")]
        public ActionResult TweetUpdate(string text)
        {
            try
            {
                Auth.SetUserCredentials(TWITTER_CONSUMER_ID,
                                    TWITTER_CONSUMER_SECRET,
                                    TWITTER_ACCESS_TOKEN,
                                    TWITTER_ACCESS_TOKEN_SECRET);

                var tweetToBe = Tweet.PublishTweet(text);

                if (tweetToBe.IsTweetPublished)
                {
                    return Json(new Dictionary<string, object> { { "url", tweetToBe.Url } });
                }


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(Tweetinvi.ExceptionHandler.GetLastException().TwitterDescription);
                Console.WriteLine(Tweetinvi.ExceptionHandler.GetLastException().TwitterDescription);
                return new HttpStatusCodeResult(500, Tweetinvi.ExceptionHandler.GetLastException().TwitterDescription);
            }
            return new HttpStatusCodeResult(500);
        }
    }
 }