using System;
using System.Collections.Generic;
using System.Text;
using CoreLayer.DataAccess;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfBrandDAL:EfEntityRepositoryBase<NBrand,ProjectDBContext>,IBrandDAL
    {

    }
}
