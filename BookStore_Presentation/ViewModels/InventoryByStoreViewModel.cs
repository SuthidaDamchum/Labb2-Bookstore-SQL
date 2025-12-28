using System.Collections.ObjectModel;
using BookStore_Domain;
using BookStore_Infrastrcuture.Data.Model;
using BookStore_Presentation.Command;
using Microsoft.EntityFrameworkCore;

namespace BookStore_Presentation.ViewModels
{
    internal class InventoryByStoreViewModel : ViewModelBase
    {
        private readonly BookStoreContext _context = new();

        public ObservableCollection<Store> Stores { get; private set; }
        public ObservableCollection<InventoryItem> Inventory { get; private set; } = new();

        private Store? _selectedStore;
        public Store? SelectedStore
        {
            get => _selectedStore;
            set
            {
                _selectedStore = value;
                LoadInventory();
                RaisePropertyChanged();
            }
        }

        private InventoryItem? _selectedInventoryItem;
        public InventoryItem? SelectedInventoryItem
        {
            get => _selectedInventoryItem;
            set
            {
                _selectedInventoryItem = value;
                RaisePropertyChanged();
                ((DelegateCommand)IncreaseQuantityCommand).RaiseCanExecuteChanged();
                ((DelegateCommand)DecreaseQuantityCommand).RaiseCanExecuteChanged();
            }
        }



        public DelegateCommand IncreaseQuantityCommand { get; }
        public DelegateCommand DecreaseQuantityCommand { get; }

        public InventoryByStoreViewModel()
        {
            LoadStores();

            IncreaseQuantityCommand = new DelegateCommand(
               _ =>
               {
                   if (SelectedInventoryItem != null)
                   {
                       SelectedInventoryItem.Quantity++;
                       UpdateQuantityInDatabase(SelectedInventoryItem, +1);
                   }
               },
               _ => SelectedInventoryItem != null
           );

            DecreaseQuantityCommand = new DelegateCommand(
                _ =>
                {
                    if (SelectedInventoryItem != null && SelectedInventoryItem.Quantity > 0)
                    {
                        SelectedInventoryItem.Quantity--;
                        UpdateQuantityInDatabase(SelectedInventoryItem, -1);
                    }
                },
                _ => SelectedInventoryItem != null && SelectedInventoryItem.Quantity > 0
            );
        }

        private void UpdateQuantityInDatabase(InventoryItem item, int delta)
        {
            var inventory = _context.Inventories
                .FirstOrDefault(i => i.Isbn13 == item.ISBN && i.StoreId == item.StoreId);

            if (inventory != null)
            {
                inventory.Quantity += delta;
                _context.SaveChanges();
            }
        }
        private void LoadStores()
        {
            Stores = new ObservableCollection<Store>(_context.Stores.ToList());
            SelectedStore = Stores.FirstOrDefault();
            RaisePropertyChanged(nameof(Stores));
        }

        private void LoadInventory()
        {
            if (SelectedStore == null) return;

            Inventory = new ObservableCollection<InventoryItem>(
                _context.Inventories
                    .Include(i => i.Isbn13Navigation)
                    .Where(i => i.StoreId == SelectedStore.StoreId)
                    .Select(i => new InventoryItem
                    {
                        ISBN = i.Isbn13Navigation.Isbn13,
                        Title = i.Isbn13Navigation.Title,
                        Price = i.Isbn13Navigation.Price ?? 0m,
                        Quantity = i.Quantity
                    }).ToList()
            );
            RaisePropertyChanged(nameof(Inventory));
        }
    }
}