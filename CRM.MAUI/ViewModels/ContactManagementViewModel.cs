using CRM.Library.Services;
using CRM.Models;


namespace CRM.MAUI.ViewModels
{
    public class ContactManagementViewModel
    {
        public List<Models.Contact> Contacts
        {
            get
            {
                return ContactServiceProxy.Current?.Contacts?.ToList() ?? new List<Models.Contact>();
            }
        }
        public ContactManagementViewModel() { 
            
        }
    }
}
