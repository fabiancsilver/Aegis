using Aegis.AddressBook.API.Models;
using Aegis.AddressBook.Application.Data;
using Aegis.AddressBook.Domain;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Aegis.AddressBook.API.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;        

        public AddressesController(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository ?? throw new System.ArgumentNullException(nameof(addressRepository));
            _mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
        }

        // GET: api/<AddressesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> Get()
        {
            var addresses = await _addressRepository.GetAll();

            return Ok(addresses);
        }

        // GET: api/<AddressesController>
        [HttpGet("ByContact/{contactID}")]
        public async Task<ActionResult<IEnumerable<Address>>> GetByContact(int contactID)
        {
            var addresses = await _addressRepository.GetByContact(contactID);

            return Ok(addresses);
        }

        // GET: api/<AddressesController>
        [HttpGet("Last10")]
        public async Task<ActionResult<IEnumerable<Address>>> GetLast10()
        {
            var addresses = await _addressRepository.GetLast10();

            return Ok(addresses);
        }

        // GET api/<AddressesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> Get(int id)
        {
            var address = await _addressRepository.GetById(id);

            return Ok(address);
        }

        // POST api/<AddressesController>
        [HttpPost]
        public async Task<ActionResult<Address>> Post([FromBody] Address address)
        {
            _addressRepository.Create(address);
            await _addressRepository.SaveChanges();

            return Ok(address);
        }

        // PUT api/<AddressesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] AddressViewModel addressViewModel)
        {
            var addressFromDB = await _addressRepository.GetById(id);
            _mapper.Map(addressViewModel, addressFromDB);

            await _addressRepository.SaveChanges();

            return Ok();
        }

        // DELETE api/<AddressesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _addressRepository.Remove(id);
            await _addressRepository.SaveChanges();

            return Ok();
        }
    }
}
