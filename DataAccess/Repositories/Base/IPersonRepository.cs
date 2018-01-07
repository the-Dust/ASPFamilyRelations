using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Base
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetPersons();

        IEnumerable<Person> GetPersons(Expression<Func<Person, bool>> func);

        IEnumerable<Person> SearchByString(Expression<Func<Person, bool>> func, string[] keywords);

        Person GetPerson(int id);

        Person GetPerson(Expression<Func<Person, bool>> func);

        void RemovePerson(int id);

        void UpdatePerson(Person person);

        void AddPerson(Person person);
    }
}
