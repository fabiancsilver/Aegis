using Aegis.AddressBook.Application.Data;
using Aegis.AddressBook.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aegis.AddressBook.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressTypesController : ControllerBase
    {
        public IAddressTypeRepository _addressTypeRepository;

        public AddressTypesController(IAddressTypeRepository addressTypeRepository)
        {
            _addressTypeRepository = addressTypeRepository;
        }

        // GET: api/<AddressTypesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressType>>> Get()
        {
            var addressTypes = await _addressTypeRepository.GetAll();

            return Ok(addressTypes);
        }

        // GET api/<AddressTypesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddressType>> Get(int id)
        {
            var addressType = await _addressTypeRepository.GetById(id);

            return Ok(addressType);
        }

        // POST api/<AddressTypesController>
        [HttpPost]
        public async Task<ActionResult<AddressType>> Post([FromBody] AddressType addressType)
        {
            _addressTypeRepository.Create(addressType);
            await _addressTypeRepository.SaveChanges();

            return Ok(addressType);
        }

        // PUT api/<AddressTypesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] AddressType addressType)
        {
            _addressTypeRepository.Update(id, addressType);
            await _addressTypeRepository.SaveChanges();

            return Ok();
        }

        // DELETE api/<AddressTypesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _addressTypeRepository.Remove(id);
            await _addressTypeRepository.SaveChanges();

            return Ok();
        }
    }
}
