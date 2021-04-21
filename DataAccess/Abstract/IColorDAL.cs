using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.CoreLayer;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IColorDAL:IEntityRepository<NColor>
    {
    }
}
