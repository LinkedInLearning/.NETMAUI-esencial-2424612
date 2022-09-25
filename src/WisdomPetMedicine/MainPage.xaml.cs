using WisdomPetMedicine.DataAccess;

namespace WisdomPetMedicine;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

		var dbContext = new WpmDbContext();
		categories.Text = dbContext.Categories.Count().ToString();
		products.Text = dbContext.Categories.Count().ToString();
		clients.Text = dbContext.Clients.Count().ToString();
	}

	private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
	{
		await DisplayAlert("Mensaje", "Tap!", "Ok", "Cancelar");
	}
}