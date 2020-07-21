using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PickNTour.ViewModels
{
    public class SendMessageFormViewModel
    {
        [Required]
        [Display(Name = "Recipient Username")]
        public string UserName { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string MessageBody { get; set; }
    }
}
