using Services.BuisnessLogic.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using System.Linq.Expressions;
using DataAccess.Repositories.Base;

namespace Services.BuisnessLogic
{
    public class PersonService : IPersonService
    {
        private IPersonRepository personRepository = null;

        public PersonService(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        public void AddPerson(Person person)
        {
            personRepository.AddPerson(person);
        }

        public Person GetPerson(int id)
        {
            return personRepository.GetPerson(id);
        }

        public Person GetPerson(Expression<Func<Person, bool>> func)
        {
            return personRepository.GetPerson(func);
        }

        public IEnumerable<Person> GetPersons()
        {
            return personRepository.GetPersons();
        }

        public IEnumerable<Person> GetPersons(Expression<Func<Person, bool>> func)
        {
            return personRepository.GetPersons(func);
        }

        public IEnumerable<Person> SearchByString(Expression<Func<Person, bool>> func, string[] keywords)
        {
            return personRepository.SearchByString(func, keywords);
        }

        public void RemovePerson(int id)
        {
            personRepository.RemovePerson(id);
        }

        public void UpdatePerson(Person person)
        {
            personRepository.UpdatePerson(person);
        }
    }
}
