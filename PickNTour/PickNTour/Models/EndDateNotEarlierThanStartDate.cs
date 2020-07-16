using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PickNTour.Models
{
    public class EndDateNotEarlierThanStartDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var tour = (Tour)validationContext.ObjectInstance;

            // If the Start Time and End Time is the same, reject.
            if (DateTime.Compare(tour.StartDate, tour.EndDate) == 0)
                return new ValidationResult("The Tour Start Time and End Time cannot be the same.");

            // If the End Time is earlier than the Start Time, reject.
            if (DateTime.Compare(tour.StartDate, tour.EndDate) > 0)
                return new ValidationResult("The Tour End Time cannot be earlier than the Start Time.");

            return (DateTime.Compare(tour.StartDate, tour.EndDate) < 0)
                ? ValidationResult.Success
                : new ValidationResult("The Tour End Time cannot be earlier than the Start Time.");



        }
    }
}
