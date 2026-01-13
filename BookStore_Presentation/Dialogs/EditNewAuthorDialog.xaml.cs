using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BookStore_Presentation.Models;
using BookStore_Presentation.Services;
using BookStore_Presentation.ViewModels;
using Microsoft.VisualStudio.Services.DelegatedAuthorization;


namespace BookStore_Presentation.Dialogs
{
    /// <summary>
    /// Interaction logic for EditNewAuthorDialog.xaml
    /// </summary>
    public partial class EditNewAuthorDialog : Window
    {
        private readonly AuthorService _authorService;
        public CreateNewAuthorDto? Author { get; private set; }
        public EditNewAuthorDialog(AuthorService authorService)
        {
            InitializeComponent();
            _authorService = authorService;

        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is AddNewAuthorViewModel vm)
            {
                string? errorMessage;
                if (!_authorService.IsValidAuthor(vm.FirstName, vm.LastName, vm.BirthDayText, out errorMessage))
                {
                    MessageBox.Show(errorMessage, "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                DateOnly? birthDate = null;
                if (!string.IsNullOrWhiteSpace(vm.BirthDayText) &&
                    DateOnly.TryParse(vm.BirthDayText, out var d))
                {
                    birthDate = d;
                }

                Author = new CreateNewAuthorDto
                {
                    FirstName = vm.FirstName,
                    LastName = vm.LastName,
                    BirthDay = birthDate
                };

                MessageBox.Show("Author edited successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
                Close();
            }
        }
        private void CancelButton_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
