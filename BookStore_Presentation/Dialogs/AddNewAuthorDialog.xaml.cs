using System.Windows;
using BookStore_Presentation.Models;
using BookStore_Presentation.ViewModels;

namespace BookStore_Presentation.Dialogs
{
    /// <summary>
    /// Interaction logic for AddNewAuthorDialog.xaml
    /// </summary>
    public partial class AddNewAuthorDialog : Window
    {
        public CreateNewAuthorDto Author { get; private set; }
        public AddNewAuthorDialog()
        {
            InitializeComponent();
            Author = new CreateNewAuthorDto();
            DataContext = Author; // Fixed: assign the property, not invoke as a method
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as AddNewAuthorViewModel;

            if (string.IsNullOrWhiteSpace(Author.FirstName) || string.IsNullOrWhiteSpace(Author.LastName))
            {
                MessageBox.Show("Please fill in both First Name and Last Name.");
                return;
            }

            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
