using Aegis.AddressBook.Data;
using Aegis.AddressBook.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aegis.AddressBook.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressTypesController : ControllerBase
    {
        private readonly AddressBookContext _dbContext;

        public AddressTypesController(AddressBookContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<AddressTypesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressType>>> Get()
        {
            var addressTypes = await _dbContext.AddressTypes.ToListAsync();

            return Ok(addressTypes);
        }

        // GET api/<AddressTypesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddressType>> Get(int id)
        {
            var addressType = await _dbContext.AddressTypes.FindAsync(id);

            return Ok(addressType);
        }

        // POST api/<AddressTypesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AddressType addressType)
        {
            await _dbContext.AddressTypes.AddAsync(addressType);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        // PUT api/<AddressTypesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] AddressType addressType)
        {
            //ToDo: Implement map library
            var addressTypeFromDB = await _dbContext.AddressTypes.FindAsync(id);
            addressTypeFromDB.Name = addressType.Name;
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        // DELETE api/<AddressTypesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var addressType = await _dbContext.AddressTypes.FindAsync(id);
            _dbContext.AddressTypes.Remove(addressType);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
