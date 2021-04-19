using System;
using System.Collections.Generic;
using System.Text;
using Entities.Abstract;

namespace Entities.Concrete
{
   public class NBrand:IEntity
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
    }
}
