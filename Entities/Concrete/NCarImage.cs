using DataAccess.CoreLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class NCarImage : IEntity
    {
        [Key]
        public int ImageId { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }

        
    }
}
