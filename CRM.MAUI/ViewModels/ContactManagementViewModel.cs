﻿using CRM.Library.Services;
using CRM.Models;


namespace CRM.MAUI.ViewModels
{
    public class ContactManagementViewModel
    {
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

        public void UpdateContact()
        {
            if(SelectedContact.Contact == null)
            {
                return;
            }

            ContactServiceProxy.Current.AddOrUpdate(SelectedContact.Contact);
        }
    }
}
