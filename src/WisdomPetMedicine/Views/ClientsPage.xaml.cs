using WisdomPetMedicine.ViewModels;

namespace WisdomPetMedicine.Views;

public partial class ClientsPage : ContentPage
{
	public ClientsPage(ClientsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
}