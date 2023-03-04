using System.Windows.Controls;
using PersonShower.ViewModels;

namespace PersonShower.Views;

public partial class SignInControl : UserControl
{
    private PersonViewModel _viewModel;
    public SignInControl()
    {
        InitializeComponent();
        DataContext = _viewModel = new PersonViewModel();
    }
}