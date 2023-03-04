using System.Windows.Controls;
using PersonShower.ViewModels;

namespace PersonShower.Views;

public partial class PersonDataControl : UserControl
{
    private PersonViewModel _viewModel;
    public PersonDataControl()
    {
        InitializeComponent();
        DataContext = _viewModel = new PersonViewModel();
    }

    public PersonDataControl(PersonViewModel personViewModel)
    {
        DataContext = _viewModel = personViewModel;
    }
}