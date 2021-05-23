using System;
using System.Collections.Generic;
using System.Text;
using CoreLayer.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
   public interface IRentalService
    {
        IResult Add(NRental rental);
        IResult Delete(NRental rental);
        IResult Update(NRental rental);
        IDataResult<List<NRental>> GetAll();
        IDataResult<NRental> GetById(int rentalid);
        IDataResult<List<RentalDetailDto>> GetRentalDetails();

        IResult isCarAvailable(NRental rental);
    }
}
