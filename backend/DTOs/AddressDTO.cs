using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.DTOs
{
    public class AddressDTO : BaseDTO<Address>
    {
        public string Street { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Zipcode { get; set; } = null!;
        public string Country { get; set; } = null!;

        public override void UpdateModel(Address model)
        {
            model.Street = Street;
            model.City = City;
            model.Zipcode = Zipcode;
            model.Country = Country;
        }
    }
}