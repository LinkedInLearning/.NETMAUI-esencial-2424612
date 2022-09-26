using System.Collections.ObjectModel;
using System.ComponentModel;
using WisdomPetMedicine.DataAccess;

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

public class VisitsData : BindableObject
{
	private int remainingVisits;

	public int RemainingVisits
	{
		get { return remainingVisits; }
		set 
		{ 
			if (remainingVisits != value)
			{
                remainingVisits = value;
                RaisePropertyChanged();
            }
			
		}
	}

	private ObservableCollection<Client> clients;

	public ObservableCollection<Client> Clients
	{
		get { return clients; }
		set { 
			if (clients != value)
			{
                clients = value;
                RaisePropertyChanged();
            }
		}
	}

	private Client selectedClient;

	public Client SelectedClient
	{
		get { return selectedClient; }
		set { 
			if (selectedClient != value)
			{
                selectedClient = value;
                RaisePropertyChanged();
            }
		}
	}

	public VisitsData()
	{
		var db = new WpmDbContext();
		Clients = new ObservableCollection<Client>(db.Clients);
		PropertyChanged += VisitsData_PropertyChanged;
	}

	private async void VisitsData_PropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == nameof(SelectedClient))
		{
			var uri 
				= $"{nameof(VisitDetailsPage)}?id={SelectedClient.Id}";
            await Shell.Current.GoToAsync(uri);
		}
	}
}