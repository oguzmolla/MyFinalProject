using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFrameWork;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //Loose coupled gevşek bağımlılık
        //naming convention
        //IoC Container -- Inversion of Control
        //wepapi ıoc container gidip bakıp service e karşılık gelene bakıp çalışıyor.
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public List<Product> Get()
        {
            return new List<Product>
            {
                new Product {ProductId=1, ProductName ="Elma"},
                new Product {ProductId=2, ProductName = "Armut"}
            };
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //Dependency chain --
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //Dependency chain --
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
