using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using WisdomPetMedicine.DataAccess;

namespace WisdomPetMedicine.ViewModels;
public partial class ClientsViewModel : ViewModelBase
{
    [ObservableProperty]
    ObservableCollection<Client> clients;

    [ObservableProperty]
    Client selectedClient;

    public ClientsViewModel()
    {
        var db = new WpmDbContext();
        Clients = new ObservableCollection<Client>(db.Clients);
    }
}