using System.Windows.Input;
using BookStore_Infrastrcuture.Data.Model;
using BookStore_Presentation.Command;
using BookStore_Presentation.Services;

namespace BookStore_Presentation.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
 
        {
            // Current view bound to ContentControl
            private ViewModelBase? _currentViewModel;
            public ViewModelBase? CurrentViewModel
            {
                get => _currentViewModel;
                set
                {
                    _currentViewModel = value;
                    RaisePropertyChanged();
                }
            }

        // Commands for sidebar navigation
        public ICommand OpenInventoryByStoreCommand { get; }
        public ICommand OpenBookAdminCommand { get; }
        public ICommand OpenAllAuthorsCommand { get; }

        // Keep VM instances to avoid recreating them
        private readonly BooksAdminViewModel _booksVm;
        private readonly AuthorsAdminViewModel _authorsVm;
        private readonly InventoryByStoreViewModel _inventoryVm;


        public MainWindowViewModel(BookSelectionService bookSelectionService, AuthorService authorService)
        {
      
            _booksVm = new BooksAdminViewModel(bookSelectionService, authorService);
            _authorsVm = new AuthorsAdminViewModel(authorService);
            _inventoryVm = new InventoryByStoreViewModel(bookSelectionService, _booksVm);

     
            OpenInventoryByStoreCommand = new DelegateCommand(_ =>
            {
                CurrentViewModel = _inventoryVm;
            });

            OpenBookAdminCommand = new DelegateCommand(_ =>
            {
                CurrentViewModel = _booksVm;
            });

            OpenAllAuthorsCommand = new DelegateCommand(_ =>
            {
                _authorsVm.LoadAuthors(); // Refresh authors before showing
                CurrentViewModel = _authorsVm;
            });

          
            CurrentViewModel = _booksVm;
        }
    }
}




