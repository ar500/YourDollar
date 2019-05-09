using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using YourDollar.API.DTOs.PersonDTOs;
using YourDollar.API.Infrastructure.Entities;
using YourDollar.API.Repositories.Person;

namespace YourDollar.API.Controllers
{
    [Route("api/people")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;

        public PeopleController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        // GET: api/people
        [HttpGet]
        public IActionResult GetPeople()
        {
            var peopleFromRepo = _personRepository.GetPeople();

            var mappedPeople = Mapper.Map<IEnumerable<PersonDto>>(peopleFromRepo);

            return Ok(mappedPeople);
        }

        // GET: api/people/5
        [HttpGet("{id}", Name = "GetPersonById")]
        public IActionResult GetPersonById(Guid id)
        {
            if (!_personRepository.PersonExists(id))
            {
                return NotFound();
            }

            var person = _personRepository.GetPersonById(id);

            var mappedPerson = Mapper.Map<PersonDto>(person);

            return Ok(mappedPerson);
        }

        // POST: api/people
        [HttpPost]
        public IActionResult AddPerson([FromBody] PersonForAddOrUpdateDto person)
        {
            if (person == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mappedPerson = Mapper.Map<PersonEntity>(person);

            _personRepository.AddPerson(mappedPerson);

            if (!_personRepository.SaveChanges())
            {
                return StatusCode(500, "The server was unable to handle your request.");
            }

            var createdPersonForReturn = Mapper.Map<PersonDto>(mappedPerson);

            return CreatedAtRoute("GetPersonById", new
                { id = createdPersonForReturn.PersonId }, createdPersonForReturn);
        }

        // PATCH: api/People/5
        [HttpPatch("{id}")]
        public IActionResult UpdatePerson(Guid id, [FromBody] JsonPatchDocument<PersonForAddOrUpdateDto> patchDocument)
        {
            if (patchDocument == null)
            {
                return BadRequest();
            }

            var personToUpdate = _personRepository.GetPersonById(id);

            if (personToUpdate == null)
            {
                return NotFound();
            }

            var personToPatch = Mapper.Map<PersonForAddOrUpdateDto>(personToUpdate);

            patchDocument.ApplyTo(personToPatch, ModelState);

            TryValidateModel(personToPatch);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Mapper.Map(personToPatch, personToUpdate);

            if (!_personRepository.SaveChanges())
            {
                return StatusCode(500, "The server was unable to handle your request.");
            }

            return CreatedAtRoute("GetPersonById", new
                {id = personToUpdate.PersonId}, personToUpdate);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult DeletePerson(Guid id)
        {
            var personToDelete = _personRepository.GetPersonById(id);
            if (personToDelete == null)
            {
                return BadRequest();
            }

            _personRepository.RemovePerson(personToDelete);

            if (!_personRepository.SaveChanges())
            {
                return StatusCode(500, "The server was unable to handle your request.");
            }

            return NoContent();
        }
    }
}
