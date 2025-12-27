using System.Windows.Input;
using BookStore_Presentation.Command;

namespace BookStore_Presentation.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
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

        public ICommand OpenInventoryByStoreCommand { get; }

        public ICommand OpenBookAdminCommand { get; }

        public MainWindowViewModel()
        {
            OpenInventoryByStoreCommand = new DelegateCommand(_ =>
            {
                CurrentViewModel = new InventoryByStoreViewModel(); // navigation
            });

            OpenBookAdminCommand = new DelegateCommand(_ =>
            
            CurrentViewModel = new BooksAdminViewModel());
            }
        }

    }
