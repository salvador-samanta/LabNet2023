using AutoMapper;
using Lab.Demo.Entities;
using Lab.EF.Entities;
using Lab.EF.Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic.Mapper
{
    public class ShippersMapper : Profile
    {
        public ShippersMapper()
        {
            CreateMap<Shippers, ShippersDto>().ReverseMap();
        }
    }
}
