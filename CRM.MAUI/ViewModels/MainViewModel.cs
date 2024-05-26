using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.MAUI.ViewModels
{
    public class MainViewModel
    {

        private string title;
        public string Title
        {
            set
            {
                this.title = value;
            }

            get
            {
                return this.title;
            }

        }

        public MainViewModel()
        {
            Title = "Some Different String!";
        }
    }
}
