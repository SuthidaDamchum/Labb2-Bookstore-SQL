using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using BookStore_Domain;
using BookStore_Infrastrcuture.Data.Model;
using BookStore_Presentation.Models;
using BookStore_Presentation.ViewModels;

namespace BookStore_Presentation.Dialogs
{
    /// <summary>
    /// Interaction logic for AddNewTitleDailog.xaml
    /// </summary>
    public partial class AddNewTitleDailog : Window
    {
        public AddNewTitleDailog(AddNewTitleViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}