using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_APIs.Entities
{
    public class MoviesTheather
    {

        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength:75)]
        public string Name { get; set; }

        public Point Location { get; set; } 
    }
}
