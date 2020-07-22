using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


// View Model for messaging tour group
namespace PickNTour.ViewModels
{
    public class MessageTGViewModel
    {
        public int TourId { get; set; }

        public string TourName { get; set; }

        public List<string> Participants { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        [Display(Name = "Message")]
        [DataType(DataType.MultilineText)]
        public string MessageBody { get; set; }
    }
}
