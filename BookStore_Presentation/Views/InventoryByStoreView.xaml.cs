using System.Windows.Controls;

namespace BookStore_Presentation.Views
{
    /// <summary>
    /// Interaction logic for InventoryByStore.xaml
    /// </summary>
    public partial class InventoryByStoreView : UserControl
    {
        public InventoryByStoreView()
        {
            InitializeComponent();
            //DataContext = new InventoryByStoreViewModel(); // <-- Rätt ViewModel
        }
    }
}