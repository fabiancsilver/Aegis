using Aegis.AddressBook.Data;
using Aegis.AddressBook.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Aegis.AddressBook.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly AddressBookContext _dbContext;

        public ContactsController(AddressBookContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<ContactsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> Get()
        {
            var contacts = await _dbContext.Contacts.ToListAsync();

            return Ok(contacts);
        }

        // GET api/<ContactsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> Get(int id)
        {
            var contact = await _dbContext.Contacts.FindAsync(id);

            return Ok(contact);
        }

        // POST api/<ContactsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Contact contact)
        {
            await _dbContext.Contacts.AddAsync(contact);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        // PUT api/<ContactsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Contact contact)
        {
            var contactFromDB = await _dbContext.Contacts.FindAsync(id);

            contactFromDB.FirstName = contact.FirstName;
            contactFromDB.LastName = contact.LastName;            

            return Ok();
        }

        // DELETE api/<ContactsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var contact = await _dbContext.Contacts.FindAsync(id);
            _dbContext.Contacts.Remove(contact);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
