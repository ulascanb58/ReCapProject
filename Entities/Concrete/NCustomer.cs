using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using DataAccess.CoreLayer;

namespace Entities.Concrete
{
    public class NCustomer :IEntity
    {
        [Key]
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
    }
}
