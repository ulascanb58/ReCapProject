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
    public class RentalsController : ControllerBase
    {
        private IRentalService _iRentalService;

        public RentalsController(IRentalService rentalService)
        {
            _iRentalService = rentalService;
        }

        [HttpPost("Add")]
        public IActionResult Add(NRental rental)
        {
            var result = _iRentalService.Add(rental);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpPost("Update")]
        public IActionResult Update(NRental rental)
        {
            var result = _iRentalService.Update(rental);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpPost("Delete")]
        public IActionResult Delete(NRental rental)
        {
            var result = _iRentalService.Delete(rental);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _iRentalService.GetAll();
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _iRentalService.GetById(id);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }


        [HttpGet("GetRentalDetails")]
        public IActionResult GetRentalDetails(int id)
        {
            var result = _iRentalService.GetRentalDetails();
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }


    }
}