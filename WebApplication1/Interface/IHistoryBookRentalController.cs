using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public interface IHistoryBookRentalController
    {
        Task<IActionResult> RentBook(Book_Rental_History newRental);
        Task<IActionResult> ReturnBook(int id);
        Task<IActionResult> GetRentalHistoryForReader(int readerId);
        Task<IActionResult> GetRentalHistoryForBook(int bookId);
        Task<IActionResult> GetCurrentRentals();
    }
}
