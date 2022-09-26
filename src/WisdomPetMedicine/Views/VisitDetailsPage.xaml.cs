namespace WisdomPetMedicine.Views;

public partial class VisitDetailsPage : ContentPage, IQueryAttributable
{
	public VisitDetailsPage()
	{
		InitializeComponent();
	}

	public void ApplyQueryAttributes(IDictionary<string, object> query)
	{
		Title = $"Cliente: {query["id"]}";
	}
}