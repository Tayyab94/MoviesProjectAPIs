using Movies_APIs.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_APIs.Validations
{
    public class FirstLetterUpperCaseAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
           //var obj= (Genres)validationContext.ObjectInstance;  // By using this ValidationContext we can access the Whole Obj
           

            if(value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            var firstLetter = value.ToString()[0].ToString();

            if(firstLetter != firstLetter.ToUpper())
            {
                return new ValidationResult("First Letter Should be Upper Case");
            }


            return ValidationResult.Success;
        }
    }
}
