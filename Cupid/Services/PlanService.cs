using Cupid.Data;
using Cupid.Models;
using Cupid.Models.Data;
using System.Diagnostics;

namespace Cupid.Services;

public record PlanResponse(List<PlanDataObject>? Value, string Message, bool Error)
    : TListResponse<PlanDataObject>(Value, Message, Error);

public class PlanService
{
    public PlanService(IHttpClientFactory httpClientFactory)
    {
        client = httpClientFactory.CreateClient("Api");
    }

    private readonly HttpClient client;
    private readonly string ApiName = "plan";

    public async ValueTask<PlanResponse> GetPlans()
    {
        try
        {
            var httpResponse = await client.GetAsync($"{ApiName}");

            if (!httpResponse.IsSuccessStatusCode)
            {
                return new(null, $"{(int)httpResponse.StatusCode} {httpResponse.ReasonPhrase}", true);
            }

            var created = await httpResponse.Content.ReadFromJsonAsync<List<PlanDataObject>>();

            return new(created, httpResponse.StatusCode.ToString(), false);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            return new(null, "Error sending content to server.", true);
        }
    }
}
