using System;
using PersonShower.Models;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Faker;


namespace PersonShower.Tools;

public class PersonsLoader
{
    public static string path = @"C:\Users\Ярослав\RiderProjects\PersonShower\PersonShower\person.bin";
    public static Person[] LoadPeople()
    {
        Person[] people = new Person[]{};

        if (File.Exists(path)) {
            using (var stream = new FileStream(path, FileMode.Open))
            {
                var formatter = new BinaryFormatter();
                people = (Person[])formatter.Deserialize(stream);
            }
        } else
        {
            people = GeneratePeople();
            SavePeople(people);
        }
        
        return people;
    }

    public static void SavePeople(Person[] people)
    {
        using (var stream = new FileStream(path, FileMode.Create))
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, people);
        }
    }

    public static Person[] GeneratePeople()
    {
        Person[] people = new Person[50];
        Random random = new Random();
        for (int i = 0; i < 50; i++)
        {
            string name = Faker.Name.First();
            string lastname = Faker.Name.Last();
            string email = Faker.Internet.Email(name);
            DateTime date = DateTime.Now.AddDays(-10000).AddDays(random.Next(10000));
            Person newPerson = new Person(name, lastname, email, date);
            people[i] = newPerson;
        }

        return people;
    }
}