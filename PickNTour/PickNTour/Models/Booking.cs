using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PickNTour.Areas.Identity.Data;

namespace PickNTour.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public int TourId { get; set; }
        public Tour Tour { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public DateTime DateBooked { get; set; }
    }
}
