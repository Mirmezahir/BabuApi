using Babu.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Babu.Service.Abstracts
{
    public interface ICategoriesService
    {
        Task CreateAsync(CategoriesCreatDto vm);
        Task<Boolean> DeleteAsync(CategoriesCreatDto vm);
        Task<IEnumerable<CategoriesGetDto>> GetAllAsync();

    }
}
