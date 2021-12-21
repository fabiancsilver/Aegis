using Aegis.AddressBook.API.Models;
using Aegis.AddressBook.Domain;
using AutoMapper;

namespace Aegis.AddressBook.API.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressViewModel>().ReverseMap();
        }
    }
}
