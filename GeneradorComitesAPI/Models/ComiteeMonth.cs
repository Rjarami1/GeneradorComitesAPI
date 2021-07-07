using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GeneradorComitesAPI.Models
{
    public class ComiteeMonth
    {
        public int Id { get; set; }
        public int ComiteeId { get; set; }
        public Comitee Comitee { get; set; }

        [Required]
        public int Month { get; set; }
    }
}
