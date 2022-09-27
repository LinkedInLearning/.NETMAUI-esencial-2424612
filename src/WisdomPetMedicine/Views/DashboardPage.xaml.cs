using WisdomPetMedicine.ViewModels;

namespace WisdomPetMedicine.Views;

public partial class DashboardPage : ContentPage
{
	public DashboardPage(DashboardViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}