using WisdomPetMedicine.ViewModels;

namespace WisdomPetMedicine.Views;

public partial class SyncPage : ContentPage
{
	public SyncPage(SyncViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}