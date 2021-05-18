using Movies_APIs.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_APIs.Entities
{
    public class GenresCopy
    {

        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        [FirstLetterUpperCase]
        public string Name { get; set; }

        [Range(10, 120)]
        public int Age { get; set; }

        [CreditCard]
        public string CreditCard { get; set; }


        [Url]
        public string Url { get; set; }


    }

    public class Genres1Copy : IValidatableObject
    {

        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        [FirstLetterUpperCase]
        public string Name { get; set; }

        [Range(10, 120)]
        public int Age { get; set; }

        [CreditCard]
        public string CreditCard { get; set; }


        [Url]
        public string Url { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(!string.IsNullOrEmpty(Name))
            {
                var first_Letter = Name[0].ToString();

                if(first_Letter!= first_Letter.ToUpper())
                {
                    yield return new ValidationResult("Fist Leter Should Upper", new string[] { nameof(Name) });
                }
            }
        }
    }
}
