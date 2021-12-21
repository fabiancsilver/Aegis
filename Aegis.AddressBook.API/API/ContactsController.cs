using Aegis.AddressBook.Application.Data;
using Aegis.AddressBook.Domain;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aegis.AddressBook.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;


        public ContactsController(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository ?? throw new System.ArgumentNullException(nameof(contactRepository));
            _mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
        }

        // GET: api/<ContactsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> Get()
        {
            var contacts = await _contactRepository.GetAll();

            return Ok(contacts);
        }

        // GET api/<ContactsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> Get(int id)
        {
            var contact = await _contactRepository.GetById(id);

            return Ok(contact);
        }

        // POST api/<ContactsController>
        [HttpPost]
        public async Task<ActionResult<Contact>> Post([FromBody] Contact contact)
        {
            _contactRepository.Create(contact);
            await _contactRepository.SaveChanges();

            return Ok(contact);
        }

        // PUT api/<ContactsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ContactViewModel contactViewModel)
        {
            var contactFromDB = await _contactRepository.GetById(id);
            
            _mapper.Map(contactViewModel, contactFromDB);

            
            await _contactRepository.SaveChanges();

            return Ok();
        }

        // DELETE api/<ContactsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _contactRepository.Remove(id);
            await _contactRepository.SaveChanges();

            return Ok();
        }
    }
}
