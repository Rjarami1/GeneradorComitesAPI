using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GeneradorComitesAPI.DTOs
{
    public class PersonCreationDTO
    {
        [Required]
        [StringLength(maximumLength: 150)]
        public string Name { get; set; }

        [Required]
        public int BirthdayMonth { get; set; }

        [Required]
        public int BirthdayDay { get; set; }
    }
}
