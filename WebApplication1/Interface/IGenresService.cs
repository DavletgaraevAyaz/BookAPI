using WebApplication1.Models;

namespace WebApplication1.Interface
{
    public interface IGenresService
    {
        Task<IEnumerable<Genres>> GetAllGenresAsync();
        Task<Genres> GetGenreByIdAsync(int id);
        Task<Genres> AddGenreAsync(Genres genre);
        Task<Genres> UpdateGenreAsync(int id, Genres genre);
        Task<bool> DeleteGenreAsync(int id);
        Task<IEnumerable<Genres>> SearchGenresAsync(string searchTerm);
        Task<(IEnumerable<Genres> genres, int totalCount)> GetGenresPaginatedAsync(int page, int pageSize);
        Task<int> GetTotalGenresCountAsync();
        Task ImportGenresAsync(IEnumerable<Genres> genres);
        Task<IEnumerable<Genres>> ExportGenresAsync();
    }
}
