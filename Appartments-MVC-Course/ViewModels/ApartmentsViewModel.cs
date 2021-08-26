using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Appartments_MVC_Course.Dtos;
using Appartments_MVC_Course.Models;

namespace Appartments_MVC_Course.ViewModels
{
    public class ApartmentsViewModel
    {
        //public List<Apartment> Apartments;
        public List<ApartmentDtos> Apartments { get; set; }
    }
}