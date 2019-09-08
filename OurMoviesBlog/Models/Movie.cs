using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OurMoviesBlog.Models
{
    public enum Genre
    {
        Comedy, Action, Animated, Horror, ScienceFiction, Drama, Historical
    }

    public enum Language
    {
        English, France, Spanish, Hebrew, German
    }

    public class Movie
    {
        [Key]
        public int MovieID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Genre Genre { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public String Producer { get; set; }
        [Required]
        public int RunningTime { get; set; }
        public double Rate { get; set; }
        public Language Language { get; set; }
        public string ImageName { get; set; }
        public Coordinate Location { get; set; }
        public string TrailerPath { get; set; }
    }
}