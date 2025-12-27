using System.Collections.ObjectModel;
using BookStore_Infrastrcuture.Data.Model;
using Microsoft.EntityFrameworkCore;
using BookStore_Domain;


namespace BookStore_Presentation.ViewModels
{
    public class BooksAdminViewModel : ViewModelBase
    {
        private readonly BookStoreContext _context;

        public ObservableCollection<BookAdminItem> Books { get; }

        public BooksAdminViewModel()
        {
            _context = new BookStoreContext();
            Books = new ObservableCollection<BookAdminItem>(LoadBooks());
        }

        private List<BookAdminItem> LoadBooks()
        {
            return _context.Books
                .Include(b => b.Genre)
                .Select(b => new BookAdminItem
                {
                    Isbn13 = b.Isbn13,
                    Title = b.Title,
                    Genre = b.Genre != null ? b.Genre.GenreName : "",
                    Language = b.Language,
                    Price = b.Price ?? 0m
                })
                .ToList();
        }
    }
}