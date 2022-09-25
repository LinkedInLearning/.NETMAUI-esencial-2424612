using WisdomPetMedicine.DataAccess;

namespace WisdomPetMedicine.Views;

public partial class ClientsPage : ContentPage
{
	public ClientsPage()
	{
		InitializeComponent();
        var dbContext = new WpmDbContext();
        foreach (var item in dbContext.Clients)
        {
            data.Children.Add(new Label() { Text = item.Name });
        }
    }
}