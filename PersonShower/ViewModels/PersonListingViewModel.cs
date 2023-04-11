using PersonShower.Models;
using PersonShower.Tools;
using PersonShower.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PersonShower.ViewModels;

public class PersonListingViewModel: ViewModelBase
{
    private readonly ObservableCollection<PersonViewModel> _personViewModels;
    public ICollectionView PeopleCollectionView { get; }

    private string _personsFilterPropertyName = string.Empty;
    private string _personsFilter = string.Empty;

    public string PersonsFilter
    {
        get
        {
            return _personsFilter;
        }
        set
        {
            _personsFilter = value;
            OnPropertyChanged(nameof(PersonsFilter));
            PeopleCollectionView.Refresh();
        }
    }

    public string PersonsFilterPropertyName
    {
        get { return _personsFilterPropertyName; }
        set
        {
            _personsFilterPropertyName = value;
            OnPropertyChanged(nameof(PersonsFilterPropertyName));   
            PeopleCollectionView.Refresh();
        }
    }

    public PersonListingViewModel()
    {
        _personViewModels = new ObservableCollection<PersonViewModel>();
        PeopleCollectionView = CollectionViewSource.GetDefaultView(_personViewModels);

        PeopleCollectionView.Filter = GetFilter();

        Person[] people = PersonsLoader.LoadPeople();
        PersonViewModel[] peopleViews = new PersonViewModel[people.Length];
        for (int i = 0; i < people.Length; i++)
        {
            peopleViews[i] = new PersonViewModel(people[i]);
            _personViewModels.Add(peopleViews[i]);
        }
    }

    public Person[] GetPeople() {
        PersonViewModel[] peopleViewModels = _personViewModels.ToArray();
        Person[] people = new Person[peopleViewModels.Length];  
        for (int i = 0;i < peopleViewModels.Length; i++)
        {
            PersonViewModel personViewModel = peopleViewModels[i];
            people[i] = new Person(personViewModel.Name, personViewModel.Surname, personViewModel.Email, personViewModel.Date);
        }
        return people;
    }

    private bool FilterName (object obj)
    {
        if(obj is PersonViewModel personViewModel)
        {
            return personViewModel.Name.Contains(PersonsFilter);
        }
        return false;
    }

    private bool FilterSurname(object obj)
    {
        if (obj is PersonViewModel personViewModel)
        {
            return personViewModel.Surname.Contains(PersonsFilter);
        }
        return false;
    }

    private bool FilterEmail(object obj)
    {
        if (obj is PersonViewModel personViewModel)
        {
            return personViewModel.Email.Contains(PersonsFilter);
        }
        return false;
    }

    private bool FilterDate(object obj)
    {
        if (obj is PersonViewModel personViewModel)
        {
            return personViewModel.Date.ToLongDateString().Contains(PersonsFilter);
        }
        return false;
    }

    private bool FilterAge(object obj)
    {
        if (obj is PersonViewModel personViewModel)
        {
            return personViewModel.Age.ToString().Contains(PersonsFilter);
        }
        return false;
    }

    private bool FilterIsBirthday(object obj)
    {
        if (obj is PersonViewModel personViewModel)
        {
            return personViewModel.IsBirthday.ToString().Contains(PersonsFilter);
        }
        return false;
    }

    private bool FilterIsAdult(object obj)
    {
        if (obj is PersonViewModel personViewModel)
        {
            return personViewModel.IsAdult.ToString().Contains(PersonsFilter);
        }
        return false;
    }

    private bool FilterSunSign(object obj)
    {
        if (obj is PersonViewModel personViewModel)
        {
            return personViewModel.SunSign.Contains(PersonsFilter);
        }
        return false;
    }

    private bool FilterChineseSign(object obj)
    {
        if (obj is PersonViewModel personViewModel)
        {
            return personViewModel.ChineseSign.Contains(PersonsFilter);
        }
        return false;
    }

    public Predicate<object> GetFilter()
    {
        switch (PersonsFilterPropertyName)
        {
            case "Name":
                return FilterName;
            case "Surname":
                return FilterSurname;
            case "Email":
                return FilterEmail;
            case "Age":
                return FilterAge;
            case "Date":
                return FilterDate;
            case "IsBirtday":
                return FilterIsBirthday;
            case "IsAdult":
                return FilterIsAdult;
            case "SunSign":
                return FilterSunSign;
            case "ChineseSign":
                return FilterChineseSign;
            default: return FilterName;
        }
    }

    public void UpdateFilter ()
    {
        PeopleCollectionView.Filter = GetFilter();
    }
}
