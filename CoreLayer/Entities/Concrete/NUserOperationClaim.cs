using DataAccess.CoreLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLayer.Entities.Concrete
{
   public class NUserOperationClaim : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
