using CRM.Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Contact = CRM.Models.Contact;

namespace CRM.MAUI.ViewModels
{
    public class ContactViewModel
    {
        public ICommand? EditCommand { get; private set; }
        public ICommand? DeleteCommand { get; private set; }

        public Contact? Contact;

        public string? Name
        {
            get
            {
                return Contact?.Name ?? string.Empty;
            }

            set
            {
                if(Contact != null)
                {
                    Contact.Name = value;
                }
            }
        }

        private void ExecuteEdit(ContactViewModel? p)
        {
            if(p?.Contact == null)
            {
                return;
            }
            Shell.Current.GoToAsync($"//Contact?contactId={p.Contact.Id}");
        }

        private void ExecuteDelete(int? id)
        {
            if (id == null)
            {
                return;
            }

            ContactServiceProxy.Current.Delete(id ?? 0);
        }

        public void Add()
        {
            ContactServiceProxy.Current.AddOrUpdate(Contact);
        }

        public void SetupCommands()
        {
            EditCommand = new Command(
               (c) => ExecuteEdit(c as ContactViewModel));
            DeleteCommand = new Command(
               (c) => ExecuteDelete((c as ContactViewModel)?.Contact?.Id));
        }

        public ContactViewModel()
        {
            Contact = new Contact();
            SetupCommands();
        }

        public ContactViewModel(int id)
        {
            Contact = ContactServiceProxy.Current?.Contacts?.FirstOrDefault(c => c.Id == id); 
            if(Contact == null)
            {
                Contact = new Contact();
            }
        }

        public ContactViewModel(Contact c)
        {
            Contact = c;
            SetupCommands();
        }

        public string? Display
        {
            get
            {
                return ToString();
            }
        }
    }
}
