using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Aegis.AddressBook.API.Models
{
    public class AddressViewModel
    {
        [Key]
        public int AddressID { get; set; }

        [Required]
        public int ContactID { get; set; }       

        [Required]
        public int AddressTypeID { get; set; }

        
        [Required]
        [MaxLength(128)]
        public string Addr1 { get; set; }

        [MaxLength(128)]
        public string Addr2 { get; set; }

        public string ZipCode { get; set; }

        [MaxLength(32)]
        public string City { get; set; }

        [MaxLength(32)]
        public string State { get; set; }

        [MaxLength(32)]
        public string Country { get; set; }
    }
}
