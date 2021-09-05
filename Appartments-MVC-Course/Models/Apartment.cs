using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.ComponentModel.DataAnnotations;

namespace Appartments_MVC_Course.Models
{
    public class Apartment
    {
        
        public int Id { get; set; }
        [Required]
        public string OwnerId { get; set; }
        [Required]
        [StringLength(255)]
        public string City { get; set; }
        [Required]
        [StringLength(255)]
        public string Street { get; set; }
        [Required]
        [Range(1,int.MaxValue)]
        public int AparatmentNumber { get; set; }
        public string Description { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int PriceInILS { get; set; }
        [Url]
        public string ImageUrl { get; set; }

        public Apartment() {}

        public Apartment(int id, string ownerId, string city,string street, int aparatmentNumber, string description, int priceInIls,
            string imageUrl)
        {
            this.Id = id;
            this.OwnerId = ownerId;
            this.City = city;
            this.Street = street;
            this.AparatmentNumber = aparatmentNumber;
            this.Description = description;
            this.PriceInILS = priceInIls;
            this.ImageUrl = imageUrl;
        }
    }
}