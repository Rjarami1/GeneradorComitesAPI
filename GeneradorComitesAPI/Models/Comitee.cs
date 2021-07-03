using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GeneradorComitesAPI.Models
{
    public class Comitee
    {
        public int Id { get; set; }

        [Required]
        public bool Active { get; set; }
    }
}
