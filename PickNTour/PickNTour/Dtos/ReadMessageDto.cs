using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using PickNTour.Areas.Identity.Data;

namespace PickNTour.Dtos
{
    public class ReadMessageDto
    {
        public int Id { get; set; }


        public string UserFromId { get; set; }
        public UserQueryDto UserFrom { get; set; }

        public DateTime DateSent { get; set; }

        public string Subject { get; set; }

        public string MessageBody { get; set; }
    }
}
