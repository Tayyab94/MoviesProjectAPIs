using Movies_APIs.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_APIs.DTOs
{
    public class GenresCreationDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        [FirstLetterUpperCase]
        public string Name { get; set; }
    }
}
