using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using CoreLayer.Aspects.Autofac.Validation;
using CoreLayer.Utilities;
using CoreLayer.Utilities.Helpers;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService

    {
        ICarImageDAL _carImageDal;

        public CarImageManager(ICarImageDAL carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, NCarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckCarImageLimit(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(NCarImage carImage)
        {
            FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, NCarImage carImage)
        {
            carImage.ImagePath = FileHelper.Update(_carImageDal.Get(c => c.ImageId == carImage.ImageId).ImagePath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<NCarImage> GetById(int id)
        {
            return new SuccessDataResult<NCarImage>(_carImageDal.Get(c => c.ImageId == id));
        }


        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<List<NCarImage>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<NCarImage>>(ShowDefaultImage(carId));
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<List<NCarImage>> GetAll()
        {
            return new SuccessDataResult<List<NCarImage>>(_carImageDal.GetAll());
        }
        /*--------------------------------------------------------------------------------------------------------*/
        private IResult CheckCarImageLimit(int carId)
        {
            var CarImages = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (CarImages >= 5)
            {
                return new ErrorResult("Message.CarImageLimit");
            }

            return new SuccessResult();
        }
        private List<NCarImage> ShowDefaultImage(int carId)
        {
            string path = @"\Images\logo.png";
            var result = _carImageDal.GetAll(c => c.CarId == carId).Any();

            if (result)
            {
                return new List<NCarImage>(_carImageDal.GetAll(c => c.CarId == carId));
            }

            List<NCarImage> carImage = new List<NCarImage>();
            carImage.Add(new NCarImage { CarId = carId, ImagePath = path, Date = DateTime.Now });

            return new List<NCarImage>(carImage);
        }


    }
}
