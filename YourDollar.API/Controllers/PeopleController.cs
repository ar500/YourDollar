using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YourDollar.API.DTOs.PersonDTOs;

namespace YourDollar.API.Controllers
{
    [Route("api/people")]
    [ApiController]
    public class PeopleController : ControllerBase
    {

        // GET: api/people
        [HttpGet]
        public IActionResult GetPeople()
        {
            var peopleFromDataStore = DummyDataStore.Current.People;

            return Ok(peopleFromDataStore);
        }

        // GET: api/people/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult GetPersonById(Guid id)
        {
            var returnPerson = DummyDataStore.Current.People
                .FirstOrDefault(p => p.PersonId == id);

            if (!PersonExists(id))
            {
                return NotFound();
            }

            return Ok(returnPerson);
        }

        // POST: api/people
        [HttpPost]
        public IActionResult AddPerson([FromBody] PersonForAddDto person)
        {
            if (person == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newPersonId = Guid.NewGuid();

            DummyDataStore.Current.People.Add(new PersonDto()
            {
                PersonId = new Guid(),
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email,
                PhoneNumber = person.PhoneNumber
            });

            return NoContent();
        }

        // PUT: api/People/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private bool PersonExists(Guid personId)
        {
            var resultPerson = DummyDataStore.Current.People
                .FirstOrDefault(p => p.PersonId == personId);

            return resultPerson != null;
        }
    }
}
