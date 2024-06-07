using CRM.MAUI.ViewModels;

namespace CRM.MAUI.Views;
[QueryProperty(nameof(ContactId), "contactId")]
public partial class ContactView : ContentPage
{
    public int ContactId { get; set; }
    public ContactView()
	{
		InitializeComponent();
        
	}

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as ContactViewModel).Add();
        Shell.Current.GoToAsync("//Management");
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Management");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ContactViewModel(ContactId);
    }
}