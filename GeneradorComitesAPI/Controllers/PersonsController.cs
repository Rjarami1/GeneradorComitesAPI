using AutoMapper;
using GeneradorComitesAPI.DTOs;
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
        private readonly IMapper mapper;

        public PersonsController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> Get()
        {
            var persons = await context.Persons.ToListAsync();

            return persons;
        }

        [HttpPost]
        public async Task<ActionResult> Post(PersonCreationDTO personCreation)
        {
            if(Enum.GetName(typeof(BirthdayDates.Months), personCreation.BirthdayMonth) == null)
            {
                return BadRequest("Specified month is not valid. Valid months range from 0 to 11");
            }

            if(BirthdayDates.MonthMaxDays[personCreation.BirthdayMonth] < personCreation.BirthdayDay)
            {
                return BadRequest($"The birthday day number '{personCreation.BirthdayDay}' " +
                    $"is not valid for the month of {Enum.GetName(typeof(BirthdayDates.Months), personCreation.BirthdayMonth)}");
            }

            var person = mapper.Map<Person>(personCreation);

            context.Add(person);

            await context.SaveChangesAsync();

            return Created(new Uri("/api/persons", UriKind.Relative), person);
        }

    }
}
