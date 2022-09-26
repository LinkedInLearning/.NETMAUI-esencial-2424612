namespace WisdomPetMedicine.Views;

public partial class VisitsPage : ContentPage
{
	public VisitsPage()
	{
		InitializeComponent();
	}

	private void Button_Clicked(object sender, EventArgs e)
	{
		var data = Resources["data"] as VisitsData;
		data.RemainingVisits = 1;
	}
}

public class VisitsData
{
	public int RemainingVisits { get; set; }
}