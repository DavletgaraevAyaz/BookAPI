using Microsoft.EntityFrameworkCore;
using WebApplication1.DbContextApi;
using WebApplication1.Interface;
using WebApplication1.Models;

namespace WebApplication1.Service
{
    public class GenresService : IGenresService
    {
        private readonly LibraryContext _context;

        public GenresService(LibraryContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Genres>> GetAllGenresAsync()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task<Genres> GetGenreByIdAsync(int id)
        {
            return await _context.Genres.FindAsync(id);
        }

        public async Task<Genres> AddGenreAsync(Genres genre)
        {
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();
            return genre;
        }

        public async Task<Genres> UpdateGenreAsync(int id, Genres genre)
        {
            if (id != genre.Id_Genres)
                return null;

            _context.Entry(genre).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return genre;
        }

        public async Task<bool> DeleteGenreAsync(int id)
        {
            var genre = await _context.Genres.FindAsync(id);
            if (genre == null)
                return false;

            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Genres>> SearchGenresAsync(string searchTerm)
        {
            return await _context.Genres
                .Where(g => g.Name.Contains(searchTerm))
                .ToListAsync();
        }

        public async Task<(IEnumerable<Genres> genres, int totalCount)> GetGenresPaginatedAsync(int page, int pageSize)
        {
            var totalCount = await _context.Genres.CountAsync();
            var genres = await _context.Genres
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (genres, totalCount);
        }

        public async Task<int> GetTotalGenresCountAsync()
        {
            return await _context.Genres.CountAsync();
        }

        public async Task ImportGenresAsync(IEnumerable<Genres> genres)
        {
            await _context.Genres.AddRangeAsync(genres);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Genres>> ExportGenresAsync()
        {
            return await _context.Genres.ToListAsync();
        }
    }
}
