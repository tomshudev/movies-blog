using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OurMoviesBlog.Models
{
    public class User
    {

        [Key]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}