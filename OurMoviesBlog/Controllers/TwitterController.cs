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
        private const string TWITTER_CONSUMER_ID = "g4vIIbPIL9f4d7JKQMlcMgr1c";
        private const string TWITTER_CONSUMER_SECRET = "9QNHRjCMWFBFmluClgIkcZhoQi8ytSnC6oaac8xIzOYSxKE4dZ";
        private const string TWITTER_ACCESS_TOKEN = "1171060325774499840-HuWChy7EvZ3CiAbovggmbl3ZH4dJir";
        private const string TWITTER_ACCESS_TOKEN_SECRET = "7Odwfcdmy7bKJuTMN3EOmnneOhevDEQHvUb6OsMKlgb14";

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