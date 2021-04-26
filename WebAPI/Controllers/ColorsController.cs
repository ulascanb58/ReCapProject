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
    public class ColorsController : ControllerBase
    {
        private IColorService _iColorService;

        public ColorsController(IColorService colorService)
        {
            _iColorService = colorService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _iColorService.GetAll();
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _iColorService.GetById(id);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(NColor color)
        {
            var result = _iColorService.AddColor(color);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
        [HttpPost("Update")]
        public IActionResult Update(NColor color)
        {
            var result = _iColorService.UpdateColor(color);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
        [HttpPost("Delete")]
        public IActionResult Delete(NColor color)
        {
            var result = _iColorService.DeleteColor(color);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }





    }
}