using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Appartments_MVC_Course.Dtos;
using Appartments_MVC_Course.Models;
using AutoMapper;

namespace Appartments_MVC_Course.Controllers.Api
{
    [EnableCors(origins:"*",headers:"*",methods:"*")]
    public class ApartmentsController : ApiController
    {
        private ApplicationDbContext _context;

        public ApartmentsController()
        {
            _context = new ApplicationDbContext();
        }

        // Get /api/aparments
        [HttpGet]
        public IHttpActionResult GetApartments()
        {
            var apartmentsDtos = _context.Apartments
                .ToList()
                .Select(Mapper.Map<Apartment, ApartmentDtos>);

            return Ok(apartmentsDtos);
        }

        // Get /api/aparments/:id
        [HttpGet]
        public IHttpActionResult GetApartment(int id)
        {
            var apartment = _context.Apartments.SingleOrDefault(apt => apt.Id == id);

            if (apartment == null)
            {
                return NotFound();
            }

            var apartmentDto = Mapper.Map<Apartment, ApartmentDtos>(apartment);

            return Ok(apartmentDto);
        }

        // Post /api/apartments
        [HttpPost]
        public IHttpActionResult PostApartment(ApartmentDtos apartmentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var apartment = Mapper.Map<ApartmentDtos, Apartment>(apartmentDto);
            apartment.OwnerId = "David the king";

            _context.Apartments.Add(apartment);
            _context.SaveChanges();

            apartmentDto.Id = apartment.Id;
            return Created(new Uri(Request.RequestUri+"/"+apartmentDto.Id),apartmentDto);
        }

        // Put /api/apartments/:id
        [HttpPut]
        public IHttpActionResult PutApartment(int id,ApartmentDtos apartmentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var aparmentInDb = _context.Apartments.SingleOrDefault(apt => apt.Id == id);

            if (aparmentInDb == null)
            {
                return NotFound();
            }

            // updates the object 
            Mapper.Map(apartmentDto, aparmentInDb);
            _context.SaveChanges();
            return Ok(apartmentDto);
        }

        // Delete /api/apartments/:id
        [HttpDelete]
        public IHttpActionResult DeleteApartment(int id)
        {
            var aparmentInDb = _context.Apartments.SingleOrDefault(apt => apt.Id == id);

            if (aparmentInDb == null)
            {
                return NotFound();
            }

            _context.Apartments.Remove(aparmentInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
