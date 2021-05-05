using DataAccess.CoreLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLayer.Entities.Concrete
{
    public class NOperationClaim : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
