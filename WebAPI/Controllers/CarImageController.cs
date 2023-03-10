using Business.Abstrack;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImageController : ControllerBase
    {
        ICarImageService _carImageService;

        [HttpPost("add")]

        public IActionResult Add([FromForm (Name ="name")] IFormFile file, [FromForm]  CarImage carImage)
        {
            var result = _carImageService.Add(file, carImage);
           
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
