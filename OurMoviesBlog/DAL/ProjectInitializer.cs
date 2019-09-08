using OurMoviesBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OurMoviesBlog.DAL
{
    public class ProjectInitializer : System.Data.Entity.DropCreateDatabaseAlways<ProjectContext>

    {
        protected override void Seed(ProjectContext context)
        {

            var movies = new List<Movie>
            {
                new Movie
                {
                    MovieID=1,
                    Name="Titanic",
                    Genre=Genre.Drama,
                    ReleaseDate=new DateTime(1997, 11 , 1),
                    Producer="Twentieth Century Fox",
                    RunningTime=194,
                    Language=Models.Language.English,
                    Location=new Coordinate { Longtitude=50, Latitude=1 },
                    ImageName="titanic-the-movie.jpg",
                     TrailerPath="-iRajLSA8TA"
                },
                new Movie
                {
                    MovieID=2,
                    Name="Shrek",
                    Genre=Genre.Animated,
                    ReleaseDate=new DateTime(2001, 4, 22),
                    Producer="Universal",
                    RunningTime=90,
                    Rate=7.9,
                    Language=Models.Language.English,
                    ImageName="shrek.jpg",
                    Location=new Coordinate { Longtitude=-81.3, Latitude=28.55 },
                    TrailerPath="W37DlG1i61s"
                },
                new Movie
                {
                    MovieID=3,
                    Name="Toy Story",
                    Genre=Genre.Animated,
                    ReleaseDate=new DateTime(1995, 11, 19),
                    Producer="Pixar",
                    RunningTime=81,
                    ImageName="Toy_Story.jpg",
                    Language=Models.Language.English,
                    Location=new Coordinate { Longtitude=-81.35, Latitude=28.5 },
                    TrailerPath="KYz2wyBy3kc"
                },
                new Movie
                {
                    MovieID=4,
                    Name="Pretty Woman",
                    Genre=Genre.Drama,
                    ReleaseDate=new DateTime(1990, 3, 23),
                    Producer="Touchston Pictures",
                    RunningTime=119,
                    Language=Models.Language.English,
                    ImageName="Prettty-Woman.jpg",
                    Location=new Coordinate { Longtitude=-109.13, Latitude=36.17},
                    TrailerPath="Wzii8IuL8lk"
                },
                new Movie
                {
                    MovieID=5,
                    Name="The Hangover",
                    Genre=Genre.Comedy,
                    ReleaseDate=new DateTime(2009, 5, 30),
                    Producer="Warner Bros",
                    RunningTime=100,
                    Language=Models.Language.English,
                    ImageName="hangover.jpg",
                    Location=new Coordinate { Longtitude=-115.13, Latitude=36.17 },
                     TrailerPath="tcdUhdOlz9M"
                },
               new Movie
                {
                    MovieID=6,
                    Name="Se La Vi",
                    Genre=Genre.Drama,
                    ReleaseDate=DateTime.Now,
                    Producer="Quad Prosunction",
                    RunningTime=117,
                    ImageName="ce-la-vi.jpg",
                    Language=Models.Language.France,
                    Location=new Coordinate { Longtitude=5, Latitude=45 },
                     TrailerPath="WjV8m84FcOs"
                },
                new Movie
                {
                    MovieID=7,
                    Name="Fast and Furious",
                    Genre=Genre.Action,
                    ReleaseDate=new DateTime(2001, 6, 18),
                    Producer="Universal Pictures",
                    RunningTime=106,
                    Language=Models.Language.English,
                    ImageName="Fast_and_Furious.jpg",
                    Location=new Coordinate { Longtitude=-115.13, Latitude=42},
                    TrailerPath="2TAOizOnNPo"
                },
                 new Movie
                {
                    MovieID=8,
                    Name="2 fast 2 furious",
                    Genre=Genre.Drama,
                    ReleaseDate=new DateTime(2003, 6, 3),
                    Producer="Universal Pictures",
                    RunningTime=107,
                    ImageName="Two_fast_two_furious.jpg",
                    Language=Models.Language.English,
                    Location=new Coordinate { Longtitude=-108.13, Latitude=47 },
                    TrailerPath="F_VIM03DXWI"
                },
                new Movie
                {
                    MovieID=9,
                    Name="Inception",
                    Genre=Genre.ScienceFiction,
                    ReleaseDate=new DateTime(2010, 7, 8),
                    Producer="Warner Bros",
                    RunningTime=148,
                    ImageName="inception.png",
                    Language=Models.Language.English,
                    Location=new Coordinate { Longtitude=-75, Latitude=45 },
                    TrailerPath="YoHD9XEInc0"
                },
                new Movie
                {
                    MovieID=10,
                    Name="Solo a Star Wars Story",
                    Genre=Genre.Drama,
                    ReleaseDate=new DateTime(2018, 5, 10),
                    Producer="Walt Disney Pictures",
                    RunningTime=135,
                    ImageName="Solo_A_Star_Wars_Story_poster.jpg",
                    Language=Models.Language.English,
                    Location=new Coordinate { Longtitude=-120.13, Latitude=44 },
                    TrailerPath="jPEYpryMp2s"
                },
                new Movie
                {
                    MovieID=11,
                    Name="Veronica",
                    Genre=Genre.Horror,
                    ReleaseDate=new DateTime(2017, 8, 27),
                    Producer="Apachi Films",
                    ImageName="Veronica.jpg",
                    RunningTime=105,
                    Language=Models.Language.Spanish,
                    Location=new Coordinate { Longtitude=-2.5, Latitude=40 },
                    TrailerPath="lQW5I5tCy28"
                },
                new Movie
                {
                    MovieID=12,
                    Name="Annabelle",
                    Genre=Genre.Horror,
                    ReleaseDate=new DateTime(2014, 9, 29),
                    Producer="New Line Cinema",
                    RunningTime=99,
                    ImageName="220px-Annabelle_film_poster.jpg",
                    Language=Models.Language.English,
                    Location=new Coordinate { Longtitude=-109.13, Latitude=40 },
                    TrailerPath="paFgQNPGlsg"
                },
                new Movie
                {
                    MovieID=13,
                    Name="Schindler's list",
                    Genre=Genre.Historical,
                    ReleaseDate=new DateTime(1993, 11, 30),
                    Producer="Universal Pictures",
                    ImageName="SchindlersList.jpg",
                    RunningTime=195,
                    Language=Models.Language.English,
                    Location=new Coordinate { Longtitude=-119.135, Latitude=42 },
                    TrailerPath="gG22XNhtnoY"
                },
                new Movie
                {
                    MovieID=14,
                    Name="Good Bye Lenin!",
                    Genre=Genre.Historical,
                    ReleaseDate=new DateTime(2003, 2, 9),
                    Producer="X-Filme Creative Pool",
                    ImageName="215px-Good_Bye_Lenin.jpg",
                    RunningTime=121,
                    Language=Models.Language.German,
                    Location=new Coordinate { Longtitude=10, Latitude=50 },
                    TrailerPath="mIjSaHUKD5I"
                },
                new Movie
                {
                    MovieID=15,
                    Name="Bonjour Monsieur Shlomi",
                    Genre=Genre.Drama,
                    ReleaseDate=new DateTime(2003, 4, 3),
                    Producer="United King Films",
                    RunningTime=94,
                    ImageName="ShlomisStars.jpg",
                    Language=Models.Language.Hebrew,
                    Location=new Coordinate { Longtitude=34.840819, Latitude=32.161824 },
                    TrailerPath="uc7KNgH0gf4"
                }
            };

            movies.ForEach(h => context.Movies.Add(h));
            context.SaveChanges();

            var posts = new List<Post>
            {
                new Post {
                    PostID = 1,
                    Title = "Why did they have to kill Leonardo",
                    AuthorName = "Sagie Ivan",
                    Date=new DateTime(2018, 9, 10),
                    Content="I believe We all would have preferred Jack Dawson to live, even if it was Rose's death",
                    Category = Category.Celebs,
                    ImgPath="kate_winslet_jack_titanic_.jpg",
                    MovieId=movies[0].MovieID
                },
                new Post  {
                    PostID = 2,
                    Title = "More frightening than hell",
                    AuthorName="Niv Hindi",
                    Date=new DateTime(2018,5,2),
                    Content="As a person who loves horror movies, I admit it too, Annabelle has crossed every boundary - the most terrifying movie I have ever seen!",
                    Category = Category.Reviews,
                    MovieId =movies[11].MovieID
                },
                new Post  {
                    PostID = 3,
                    Title = "When part B is better then part A",
                    AuthorName="Tom Shushan",
                    Date=new DateTime(2018,9,30),
                    Content="Even though the first 'fast and furious' was an excellent film, I must admit that the sequel was even better",
                    Category = Category.NewMovies,
                    ImgPath="fast-furious6.jpg",
                    MovieId =movies[7].MovieID
                },
                new Post  {
                    PostID = 4,
                    Title = "When comedy and horror connect",
                    AuthorName="Guest author",
                    Date=new DateTime(2018,8,26),
                    Content="A great movie with great actors - I've never been so nervous from a comedy movie",
                    Category = Category.NewsFlash,
                    MovieId =movies[5].MovieID
                },
                new Post  {
                    PostID = 5,
                    Title = "Best movie i have ever seen",
                    AuthorName="Sagie Ivan",
                    Date=new DateTime(2018,8,21),
                    Content="'Shrek' is by far the best movie ever made - I wish I could trade with Fiona",
                    Category = Category.Reviews,
                    MovieId =movies[1].MovieID
                },
                new Post  {
                    PostID = 6,
                    Title = "See it All the time",
                    AuthorName="Guest",
                    Date=new DateTime(2018,8,21),
                    Content="I like this movie!!",
                    Category = Category.Reviews,
                    MovieId =movies[2].MovieID
                },

                new Post
                {
                    PostID = 7,
                    Title = "All about Inception",
                    AuthorName = "Niv Hindi",
                    Date=new DateTime(2018,7,18),
                    Content = "The film opened last weekend at $62.8 million and could reach $140 million at the box office by the end of this weekend.",
                    Category = Category.BehindTheScene,
                    MovieId=movies[2].MovieID,
                    ImgPath="avengers.jpg"
                },

                new Post
                {
                    PostID = 8,
                    Title = "Brad Pitt",
                    AuthorName = "Sagie Ivan",
                    Date=new DateTime(2018,10,3),
                    Content = "When I ask Pitt what gives him the most comfort these days, he says, “I get up every morning and I make a fire. When I go to bed, I make a fire, just because—it makes me feel life. I just feel life in this house.”",
                    Category = Category.Celebs,
                    ImgPath="brad-pitt.jpg"
                }
            };

            posts.ForEach(p => context.Posts.Add(p));
            context.SaveChanges();

            var comments = new List<Comment>
            {
                new Comment
                {
                    CommentID=1,
                    PostID=1,
                    Title="True and accurate!",
                    AuthorName="user123",
                    Content="Agree with every word",
                },
                new Comment
                {
                    CommentID=2,
                    PostID=2,
                    Title="I couldnt Agree more",
                    AuthorName="anonymus",
                    Content="Rose is the wrost",
                },
                new Comment
                {
                    CommentID=3,
                    PostID=3,
                    Title="Nonsense",
                    AuthorName="BestGuy94",
                    Content="This movie is not scarry at all",
                },
                new Comment
                {
                    CommentID=4,
                    PostID=5,
                    Title="Shahar you are the queen!",
                    AuthorName="beast%^&",
                    Content="Agree with every word you write! I choose movies only according to your reviews!",
                },
            };
            comments.ForEach(c => context.Comments.Add(c));
            context.SaveChanges();

            var users = new List<User>
            {
                new User
                {
                    UserName="Sagie Ivan",
                    Password="Shahar1234"
                },
                new User
                {
                    UserName="Tom Shushan",
                    Password="Nn123456"
                },
                new User
                {
                    UserName="Niv Hindi",
                    Password="2wsx@WSX"
                }
            };

            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();


            var maps = new List<Map>();

            for (int i = 0; i < movies.ToArray().Length; i++)
            {
                Map map = new Map
                {
                    MapID = movies[i].MovieID,
                    Name = movies[i].Name,
                    Location = movies[i].Location
                };

                maps.Add(map);
            }
            maps.ForEach(m => context.Maps.Add(m));
            context.SaveChanges();
        }
    }
}