using DataAccess.Entities;
using DataAccess.Repositories.Base;
using NinjaNye.SearchExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public class PersonRepository : AbstractRepository, IPersonRepository
    {
        public void AddPerson(Person person)
        {
            context.Persons.Add(person);
            context.SaveChanges();
        }

        public Person GetPerson(int id)
        {
            return context.Persons.FirstOrDefault(x => x.Id == id);
        }

        public Person GetPerson(Expression<Func<Person, bool>> func)
        {
            return context.Persons.FirstOrDefault(func);
        }

        public IEnumerable<Person> GetPersons()
        {
            return context.Persons;
        }

        public IEnumerable<Person> GetPersons(Expression<Func<Person, bool>> func)
        {
            return context.Persons.Where(func);
        }

        public IEnumerable<Person> SearchByString(Expression<Func<Person, bool>> func, string[] keywords)
        {
            if (keywords.Length < 6)
                throw new ArgumentException();

            return context.Persons.Where(func)
                .Search(x => x.Surname).Containing(keywords[0])
                .Search(x => x.Name).Containing(keywords[1])
                .Search(x => x.Patronymic).Containing(keywords[2])
                .Search(x => x.Country).Containing(keywords[3])
                .Search(x => x.City).Containing(keywords[4])
                .Search(x => x.Street).Containing(keywords[5]);
        }

        public void RemovePerson(int id)
        {
            Person person = GetPerson(id);
            context.Persons.Remove(person);
            context.SaveChanges();
        }

        public void UpdatePerson(Person person)
        {
            Person oldPerson = GetPerson(person.Id);

            oldPerson.BirthDate = person.BirthDate;
            oldPerson.City = person.City;
            oldPerson.Country = person.Country;
            oldPerson.Name = person.Name;
            oldPerson.Patronymic = person.Patronymic;
            oldPerson.Street = person.Street;
            oldPerson.Surname = person.Surname;

            context.SaveChanges();
        }


    }
}
