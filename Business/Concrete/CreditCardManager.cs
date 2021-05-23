using Business.Abstract;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        public IResult Add(NCreditCard creditCard)
        {
            _creditCardDal.Add(creditCard);
            return new SuccessResult("Messages.creditCardAdded");
        }


        public IResult Delete(NCreditCard creditCard)
        {
            _creditCardDal.Delete(creditCard);
            return new SuccessResult("Messages.creditCardDeleted");
        }

        public IDataResult<List<NCreditCard>> GetAll()
        {
            return new SuccessDataResult<List<NCreditCard>>(_creditCardDal.GetAll());
        }

        public IDataResult<List<NCreditCard>> GetAllByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<NCreditCard>>(_creditCardDal.GetAll(c => c.CustomerId == customerId));
        }


        public IDataResult<NCreditCard> GetById(int id)
        {
            return new SuccessDataResult<NCreditCard>(_creditCardDal.Get(c => c.Id == id));
        }
    }
}
