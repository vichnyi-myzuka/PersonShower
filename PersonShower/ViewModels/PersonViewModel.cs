using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using PersonShower.Models;
using PersonShower.Tools;

namespace PersonShower.ViewModels;

public class PersonViewModel: INotifyPropertyChanged
{
    #region Field

    private Person _person = new();
    private RelayCommand<object> _signInCommand;
    public event PropertyChangedEventHandler PropertyChanged;  

    #endregion

    #region Properties

    public string Name
    {
        get
        {
            return _person.Name;
        }
        set
        {
            _person.Name = value;
            NotifyPropertyChanged("Name");
        }
    }

    public string Surname
    {
        get
        {
            return _person.Surname;
        }
        set
        {
            _person.Surname = value;
            NotifyPropertyChanged("Surname");
        }
    }

    public string Email
    {
        get
        {
            return _person.Email;
        }
        set
        {
            _person.Email = value;
            NotifyPropertyChanged("Email");
        }
    }

    public DateTime Date
    {
        get
        {
            return _person.Date;
        }
        set
        {
            _person.Date = value;
            NotifyPropertyChanged("Date");
        }
    }

    public int Age
    {
        get
        {
            return _person.Age;
        }
    }

    public bool IsAdult
    {
        get
        {
            return _person.IsAdult;
        }
    }

    public string SunSign
    {
        get
        {
            return _person.SunSign;
        }
    }

    public string ChineseSign
    {
        get
        {
            return _person.ChineseSign;
        }
    }

    public bool IsBirthday
    {
        get
        {
            return _person.IsBirthday;
        }
    }

    public RelayCommand<object> SignInCommand
    {
        get
        {
            return _signInCommand ??= new RelayCommand<object>(_ => SignIn(), CanSignIn);
        }
    }

    #endregion
    
    private void NotifyPropertyChanged(String propertyName = "")  
    {  
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private async void SignIn()
    {
        if (Age < 0 || Age > 135)
        {
            MessageBox.Show("Your age is impossible!");
        }
        else
        {
            await Task.Run(() =>
            {
                Task.Delay(1000).Wait();
            });
            new PersonWindow(this).Show();
        }
    }
    
    private bool CanSignIn(object obj)
    {
        return !String.IsNullOrEmpty(Name) && !String.IsNullOrEmpty(Surname) && !String.IsNullOrEmpty(Email);
    }
}