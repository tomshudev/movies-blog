using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OurMoviesBlog.Models
{
    public enum Category
    {
        NewMovies, Celebs, Reviews, BehindTheScene, NewsFlash
    }

    public class Post
    {
        [Key]
        public int PostID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string AuthorName { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime Date { get; set; }
        public int? MovieId { get; set; }
        public Category Category { get; set; }
        public string Content { get; set; }
        public string ImgPath { get; set; }


        public virtual Movie Movie { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }

    public class SelectByMovie
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public int PostsAmount { get; set; }
    }

    public class SelectByCategory
    {
        public string CategoryName { get; set; }
        public int PostsAmount { get; set; }
    }

}
