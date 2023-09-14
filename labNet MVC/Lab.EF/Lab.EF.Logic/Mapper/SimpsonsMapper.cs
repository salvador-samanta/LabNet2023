using Lab.EF.Entities;
using Lab.EF.Logic.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic.Mapper
{
    public class SimpsonsMapper : Profile
    {
        public SimpsonsMapper() 
        {
            CreateMap<Simpson, SimpsonsDto>().ReverseMap();
        }
    }
}
