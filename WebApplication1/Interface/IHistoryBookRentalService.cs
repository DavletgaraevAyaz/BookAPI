using WebApplication1.Models;

namespace WebApplication1.Interface
{
    public interface IHistoryBookRentalService
    {
        Task<IEnumerable<Book_Rental_History>> GetAllHistoryAsync();
        Task<Book_Rental_History> GetHistoryByIdAsync(int id);
        Task<Book_Rental_History> AddHistoryAsync(Book_Rental_History history);
        Task<Book_Rental_History> UpdateHistoryAsync(int id, Book_Rental_History history);
        Task<bool> DeleteHistoryAsync(int id);
        Task<IEnumerable<Book_Rental_History>> SearchHistoryAsync(string searchTerm);
        Task<(IEnumerable<Book_Rental_History> histories, int totalCount)> GetHistoryPaginatedAsync(int page, int pageSize);
        Task<int> GetTotalHistoryCountAsync();
        Task ImportHistoryAsync(IEnumerable<Book_Rental_History> histories);
        Task<IEnumerable<Book_Rental_History>> ExportHistoryAsync();
    }
}
