using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickNTour.Dtos
{
    public class UserStatsDto
    {
        public int unreadMessages { get; set; }
        public int upcomingBookings { get; set; }
        public int completedBookings { get; set; }

    }
}
