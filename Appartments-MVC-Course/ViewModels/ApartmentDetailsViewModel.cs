using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Appartments_MVC_Course.Dtos;

namespace Appartments_MVC_Course.ViewModels
{
    public class ApartmentDetailsViewModel
    {
        public ApartmentDtos Apartment { get; set; }
        public string OwnerName { get; set; }
        public bool CanEditApartment { get; set; }
    }
}