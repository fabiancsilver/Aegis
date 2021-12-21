using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aegis.AddressBook.Domain
{
    public class Address
    {
        [Key]
        public int AddressID { get; set; }

        [Required]
        public int ContactID { get; set; }

        [ForeignKey("ContactID")]
        public Contact Contact { get; set; }

        [Required]
        public int AddressTypeID { get; set; }

        [ForeignKey("AddressTypeID")]
        public AddressType AddressType { get; set; }

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
