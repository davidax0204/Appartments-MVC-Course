using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Appartments_MVC_Course.Dtos
{
    public class ApartmentDtos
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You must enter a city name")]
        [StringLength(255)]
        public string City { get; set; }
        [Required]
        [StringLength(255)]
        public string Street { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int AparatmentNumber { get; set; }
        public string Description { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int PriceInILS { get; set; }
        [Url(ErrorMessage = "You must enter a valid url")]
        public string ImageUrl { get; set; }
    }
}