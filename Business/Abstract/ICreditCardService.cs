using CoreLayer.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        IDataResult<NCreditCard> GetById(int id);
        IDataResult<List<NCreditCard>> GetAll();
        IDataResult<List<NCreditCard>> GetAllByCustomerId(int customerId);

        IResult Add(NCreditCard creditCard);

        IResult Delete(NCreditCard creditCard);
    }
}

