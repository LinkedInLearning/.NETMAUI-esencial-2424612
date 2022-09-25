using WisdomPetMedicine.DataAccess;

namespace WisdomPetMedicine;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
	{
		await DisplayAlert("Mensaje", "Tap!", "Ok", "Cancelar");
	}
}