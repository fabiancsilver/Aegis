using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aegis.AddressBook.Domain
{
    public class ContactViewModel
    {
        [Key]
        public int ContactID { get; set; }

        [Required]
        [MaxLength(32)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(32)]
        public string LastName { get; set; }        
    }
}
