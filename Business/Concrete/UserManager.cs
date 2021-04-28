using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using CoreLayer.Aspects.Autofac.Validation;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDAL _iUserDal;

        public UserManager(IUserDAL iUserDal)
        {
            _iUserDal = iUserDal;
        }

        public IDataResult<List<NUser>> GetAll()
        {
            return new SuccessDataResult<List<NUser>>(_iUserDal.GetAll());
        }

        public IDataResult<NUser> GetById(int userid)
        {
            return new SuccessDataResult<NUser>(_iUserDal.Get(i => i.Id == userid));
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(NUser user)
        {
            _iUserDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(NUser user)
        {
            _iUserDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IResult Delete(NUser user)
        {
            _iUserDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }
    }
}
