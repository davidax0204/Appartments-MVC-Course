using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Appartments_MVC_Course.Dtos
{
    public class ApartmentDtos
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int AparatmentNumber { get; set; }
        public string Description { get; set; }
        public int PriceInILS { get; set; }
        public string ImageUrl { get; set; }
    }
}