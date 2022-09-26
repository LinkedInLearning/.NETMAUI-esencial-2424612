using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using WisdomPetMedicine.DataAccess;
using WisdomPetMedicine.Services;
using WisdomPetMedicine.Views;

namespace WisdomPetMedicine.ViewModels;

public partial class VisitsViewModel : ViewModelBase
{
    private readonly INavigationService navigationService;

    [ObservableProperty]
    private int remainingVisits;

    [ObservableProperty]
    private ObservableCollection<Client> clients;

    [ObservableProperty]
    private Client selectedClient;
    
    public VisitsViewModel(INavigationService navigationService)
    {
        var db = new WpmDbContext();
        Clients = new ObservableCollection<Client>(db.Clients);
        PropertyChanged += VisitsData_PropertyChanged;
        this.navigationService = navigationService;
    }

    private async void VisitsData_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(SelectedClient))
        {
            var uri
                = $"{nameof(VisitDetailsPage)}?id={SelectedClient.Id}";
            await navigationService.GoToAsync(uri);
        }
    }
}