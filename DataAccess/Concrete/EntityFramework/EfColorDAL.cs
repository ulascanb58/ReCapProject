using System;
using System.Collections.Generic;
using System.Text;
using CoreLayer.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDAL:EfEntityRepositoryBase<NColor,ProjectDBContext>,IColorDAL
    {
    }
}
