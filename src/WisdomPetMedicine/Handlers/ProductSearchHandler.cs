using WisdomPetMedicine.DataAccess;
using WisdomPetMedicine.Views;

namespace WisdomPetMedicine.Handlers;
public class ProductSearchHandler : SearchHandler
{
	WpmDbContext db;
	public ProductSearchHandler()
	{
		db = new WpmDbContext();
	}

	protected override void OnQueryChanged(string oldValue, 
		string newValue)
	{
		if (string.IsNullOrWhiteSpace(newValue))
		{
			ItemsSource = null;
			return;
		}

		var results = db
			.Products
			.Where(p => 
				p.Name.ToLowerInvariant()
				.Contains(newValue.ToLowerInvariant())).ToList();
		ItemsSource = results;
	}

	protected async override void OnItemSelected(object item)
	{
		await Shell.Current
			.GoToAsync($"{nameof(ProductDetailsPage)}?id={((Product)item).Id}");
	}
}