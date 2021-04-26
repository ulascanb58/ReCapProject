using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomerService _iCustomerService;// = new CustomerManager(new EfCustomerDAL());

        public CustomersController(ICustomerService customerService)
        {
            _iCustomerService = customerService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _iCustomerService.GetAll();
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _iCustomerService.GetById(id);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(NCustomer customer)
        {
            var result = _iCustomerService.Add(customer);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpPost("Update")]
        public IActionResult Update(NCustomer customer)
        {
            var result = _iCustomerService.Update(customer);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
        [HttpPost("Delete")]
        public IActionResult Delete(NCustomer customer)
        {
            var result = _iCustomerService.Delete(customer);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpGet("CustomerDetail")]
        public IActionResult GetCustomerDetail()
        {
            var result = _iCustomerService.GetCustomerDetails();
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}