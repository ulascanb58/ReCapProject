﻿using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using CoreLayer.DataAccess;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore.Internal;

namespace Business.Concrete
{
   public class RentalManager:IRentalService
   {
       private IRentalDAL _iRentalDal;

       public RentalManager(IRentalDAL iRentalDal)
       {
           _iRentalDal = iRentalDal;
       }
        public IResult Add(NRental rental)
        {

            var result = _iRentalDal.GetAll(r=>r.CarId==rental.CarId&& r.ReturnDate==null);
            if (result.Any())
            {
                return  new ErrorResult(Messages.RentalDateInvalid);
            }
            else
            {
                _iRentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);

            }
         
            
        }

        public IResult Delete(NRental rental)
        {
            _iRentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IResult Update(NRental rental)
        {
            _iRentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IDataResult<List<NRental>> GetAll()
        {
            return  new SuccessDataResult<List<NRental>>(_iRentalDal.GetAll());
        }

        public IDataResult<NRental> GetById(int rentalid)
        {
           return new SuccessDataResult<NRental>(_iRentalDal.Get(r=>r.Id==rentalid));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_iRentalDal.GetRentalDetails());
        }
    }
}
