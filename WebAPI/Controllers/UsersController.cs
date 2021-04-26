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
    public class UsersController : ControllerBase
    {
         IUserService _iUserService;

         public UsersController(IUserService userService)
         {
             _iUserService = userService;
         }

        //api/users/getall
        [HttpGet("GetAll")]
         public IActionResult GetAll()
         {
             var result = _iUserService.GetAll();
             if (result.Success == true)
             {
                 return Ok(result.Data);
             }
             return BadRequest(result.Data+result.Message);
         }

        //api/users/getbyid?=1
        [HttpGet("GetById")]
         public IActionResult GetById(int id)
         {
             var result = _iUserService.GetById(id);
             if (result.Success == true)
             {
                 return Ok(result.Data);

             }

             return BadRequest(result.Message);

         }
        //api/users/add
        [HttpPost("Add")]
         public IActionResult Add(NUser user)
         {
             var result = _iUserService.Add(user);
             if (result.Success == true)
             {
                 return Ok(result);
             }

             return BadRequest(result);
         }

         [HttpPost("Update")]
         public IActionResult Update(NUser user)
         {
             var result = _iUserService.Update(user);
             if (result.Success == true)
             {
                 return Ok(result);
             }

             return BadRequest(result);
         }

         [HttpPost("Delete")]
         public IActionResult Delete(NUser user)
         {
             var result = _iUserService.Delete(user);
             if (result.Success == true)
             {
                 return Ok(result);
             }

             return BadRequest(result);
         }

    }
}