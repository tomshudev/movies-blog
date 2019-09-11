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
        private const string TWITTER_CONSUMER_SECRET = "rQj57YltiOWNuEdR2gXjPyeIoyd4cbBK06YroUme3U1ZJqXxzN";
        private const string TWITTER_ACCESS_TOKEN = "1058689648057311232-oKh4R0EUN2KGQFLjYocmUIhZTf7Rd4";
        private const string TWITTER_ACCESS_TOKEN_SECRET = "PQ0YSBhJw8yBggJXQURHsSdiuRswQiZLMxxk6q1XT4Kld";

        public void Configuration(IAppBuilder app)
        {
            Auth.SetUserCredentials(TWITTER_CONSUMER_ID,
                                    TWITTER_CONSUMER_SECRET,
                                    TWITTER_ACCESS_TOKEN,
                                    TWITTER_ACCESS_TOKEN_SECRET);
        }
    }
}