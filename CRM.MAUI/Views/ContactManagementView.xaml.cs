using CRM.Library.Services;
using CRM.MAUI.ViewModels;

namespace CRM.MAUI.Views;

public partial class ContactManagementView : ContentPage
{
	public ContactManagementView()
	{
		InitializeComponent();
        BindingContext = new ContactManagementViewModel();
	}

    private void EditClicked(object sender, EventArgs e)
    {
        (BindingContext as ContactManagementViewModel).UpdateContact();
    }

    private void AddClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Contact");
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as ContactManagementViewModel).RefreshContacts();
    }

    private void ContentPage_NavigatedFrom(object sender, NavigatedFromEventArgs e)
    {

    }
}