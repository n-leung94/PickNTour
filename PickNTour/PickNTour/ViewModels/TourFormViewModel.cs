using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using PickNTour.Models;
using PickNTour.Areas.Identity.Data;

namespace PickNTour.ViewModels
{
    public class TourFormViewModel
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Tour Name")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [Required]
        [StringLength(255)]
        public string Country { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Start Location")]
        public string StartLocation { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "End Location")]
        public string EndLocation { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [EndDateNotEarlierThanStartDate]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public double Price { get; set; }

        [Required]
        [Display(Name = "Tour Capacity")]
        [Range(1, 100)]
        public int TourCapacity { get; set; }

        public int TourAvailability { get; set; }


        public TourFormViewModel()
        {
            Id = 0;
        }

        public TourFormViewModel(Tour tour)
        {
            Id = tour.Id;
            Name = tour.Name;
            Description = tour.Description;
            UserId = tour.UserId;
            User = tour.User;
            Country = Country;
            StartLocation = tour.StartLocation;
            EndLocation = tour.EndLocation;
            StartDate = tour.StartDate;
            EndDate = tour.EndDate;
            Price = tour.Price;
            TourCapacity = tour.TourCapacity;
            TourAvailability = tour.TourAvailability;
        }
    }
}
