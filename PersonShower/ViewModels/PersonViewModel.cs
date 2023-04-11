using System;
using System.ComponentModel;
using System.Threading.Tasks;
using PersonShower.Exceptions;
using PersonShower.Models;
using PersonShower.Tools;

namespace PersonShower.ViewModels;

public class PersonViewModel : INotifyPropertyChanged
{
    #region Field

    private Person _person;
    private RelayCommand<object> _signInCommand;
    public event PropertyChangedEventHandler PropertyChanged;

    #endregion

    public PersonViewModel()
    {
        _person = new();
    }
    
    public PersonViewModel(Person person)
    {
        _person = person;
    }

    #region Properties

    public string Name
    {
        get { return _person.Name; }
        set
        {
            _person.Name = value;
            NotifyPropertyChanged("Name");
        }
    }

    public string Surname
    {
        get { return _person.Surname; }
        set
        {
            _person.Surname = value;
            NotifyPropertyChanged("Surname");
        }
    }

    public string Email
    {
        get { return _person.Email; }
        set
        {
            _person.Email = value;
            NotifyPropertyChanged("Email");
        }
    }

    public DateTime Date
    {
        get { return _person.Date; }
        set
        {
            _person.Date = value;
            NotifyPropertyChanged("Date");
        }
    }

    public int Age
    {
        get { return _person.GetAge(Date); }
    }

    public bool IsAdult
    {
        get { return Age >= 18; }
    }

    public string SunSign
    {
        get { return _person.GetSunSign(); }
    }

    public string ChineseSign
    {
        get { return _person.GetChineseSign(); }
    }

    public bool IsBirthday
    {
        get { return Date.Day == DateTime.Today.Day && Date.Month == DateTime.Today.Month; }
    }

    public RelayCommand<object> SignInCommand
    {
        get { return _signInCommand ??= new RelayCommand<object>(_ => SignIn(), CanSignIn); }
    }

    #endregion

    private void NotifyPropertyChanged(String propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private async void SignIn()
    {
        if (!IsValidEmail(Email))
        {
            throw new WrongEmailException("Your email is wrong!");
        }
        await Task.Run(() => { Task.Delay(1000).Wait(); });
        new PersonWindow(this).Show();
    }

    private bool CanSignIn(object obj)
    {
        return !String.IsNullOrEmpty(Name) || !String.IsNullOrEmpty(Surname) || !String.IsNullOrEmpty(Email);
    }
    
    private bool IsValidEmail(string email)
    {
        var trimmedEmail = email.Trim();

        if (trimmedEmail.EndsWith("."))
        {
            return false;
        }

        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == trimmedEmail;
        }
        catch
        {
            return false;
        }
    }
}