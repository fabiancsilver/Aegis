using Aegis.AddressBook.Domain;
using System.Linq;

namespace Aegis.AddressBook.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AddressBookContext context)
        {
            context.Database.EnsureCreated();


            if (!context.AddressTypes.Any())
            {
                context.AddressTypes.Add(new AddressType { Name = "Home" });
                context.AddressTypes.Add(new AddressType { Name = "Work" });
                context.AddressTypes.Add(new AddressType { Name = "Other" });

                context.SaveChanges();
            }
        }
    }
}
