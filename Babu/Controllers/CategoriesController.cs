using Babu.DAL;
using Babu.DTOs;
using Babu.Service.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Babu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(BabuDbContext _context,ICategoriesService _service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
         
            return Ok(await _service.GetAllAsync());
        }
        [HttpPost]
        public async Task Create(CategoriesCreatDto dto)
        {
           await _service.CreateAsync(dto);
          
       
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(CategoriesCreatDto dto)
        {
           bool result = await _service.DeleteAsync(dto);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut]
        public async Task Update()
        {

        }


    }
}
