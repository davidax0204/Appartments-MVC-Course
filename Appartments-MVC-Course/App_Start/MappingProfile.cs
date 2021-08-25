using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Appartments_MVC_Course.Models;
using Appartments_MVC_Course.Dtos;

namespace Appartments_MVC_Course.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Apartment, ApartmentDtos>();
            Mapper.CreateMap<ApartmentDtos, Apartment>();
        }
    }
}