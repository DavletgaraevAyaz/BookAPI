using WebApplication1.Models;

namespace WebApplication1.Interface
{
    public interface IBooksService
    {
        Task<IEnumerable<Books>> GetAllBooksAsync();
        Task<Books> GetBookssByIdAsync(int id);
        Task AddBookssAsync(Books newBookss);
        Task UpdateBookssAsync(int id, Books updatedBookss);
        Task DeleteBookssAsync(int id);
        Task<IEnumerable<Books>> GetBooksByGenreAsync(int genreId);
        Task<IEnumerable<Books>> SearchBooksAsync(string query);
        Task<IEnumerable<Books>> SearchBooksAsync(string author, string genre, int? year);
        Task<IEnumerable<Books>> GetBooksPaginatedAsync(int page, int pageSize);
        Task ImportBooksAsync(IEnumerable<Books> Books);
        Task<IEnumerable<Books>> ExportBooksAsync();

        Task<int> GetTotalBooksCountAsync();

    }
}
