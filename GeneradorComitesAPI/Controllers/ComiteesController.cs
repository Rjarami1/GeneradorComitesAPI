using GeneradorComitesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneradorComitesAPI.Controllers
{
    [ApiController]
    [Route("api/comitees")]
    public class ComiteesController : Controller
    {
        private readonly ApplicationDbContext context;

        public ComiteesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Comitee>>> Get()
        {
            var comitees = await context.Comitees.ToListAsync();

            return comitees;
        }

        [HttpGet("{active:bool}")]
        public async Task<ActionResult<List<Comitee>>> Get(bool active)
        {
            var comitees = await context.Comitees.Where(c => c.Active == active).ToListAsync();
                         
            return comitees;
        }

        [HttpGet("generate")]
        public async Task<ActionResult<List<Comitee>>> Generate()
        {
            var currentComitees = await context.Comitees.Where(c => c.Active).ToListAsync();

            if(currentComitees.Count > 0)
            {
                foreach(var c in currentComitees)
                {
                    c.Active = false;
                    context.Update(c);
                }
                await context.SaveChangesAsync();
            }
        
            for(int i = 0; i < 12; i += 2)
            {
                var comitee = new Comitee()
                {
                    Active = true
                };

                context.Add(comitee);
                await context.SaveChangesAsync();

                var comiteeMonth1 = new ComiteeMonth()
                {
                    ComiteeId = comitee.Id,
                    Month = i
                };
                var comiteeMonth2 = new ComiteeMonth()
                {
                    ComiteeId = comitee.Id,
                    Month = i + 1
                };

                context.Add(comiteeMonth1);
                context.Add(comiteeMonth2);
                await context.SaveChangesAsync();
            }

            var persons = await context.Persons.ToListAsync();
            var comitees = await context.Comitees.Where(c => c.Active).ToListAsync();

            foreach(var p in persons)
            {
                foreach(var c in comitees)
                {
                    if(p.LastComiteeId != c.Id)
                    {
                        var months = await context.ComiteeMonths.Where(cm => cm.ComiteeId == c.Id).Select(cm => cm.Month).ToListAsync();

                        if (!months.Contains(p.BirthdayMonth))
                        {
                            var personComitee = new PersonsComitee()
                            {
                                PersonId = p.Id,
                                ComiteeId = c.Id
                            };
                            p.LastComiteeId = c.Id;

                            context.Add(personComitee);
                            context.Update(p);
                            break;
                        }
                    }
                }
            }
            await context.SaveChangesAsync();

            return comitees;
        }
    }
}
