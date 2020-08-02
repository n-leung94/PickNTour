using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickNTour.Dtos
{
    public class TourGuideStatsDto
    {
        public int unreadMessages { get; set; }
        public int upcomingTours { get; set; }
        public int completedTours { get; set; }
    }
}
