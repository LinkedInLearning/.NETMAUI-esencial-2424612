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
	public VisitsData()
	{
		var db = new WpmDbContext();
		Clients = new ObservableCollection<Client>(db.Clients);
	}
}