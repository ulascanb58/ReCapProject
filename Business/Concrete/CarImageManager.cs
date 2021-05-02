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
        ICarImageDAL _iCarImageDal;
        public CarImageManager(ICarImageDAL iCarImageDAL)
        {
            _iCarImageDal = iCarImageDAL;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, NCarImage image)
        {
          

            IResult result = BusinessRules.Run(CheckIfCarImageCountCorrect(image.CarId));



            if (result != null)
            {
                return new ErrorResult("One car must have 5 or less images");
            }

            var imageResult = FileHelper.Upload(file);

            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            image.ImagePath = imageResult.Message;
            _iCarImageDal.Add(image);
            return new SuccessResult("Car image added");
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(NCarImage image)
        {
            var result = _iCarImageDal.Get(c => c.ImageId == image.ImageId);
            if (result == null)
            {
                return new ErrorResult("Messages.ImageNotFound");
            }

            FileHelper.Delete(result.ImagePath);
            _iCarImageDal.Delete(result);
            return new SuccessResult("Messages.ImageDeleted");
        }

        public IDataResult<NCarImage> Get(int Id)
        {
            return new SuccessDataResult<NCarImage>(_iCarImageDal.Get(p => p.CarId == Id));
        }

        public IDataResult<List<NCarImage>> GetAll()
        {
            return new SuccessDataResult<List<NCarImage>>(_iCarImageDal.GetAll(), "Messages.ImagesListed");
        }

        public IDataResult<List<NCarImage>> GetById(int carId)
        {
            return new SuccessDataResult<List<NCarImage>>(_iCarImageDal.GetAll(c => c.CarId == carId), "Messages.ImagesListed");
        }

        public IDataResult<List<NCarImage>> GetImagesByCarId(int carId)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageNull(carId));
            if (result == null)
            {
                return new ErrorDataResult<List<NCarImage>>(result.Message);
            }
            return new SuccessDataResult<List<NCarImage>>(CheckIfCarImageNull(carId).Data, "Messages.ImagesListed");
        }
       // [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, NCarImage image)
        {
            var isImage = _iCarImageDal.Get(c => c.ImageId == image.ImageId);
            if (isImage == null)
            {
                return new ErrorResult("Messages.ImageNotFound");
            }

            var updatedFile = FileHelper.Update(file, isImage.ImagePath);
            if (!updatedFile.Success)
            {
                return new ErrorResult(updatedFile.Message);
            }
            image.ImagePath = updatedFile.Message;
            _iCarImageDal.Update(image);
            return new SuccessResult("Messages.CarImageUpdated");
        }


        public IResult CheckIfCarImageCountCorrect(int carId)
        {
            var result = _iCarImageDal.GetAll(c => c.CarId == carId).Count;
            if (result > 5)
            {
                return new ErrorResult("Messages.ImageLimitExceeded");
            }
            return new SuccessResult();
        }

        private IDataResult<List<NCarImage>> CheckIfCarImageNull(int carId)
        {
            try
            {
                string path = @"\images\logo.jpg";
                var result = _iCarImageDal.GetAll(c => c.CarId == carId).Any();
                if (!result)
                {
                    List<NCarImage> image = new List<NCarImage>();
                    image.Add(new NCarImage { CarId = carId, ImagePath = path, Date = DateTime.Now });
                    return new SuccessDataResult<List<NCarImage>>(image);
                }
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<NCarImage>>(exception.Message);
            }
            return new SuccessDataResult<List<NCarImage>>(_iCarImageDal.GetAll(p => p.CarId == carId).ToList());
        }


    }
}
