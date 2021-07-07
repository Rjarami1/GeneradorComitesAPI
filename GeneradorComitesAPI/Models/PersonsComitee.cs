using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneradorComitesAPI.Models
{
    public class PersonsComitee
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int ComiteeId { get; set; }
        public Comitee Comitee { get; set; }
    }
}
