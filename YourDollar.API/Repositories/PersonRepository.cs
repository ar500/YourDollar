using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourDollar.API.Infrastructure.Context;
using YourDollar.API.Infrastructure.Entities;

namespace YourDollar.API.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly YourDollarContext _context;

        public PersonRepository(YourDollarContext context)
        {
            _context = context;
        }

        public IEnumerable<PersonEntity> GetPeople()
        {
            return _context.People
                .OrderBy(p => p.LastName)
                .ThenBy(p => p.LastName)
                .ToList();
        }

        public PersonEntity GetPersonById(Guid personId)
        {
            return _context.People
                .FirstOrDefault(p => p.PersonId == personId);
        }

        public void AddPerson(PersonEntity person)
        {
            _context.People.Add(person);
        }

        public void RemovePerson(PersonEntity person)
        {
            _context.People.Remove(person);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public bool PersonExists(Guid personId)
        {
            return _context.People.Any(p => p.PersonId == personId);
        }
    }
}
