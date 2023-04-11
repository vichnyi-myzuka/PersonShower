using PersonShower.Exceptions;

namespace PersonShower.Models;

using System;
[Serializable]
public class Person
{
    #region Fields

    private string _name;
    private string _surname;
    private string _email;
    private DateTime _date = DateTime.Now;
    #endregion

    #region Properties

    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }

    public string Surname
    {
        get
        {
            return _surname;
        }
        set
        {
            _surname = value;
        }
    }

    public string Email
    {
        get
        {
            return _email;
        }
        set
        {
            _email = value;
        }
    }
    
    public DateTime Date
    {
        get
        {
            return _date;
        }
        set
        {
            if (GetAge(value) < 0)
            {
                throw new FutureBirthException("You can't be born in future!");
            }

            if (GetAge(value) > 135)
            {
                throw new AlreadyDeadException("You're already dead, ghosts can't authorize here! Go away, ghostt!");
            }
            
            _date = value;
        }
    }
    #endregion

    #region Constructors

    public Person(string name, string surname, string email, DateTime date)
    {
        _name = name;
        _surname = surname;
        _email = email;
        _date = date;
    }

    public Person(string name, string surname, string email)
    {
        _name = name;
        _surname = surname;
        _email = email;
    }
    
    public Person(string name, string surname, DateTime date)
    {
        _name = name;
        _surname = surname;
        _date = date;
    }
    
    public Person() {}

    #endregion
    public string GetSunSign()
    {
        int day = Date.Day;
        int month = Date.Month;
            
        if((day>=21&&month==3)||(day<=20&&month==4))
            return "Aries";
        if((day>=24&&month==9)||(day<=23&&month==10))
            return "Libra";
        if((day>=21&&month==4)||(day<=21&&month==5))
            return "Taurus";
        if((day>=24&&month==10)||(day<=22&&month==11))
            return "Scorpio";
        if((day>=22&&month==5)||(day<=21&&month==6))
            return "Gemini";
        if((day>=23&&month==11)||(day<=21&&month==12))
            return "Sagittarius";
        if((day>=21&&month==6)||(day<=23&&month==7))
            return "Cancer";
        if((day>=22&&month==12)||(day<=20&&month==1))
            return "Capricorn";
        if((day>=24&&month==7)||(day<=23&&month==8))
            return "Leo";
        if((day>=21&&month==1)||(day<=19&&month==2))
            return "Aquarius";
        if((day>=24&&month==8)||(day<=23&&month==9))
            return "Virgo";
        if((day>=20&&month==2)||(day<=20&&month==3))
            return "Pisces";
        return "Something went wrong;";
    }
    
    public string GetChineseSign()
    {
        int year = Date.Year;
            
        if(year % 12 == 0) { return "Monkey";}
        if (year % 12 == 1) {return "Rooster";}
        if (year % 12 == 2) {return "Dog";}
        if (year % 12 == 3) {return "Pig";}
        if (year % 12 == 4) {return "Rat";}
        if (year % 12 == 5) {return "Ox";}
        if (year % 12 == 6) {return "Tiger";}
        if (year % 12 == 7) {return "Rabbit";}
        if (year % 12 == 8) {return "Dragon";}
        if (year % 12 == 9) {return "Snake";}
        if (year % 12 == 10) {return "Horse";}
        return "Sheep"; 
    }

    public int GetAge(DateTime date)
    {
        var today = DateTime.Today; 
        var age = today.Year - Date.Year;
        if (Date.Date > today.AddYears(-age)) age--;
        return age;
    }
}    
