using DataAccess.CoreLayer;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
  public  interface ICreditCardDal : IEntityRepository<NCreditCard>
    {
    }
}
