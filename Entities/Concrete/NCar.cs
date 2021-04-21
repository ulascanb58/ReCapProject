using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.CoreLayer;

namespace Entities.Concrete
{
   public class NCar:IEntity
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
    }
}
