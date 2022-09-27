using WisdomPetMedicine.ViewModels;

namespace WisdomPetMedicine.Views;

public partial class ProductDetailsPage : ContentPage
{
	public ProductDetailsPage(ProductDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}