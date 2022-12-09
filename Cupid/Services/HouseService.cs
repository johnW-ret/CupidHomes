using Cupid.Data;
using Cupid.Models;
using Cupid.Models.Data;
using System.Diagnostics;

namespace Cupid.Services;

public record HousesResponse(List<HouseDataObject>? Value, string Message, bool Error)
    : TListResponse<HouseDataObject>(Value, Message, Error);
public record HouseStatsResponse(List<HouseStat>? Value, string Message, bool Error)
    : TListResponse<HouseStat>(Value, Message, Error);

public class HouseService
{
    public HouseService(IHttpClientFactory httpClientFactory)
    {
        client = httpClientFactory.CreateClient("Api");
    }

    private readonly HttpClient client;
    private readonly string ApiName = "house";

    public async ValueTask<HouseStatsResponse> GetHouseStats()
    {
        try
        {
            var httpResponse = await client.GetAsync($"{ApiName}/stats");

            if (!httpResponse.IsSuccessStatusCode)
            {
                return new(null, $"{(int)httpResponse.StatusCode} {httpResponse.ReasonPhrase}", true);
            }

            var created = await httpResponse.Content.ReadFromJsonAsync<List<HouseStat>>();

            return new(created, httpResponse.StatusCode.ToString(), false);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            return new(null, "Error sending content to server.", true);
        }
    }

    public async ValueTask<HousesResponse> GetHouses()
    {
        try
        {
            var httpResponse = await client.GetAsync(ApiName);

            if (!httpResponse.IsSuccessStatusCode)
            {
                return new(null, $"{(int)httpResponse.StatusCode} {httpResponse.ReasonPhrase}", true);
            }

            var created = await httpResponse.Content.ReadFromJsonAsync<List<HouseDataObject>>();

            return new(created, httpResponse.StatusCode.ToString(), false);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            return new(null, "Error sending content to server.", true);
        }
    }
}
