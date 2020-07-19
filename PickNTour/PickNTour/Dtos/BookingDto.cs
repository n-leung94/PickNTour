using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickNTour.Dtos
{
    public class BookingDto
    {
        public int Id { get; set; }

        public int TourId { get; set; }
        public PublicTourDto Tour {get; set;}


        public DateTime DateBooked { get; set; }
    }
}
