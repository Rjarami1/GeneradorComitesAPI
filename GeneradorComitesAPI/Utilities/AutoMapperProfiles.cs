using AutoMapper;
using GeneradorComitesAPI.DTOs;
using GeneradorComitesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneradorComitesAPI.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<PersonCreationDTO, Person>();
        }
    }
}
