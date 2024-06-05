using CRM.Models;
using System.Collections.ObjectModel;


namespace CRM.Library.Services
{
    public class ContactServiceProxy
    {

        private ContactServiceProxy() {
            contacts = new List<Contact> { 
                new Contact{Name = "John Smith", Id=1}
                , new Contact {Name = "Jane Doe", Id=2}
            
            };
        }

        private static ContactServiceProxy? instance;
        private static object instanceLock = new object();
        public static ContactServiceProxy Current
        {
            get
            {
                lock(instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ContactServiceProxy();
                    }
                }

                return instance;
            }
        }

        private List<Contact>? contacts;
        public ReadOnlyCollection<Contact>? Contacts
        {
            get
            {
                return contacts?.AsReadOnly();
            }
        }

        //======== functionality
        public int LastId
        {
            get
            {
                if (contacts?.Any() ?? false)
                {
                    return contacts?.Select(c => c.Id)?.Max() ?? 0;
                }
                return 0;
            }
        }
        public Contact? AddOrUpdate(Contact contact)
        {
            if(contacts == null)
            {
                return null;
            }

            var isAdd = false;

            if(contact.Id == 0)
            {
                contact.Id = LastId + 1;
                isAdd = true;
            }

            if(isAdd)
            {
                contacts.Add(contact);
            }

            return contact;
        }
    
        public void Delete(int id)
        {
            if (contacts == null)
            {
                return;
            }
            var contactToDelete = contacts.FirstOrDefault(c => c.Id == id);
            
            if(contactToDelete != null)
            {
                contacts.Remove(contactToDelete);
            }
        }
    }
}
