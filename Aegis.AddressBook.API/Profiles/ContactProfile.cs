using Aegis.AddressBook.API.Models;
using Aegis.AddressBook.Domain;
using AutoMapper;

namespace Aegis.AddressBook.API.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactViewModel>().ReverseMap();
        }
    }
}
