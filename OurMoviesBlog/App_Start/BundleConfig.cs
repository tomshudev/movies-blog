using System.Web;
using System.Web.Optimization;

namespace OurMoviesBlog
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/d3").Include(
                        "~/Scripts/d3.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/pie").Include(
            "~/Scripts/PieChart.js"));

            bundles.Add(new ScriptBundle("~/bundles/stats").Include(
            "~/Scripts/GroupByMovie.js"));

            bundles.Add(new ScriptBundle("~/bundles/login").Include(
            "~/Scripts/Login.js"));

            bundles.Add(new ScriptBundle("~/bundles/tweet").Include(
            "~/Scripts/Tweet.js"));

            bundles.Add(new ScriptBundle("~/bundles/home").Include(
            "~/Scripts/Home.js"));

            bundles.Add(new ScriptBundle("~/bundles/postDetails").Include(
            "~/Scripts/PostDetails.js"));

            bundles.Add(new ScriptBundle("~/bundles/moviesRating").Include(
            "~/Scripts/MoviesRatingScript.js"));

            bundles.Add(new ScriptBundle("~/bundles/CommentsScript").Include(
                "~/Scripts/CommentsScript.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Site.css",
                      "~/Styles/view_comment.css"));
        }
    }
}
