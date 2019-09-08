using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OurMoviesBlog.Models
{
    public class Map
    {
        public int MapID { get; set; }

        public string Name { get; set; }

        public Coordinate Location
        {
            get; set;
        }
    }
}

public class Coordinate
{
    public double Longtitude { get; set; }

    public double Latitude { get; set; }
}
