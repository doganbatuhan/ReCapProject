using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        IWebHostEnvironment _webHostEnvironment;
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService, IWebHostEnvironment webHostEnvironment)
        {
            _carImageService = carImageService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallbycarid")]
        public IActionResult GetAllByCarId(int id)
        {
            var result = _carImageService.GetAllByCarId(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] FileUpload objectFile)
        {
            try
            {
                if (objectFile.Files.Length > 0)
                {
                    string path = System.IO.Directory.GetCurrentDirectory();
                    path = System.IO.Directory.GetParent(path).ToString() + "\\Images\\";

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fileStream = System.IO.File.Create(path + Guid.NewGuid().ToString()
                        + Path.GetExtension(objectFile.Files.FileName)))
                    {
                        objectFile.Files.CopyTo(fileStream);
                        fileStream.Flush();
                        var image = new CarImage { CarId = objectFile.CarId, ImagePath = fileStream.Name.ToString(), Date = DateTime.Now };
                        var result = _carImageService.Add(image);
                        if (result.Success)
                        {
                            return Ok(result);
                        }
                        return BadRequest(result);
                    }
                }
                return BadRequest("Failed");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost("update")]
        public IActionResult Update(CarImage image)
        {
            var result = _carImageService.Update(image);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CarImage image)
        {
            var result = _carImageService.Delete(image);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
