﻿using System;
using System.Collections.Generic;
using System.Text;
using CoreLayer.Entities;

namespace Entities.DTOs
{
   public class CarDetailDto:IDto
    {
        public int CarId { get; set; }
        public string CarDescription { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        
    }
}
