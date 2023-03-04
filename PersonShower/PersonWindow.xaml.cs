using System;
using System.Windows;
using PersonShower.ViewModels;
using PersonShower.Views;

namespace PersonShower;

public partial class PersonWindow : Window
{
    private PersonViewModel _viewModel;
    public PersonWindow()
    {
        InitializeComponent();
        DataContext = _viewModel = new PersonViewModel();
    }

    public PersonWindow(PersonViewModel personViewModel)
    {
        InitializeComponent();
        DataContext = _viewModel = personViewModel;
    }
}