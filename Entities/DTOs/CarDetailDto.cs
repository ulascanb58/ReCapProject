using System;
using System.Collections.Generic;
using System.Text;
using CoreLayer.Entities;
using Entities.Concrete;

namespace Entities.DTOs
{
   public class CarDetailDto:IDto
    {
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public string Description { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public decimal Price { get; set; }
        public int ModelYear { get; set; }

        public List<string> ImagePath { get; set; }
        public List<NCarImage> CarImage { get; set; }

    }
}
