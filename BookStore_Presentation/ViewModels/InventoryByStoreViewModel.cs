using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore_Domain;
using BookStore_Infrastrcuture.Data.Model;
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

        public InventoryByStoreViewModel()
        {
            LoadStores();
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