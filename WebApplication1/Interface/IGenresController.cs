using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public interface IGenresController
    {
        Task<IActionResult> GetAllGenres();
        Task<IActionResult> AddGenre(Genres newGenre);
        Task<IActionResult> UpdateGenre(int id, Genres updatedGenre);
        Task<IActionResult> DeleteGenre(int id);
    }
}
