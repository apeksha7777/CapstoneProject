using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Capstone.Models;

namespace Capstone.Controllers
{
   // [Route("api/[controller]")]
    [ApiController]
    public class AdminProductsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public AdminProductsController()
        {
            _context = new ApplicationDBContext();
        }

        // GET: AdminProducts
        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> Get() //get product list
        {
            return new JsonResult(await _context.Products.ToListAsync());
        }

        [HttpPost]
        [Route("api/[controller]/addProduct")]
        public async Task<IActionResult> Post(Product product) //add new product
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
            return new JsonResult("Added successfully");

        }

        [Route("api/[controller]/editProduct/{id}")]
        public async Task<IActionResult> Put(Product product) //edit a product
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
            return new JsonResult("updated successfully");

        }

        [Route("api/[controller]/deleteProduct/{id}")]
        public async Task<IActionResult> Delete(Product product) //delete a product
        {
            _context.Remove(product);
            await _context.SaveChangesAsync();
            return new JsonResult("deleted successfully");

        }

        [HttpGet]
        [Route("api/product/{id}")] //get product by id
        public async Task<IActionResult> Get(int id)
        {
            
            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);

            return new JsonResult(product);
        }





    }
}
