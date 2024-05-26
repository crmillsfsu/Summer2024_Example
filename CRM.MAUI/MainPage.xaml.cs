using CRM.MAUI.ViewModels;

namespace CRM.MAUI
{
    public partial class MainPage : ContentPage
    {

        

        public MainPage()
        {

            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        private void Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Management");
        }
    }

}
