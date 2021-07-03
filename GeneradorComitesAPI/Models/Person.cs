using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GeneradorComitesAPI.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 150)]
        public string Name { get; set; }

        [Required]
        public int BirthdayMonth { get; set; }

        [Required]
        public int BirthdayDay { get; set; }

        public int? LastComiteeId { get; set; }

        public Comitee LastComitee { get; set; }
    }
}
