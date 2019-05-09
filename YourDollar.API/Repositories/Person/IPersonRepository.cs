using System;
using System.Collections.Generic;
using YourDollar.API.Infrastructure.Entities;

namespace YourDollar.API.Repositories.Person
{
    public interface IPersonRepository
    {
        IEnumerable<PersonEntity> GetPeople();
        PersonEntity GetPersonById(Guid personId);
        void AddPerson(PersonEntity person);
        void RemovePerson(PersonEntity person);
        bool SaveChanges();
        bool PersonExists(Guid personId);
    }
}