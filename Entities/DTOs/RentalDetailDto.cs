using System;
using System.Collections.Generic;
using System.Text;
using CoreLayer.Entities;

namespace Entities.DTOs
{
    public class RentalDetailDto :IDto
    {

        public string CarName { get; set; }
        public string CompanyName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
