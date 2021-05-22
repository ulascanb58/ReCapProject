using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using DataAccess.CoreLayer;


namespace Entities.Concrete
{
    public class NColor:IEntity
    {
        [Key]
        public int colorId { get; set; }
        public string ColorName { get; set; }
    }
}
