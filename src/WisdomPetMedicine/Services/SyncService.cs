using System.Net.Http.Json;
using WisdomPetMedicine.Models;

namespace WisdomPetMedicine.Services;
public class SyncService
{
    private HttpClient client;
    public SyncService()
    {
        client = new HttpClient();
    }
    public async Task<bool> SendDataAsync(IEnumerable<Sale> sales, string accessToken)
    {
        var uri = "https://wpmapi.azurewebsites.net/sales";
        var body = new
        {
            data = sales
        };
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
        var result = await client.PostAsJsonAsync(uri, body);
        return result.IsSuccessStatusCode;
    }
}