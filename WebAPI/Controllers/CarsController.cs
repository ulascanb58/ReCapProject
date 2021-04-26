﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ICarService _iCarService;

        public CarsController(ICarService carService)
        {
            _iCarService = carService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _iCarService.GetAll();
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _iCarService.GetCarsById(id);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetCarsByColorId")]
        public IActionResult GetCarsByColorId(int id)
        {
            var result = _iCarService.GetCarsByColorId(id);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetCarsByBrandId")]
        public IActionResult GetCarsByBrandId(int id)
        {
            var result = _iCarService.GetCarsByBrandId(id);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetCarsByPrice")]
        public  IActionResult GetCarsByPrice(int min,int max)
        {
            var result = _iCarService.GetByDailyPrice(min, max);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);


        }

        [HttpGet("GetCarDetails")]

        public IActionResult GetCarDetails()
        {
            var result = _iCarService.GetCarDetails();
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(NCar car)
        {
            var result = _iCarService.AddCar(car);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
        [HttpPost("Update")]
        public IActionResult Update(NCar car)
        {
            var result = _iCarService.Update(car);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
        [HttpPost("Delete")]
        public IActionResult Delete(NCar car)
        {
            var result = _iCarService.Delete(car);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }



    }
}