using WisdomPetMedicine.ViewModels;

namespace WisdomPetMedicine.Views;

public partial class VisitsPage : ContentPage
{
	public VisitsPage(VisitsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}