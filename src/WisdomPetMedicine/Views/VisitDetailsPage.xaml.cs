using WisdomPetMedicine.ViewModels;

namespace WisdomPetMedicine.Views;
public partial class VisitDetailsPage : ContentPage
{
	public VisitDetailsPage(VisitDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}