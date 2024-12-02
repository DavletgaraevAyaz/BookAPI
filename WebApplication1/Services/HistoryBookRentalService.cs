using Microsoft.EntityFrameworkCore;
using WebApplication1.DbContextApi;
using WebApplication1.Interface;
using WebApplication1.Models;

namespace WebApplication1.Service
{
    public class HistoryBookRentalService : IHistoryBookRentalService
    {
        private readonly LibraryContext _context;

        public HistoryBookRentalService(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book_Rental_History>> GetAllHistoryAsync()
        {
            return await _context.Rentals.ToListAsync();
        }

        public async Task<Book_Rental_History> GetHistoryByIdAsync(int id)
        {
            return await _context.Rentals.FindAsync(id);
        }

        public async Task<Book_Rental_History> AddHistoryAsync(Book_Rental_History history)
        {
            _context.Rentals.Add(history);
            await _context.SaveChangesAsync();
            return history;
        }

        public async Task<Book_Rental_History> UpdateHistoryAsync(int id, Book_Rental_History history)
        {
            if (id != history.Id)
                return null;

            _context.Entry(history).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await HistoryExists(id))
                    return null;
                throw;
            }
            return history;
        }

        public async Task<bool> DeleteHistoryAsync(int id)
        {
            var history = await _context.Rentals.FindAsync(id);
            if (history == null)
                return false;

            _context.Rentals.Remove(history);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Book_Rental_History>> SearchHistoryAsync(string searchTerm)
        {
            return await _context.Rentals   
                .Where(h => h.Books.Title.Contains(searchTerm) || h.Readers.Name.Contains(searchTerm))
                .ToListAsync();
        }

        public async Task<(IEnumerable<Book_Rental_History> histories, int totalCount)> GetHistoryPaginatedAsync(int page, int pageSize)
        {
            var totalCount = await _context.Rentals.CountAsync();
            var histories = await _context.Rentals
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (histories, totalCount);
        }

        public async Task<int> GetTotalHistoryCountAsync()
        {
            return await _context.Rentals.CountAsync();
        }

        public async Task ImportHistoryAsync(IEnumerable<Book_Rental_History> histories)
        {
            await _context.Rentals.AddRangeAsync(histories);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book_Rental_History>> ExportHistoryAsync()
        {
            return await _context.Rentals.ToListAsync();
        }

        private async Task<bool> HistoryExists(int id)
        {
            return await _context.Rentals.AnyAsync(e => e.Id == id);
        }
    }
}
