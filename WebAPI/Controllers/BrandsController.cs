using System;
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
    public class BrandsController : ControllerBase
    {
        private IBrandService _iBrandService;

        public BrandsController(IBrandService brandService)
        {
            _iBrandService = brandService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _iBrandService.GetAll();
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _iBrandService.GetById(id);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("Add")]
        public  IActionResult Add(NBrand brand)
        {
            var result = _iBrandService.AddBrand(brand);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(NBrand brand)
        {
            var result = _iBrandService.DeleteBrand(brand);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(NBrand brand)
        {
            var result = _iBrandService.UpdateBrand(brand);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


    }
}