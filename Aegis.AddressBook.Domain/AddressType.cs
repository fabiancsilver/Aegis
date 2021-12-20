using System.ComponentModel.DataAnnotations;

namespace Aegis.AddressBook.Domain
{
    public class AddressType
    {
        [Key]
        public int AddressTypeID { get; set; }

        [MaxLength(32)]
        public string Name { get; set; }
    }
}
