using Aegis.AddressBook.Data;
using Aegis.AddressBook.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Aegis.AddressBook.API.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly AddressBookContext _dbContext;

        public AddressesController(AddressBookContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<AddressesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> Get()
        {
            var addresses = await _dbContext.Addresses.ToListAsync();

            return Ok(addresses);
        }

        // GET api/<AddressesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> Get(int id)
        {
            var address = await _dbContext.Addresses.FindAsync(id);

            return Ok(address);
        }

        // POST api/<AddressesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Address address)
        {
            await _dbContext.Addresses.AddAsync(address);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        // PUT api/<AddressesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Address address)
        {
            var addressFromDB = await _dbContext.Addresses.FindAsync(id);

            addressFromDB.Addr1 = address.Addr1;
            addressFromDB.Addr2 = address.Addr2;
            addressFromDB.City = address.City;
            addressFromDB.State = address.State;
            addressFromDB.Country = address.Country;

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        // DELETE api/<AddressesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var address = await _dbContext.Addresses.FindAsync(id);
            _dbContext.Addresses.Remove(address);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
