using Microsoft.Maui.Controls.Shapes;
using WisdomPetMedicine.DataAccess;

namespace WisdomPetMedicine;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
	{
		(sender as Rectangle)?.ScaleTo(2);
		(sender as Rectangle)?.TranslateTo(200, 200);
    }
}