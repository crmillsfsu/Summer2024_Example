using CRM.Library.Services;
using CRM.Models;

namespace Summer2024_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var contactSvc = ContactServiceProxy.Current;

            contactSvc.AddOrUpdate(
            new Contact {
                Name = "John Smith",
                PhoneNumber = "5555555",
                EmailAddress = "test@test.com"
            });

            var contact = new Contact
            {
                Name = "Jane Smith",
                PhoneNumber = "8888888",
                EmailAddress = "test2@test.com"
            };

            Console.WriteLine("Before the save:");
            Console.WriteLine(contact);

            contact = contactSvc.AddOrUpdate(contact);

            Console.WriteLine("Before the save:");
            Console.WriteLine(contact);

            contact.Name = "Jane Something Smith";
            contactSvc.AddOrUpdate(contact);

            contactSvc?.Contacts?.ToList()?.ForEach(Console.WriteLine);


            Console.WriteLine("After delete!!!!");

            contactSvc.Delete(1);

            contactSvc?.Contacts?.ToList()?.ForEach(Console.WriteLine);
        }
    }
}
