using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Tweetinvi;

[assembly: OwinStartup(typeof(OurMoviesBlog.Startup))]

namespace OurMoviesBlog
{
    public class Startup
    {
        private const string TWITTER_CONSUMER_ID = "g4vIIbPIL9f4d7JKQMlcMgr1c";
        private const string TWITTER_CONSUMER_SECRET = "9QNHRjCMWFBFmluClgIkcZhoQi8ytSnC6oaac8xIzOYSxKE4dZ";
        private const string TWITTER_ACCESS_TOKEN = "1171060325774499840-HuWChy7EvZ3CiAbovggmbl3ZH4dJir";
        private const string TWITTER_ACCESS_TOKEN_SECRET = "7Odwfcdmy7bKJuTMN3EOmnneOhevDEQHvUb6OsMKlgb14";

        public void Configuration(IAppBuilder app)
        {
            Auth.SetUserCredentials(TWITTER_CONSUMER_ID,
                                    TWITTER_CONSUMER_SECRET,
                                    TWITTER_ACCESS_TOKEN,
                                    TWITTER_ACCESS_TOKEN_SECRET);
        }
    }
}