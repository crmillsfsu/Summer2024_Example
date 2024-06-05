using System.Windows.Input;

namespace CRM.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        private string? phoneNumber;
        public string? PhoneNumber { 
            get
            {
                return phoneNumber;
            }

            set
            {
                phoneNumber = value?.Replace("(", "")?.Replace(")", "") ?? null;               
            }
        
        }
        public string? EmailAddress { get; set; }



        public Contact()
        {
   
        }

        public override string ToString()
        {
            return $"[{Id}] {Name} - {PhoneNumber}";
        }
    }
}
