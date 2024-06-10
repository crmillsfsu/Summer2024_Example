using CRM.Library.Services;
using CRM.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace CRM.MAUI.ViewModels
{
    public class ContactManagementViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public List<ContactViewModel> Contacts
        {
            get
            {
                return ContactServiceProxy.Current?.Contacts?.Select(c => new ContactViewModel(c)).ToList() 
                    ?? new List<ContactViewModel>();
            }
        }

        public ContactViewModel SelectedContact { get; set; }
        public ContactManagementViewModel() { 
            
        }

        public void RefreshContacts() {
            NotifyPropertyChanged("Contacts");
        }

        public void UpdateContact()
        {
            if(SelectedContact?.Contact == null)
            {
                return;
            }
            Shell.Current.GoToAsync($"//Contact?contactId={SelectedContact.Contact.Id}");
            ContactServiceProxy.Current.AddOrUpdate(SelectedContact.Contact);
        }

        public void DeleteContact()
        {
            if (SelectedContact?.Contact == null)
            {
                return;
            }

            ContactServiceProxy.Current.Delete(SelectedContact.Contact.Id);
            RefreshContacts();
        }
    }
}
