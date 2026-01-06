using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BookStore_Presentation.ViewModels;




namespace BookStore_Presentation.Models
{
    public class InventoryItem : ViewModelBase
    {
        private int _quantity;
        public string ISBN { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StoreId { get; set; }
        public int Quantity
        {
            get => _quantity;
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    RaisePropertyChanged();
                }
            }

        }

    }
}
    
