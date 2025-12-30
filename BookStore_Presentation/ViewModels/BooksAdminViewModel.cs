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
                .Include(b => b.BookAuthors)
                    .ThenInclude(ba => ba.Author)
                .Select(b => new BookAdminItem
                {
                    Isbn13 = b.Isbn13,
                    Title = b.Title,
                    AuthorNames = string.Join(", ",
                    b.BookAuthors.Select(ba =>
                    ba.Author.FirstName + " " + ba.Author.LastName)),
                    Genre = b.Genre != null ? b.Genre.GenreName : "",
                    Language = b.Language,
                    Price = b.Price ?? 0m
                })
                .ToList();
        }


        private void CreateNewTitle(string isbn13, string title, int? genreId,
            string language, decimal price, List<int> existingAuthorIds)

        {
            var authors = _context.Authors
            .Where(a => existingAuthorIds.Contains(a.AuthorId))
            .ToList();

            if (!authors.Any())
                throw new Exception("Could not find a book with the specified ID");

            var newBookTitle = new Book
            {
                Isbn13 = isbn13,
                Title = title,
                GenreId = genreId,
                Language = language,
                Price = price,
                BookAuthors = authors.Select(a => new BookAuthor
                {
                    AuthorId = a.AuthorId
                }).ToList()
            };

            _context.Books.Add(newBookTitle);
            _context.SaveChanges();

            Books.Add(new BookAdminItem

            {

                Isbn13 = newBookTitle.Isbn13,
                Title = newBookTitle.Title,
                AuthorNames = string.Join(", ", authors.Select(a => $"{a.FirstName} {a.LastName}")),
                 Genre = newBookTitle.Genre != null ? newBookTitle.Genre.GenreName : "",
                Language = newBookTitle.Language,
                 Price = newBookTitle.Price ?? 0m
            });

        }
    }
}


//private void CreateNewPack()
//{
//    if (ConfigurationViewModel == null)
//    {
//        CurrentView = new ConfigurationViewModel(this);
//    }
//    var newQuestionPackViewModel = new QuestionPackViewModel(new QuestionPack("<PackName>"));
//    var dialog = new AddNewQuestionDialog(newQuestionPackViewModel);

//    if (dialog.ShowDialog() == true)
//    {
//        ActivePack = newQuestionPackViewModel;
//        Packs.Add(newQuestionPackViewModel);
//        CurrentView = ConfigurationViewModel;
//    }