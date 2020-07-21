using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using PickNTour.Areas.Identity.Data;

namespace PickNTour.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required]
        public string UserToId { get; set; }
        public ApplicationUser UserTo { get; set; }


        [Required]
        public string UserFromId { get; set; }
        public ApplicationUser UserFrom { get; set; }


        public DateTime DateSent { get; set; }
        public DateTime? DateRead { get; set; }


        public string Subject { get; set; }


        [DataType(DataType.MultilineText)]
        public string MessageBody { get; set; }
    }
}
