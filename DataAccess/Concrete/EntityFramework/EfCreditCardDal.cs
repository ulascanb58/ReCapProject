﻿using CoreLayer.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfCreditCardDal : EfEntityRepositoryBase<NCreditCard, ProjectDBContext>, ICreditCardDal
    {
    }
}
