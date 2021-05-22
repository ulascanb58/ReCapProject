using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using DataAccess.CoreLayer;


namespace Entities.Concrete
{
   public class NBrand:IEntity
    {
        [Key]
        public int brandId { get; set; }
        public string BrandName { get; set; }
    }
}
