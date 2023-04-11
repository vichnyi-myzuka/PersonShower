using PersonShower.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using PersonShower.Tools;
using PersonShower.Calendar;
using PersonShower.Models;

namespace PersonShower.Views;

    /// <summary>
    /// Interaction logic for PeopleGrid.xaml
    /// </summary>
    public partial class PeopleGrid : UserControl
    {
    private PersonListingViewModel _personListingViewModel;
    public PeopleGrid()
    {
        InitializeComponent();
        DataContext = _personListingViewModel = new PersonListingViewModel();

        FilterBy.ItemsSource = typeof(PersonViewModel).GetProperties().Where((o) => o.Name != "SignInCommand").Select((o) => o.Name);
    }

    private void FilterBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        _personListingViewModel.UpdateFilter();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        PersonsLoader.SavePeople(_personListingViewModel.GetPeople());
    }

    private bool flagfix = true;
    private void DataGridXAML_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
    {
        if((string)e.Column.Header == "Birthdate")
        {
            PersonViewModel p = e.Row.Item as PersonViewModel;
            //MessageBox.Show($"{p.Name} {p.Surname} {p.Email} {p.Date} {p.Age}");

            if (flagfix)
            {
                flagfix = false;
                DataGridXAML.CancelEdit();
                DataGridXAML.CancelEdit();
                flagfix = true;
                DataGridXAML.Items.Refresh();
            }
        }
        
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        DataGridXAML.Items.Refresh();
    }
}

