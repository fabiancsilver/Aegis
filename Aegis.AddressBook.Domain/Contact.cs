using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aegis.AddressBook.Domain
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }

        [Required]
        [MaxLength(32)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(32)]
        public string LastName { get; set; }

        public IEnumerable<Address> Addresses { get; set; }
    }
}
