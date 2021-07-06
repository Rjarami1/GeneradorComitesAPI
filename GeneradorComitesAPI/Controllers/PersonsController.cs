using GeneradorComitesAPI.Models;
using GeneradorComitesAPI.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneradorComitesAPI.Controllers
{
    [ApiController]
    [Route("api/persons")]
    public class PersonsController : Controller
    {
        private readonly ApplicationDbContext context;

        public PersonsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> Get()
        {
            var persons = await context.Persons.ToListAsync();

            return persons;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Person person)
        {
            if(Enum.GetName(typeof(BirthdayDates.Months), person.BirthdayMonth) == null)
            {
                return BadRequest("Specified month is not valid. Valid months range from 0 to 11");
            }

            if(BirthdayDates.MonthMaxDays[person.BirthdayMonth] < person.BirthdayDay)
            {
                return BadRequest($"The birthday day number '{person.BirthdayDay}' " +
                    $"is not valid for the month of {Enum.GetName(typeof(BirthdayDates.Months), person.BirthdayMonth)}");
            }

            context.Add(person);

            await context.SaveChangesAsync();

            return Created(new Uri("/api/persons", UriKind.Relative), person);
        }

    }
}
