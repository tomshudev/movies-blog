using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OurMoviesBlog.Models
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        [Required]
        public int PostID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string AuthorName { get; set; }
        [Required]
        public string Content { get; set; }
        public virtual Post Post { get; set; }
    }
}