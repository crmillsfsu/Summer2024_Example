using CRM.MAUI.ViewModels;

namespace CRM.MAUI.Views;

public partial class ContactManagementView : ContentPage
{
	public ContactManagementView()
	{
		InitializeComponent();
        BindingContext = new ContactManagementViewModel();
	}

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
}