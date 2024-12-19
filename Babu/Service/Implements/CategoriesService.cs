using Babu.DAL;
using Babu.DTOs;
using Babu.Entities;
using Babu.Service.Abstracts;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Babu.Service.Implements
{
    public class CategoriesService(BabuDbContext _context) : ICategoriesService
    {
        

        async Task ICategoriesService.CreateAsync(CategoriesCreatDto vm)
        {
            await _context.categories.AddAsync(new Entities.Categories
            {
                Name = vm.Name, 
               
            });
           await _context.SaveChangesAsync();

        }

       async  Task<Boolean> ICategoriesService.DeleteAsync(CategoriesCreatDto vm)
        {
            Boolean result = new Boolean();
            result = false;
            var data =await _context.categories.FirstOrDefaultAsync(x=>x.Name == vm.Name);
            if (data != null)
            {
                _context.categories.Remove(data);

                result = true;
                await _context.SaveChangesAsync();  
                return result ;
            }
                
             await _context.SaveChangesAsync();
            return result;
        }

        async Task<IEnumerable<CategoriesGetDto>> ICategoriesService.GetAllAsync()
        {
           return await _context.categories.Select(x=> new CategoriesGetDto
           {
               Id = x.Id,   
               Name = x.Name,  
           }).ToListAsync();
         
        }
       
    }
}
