using Cupid.Data;
using Cupid.Models;
using Cupid.Models.Data;
using System.Diagnostics;

namespace Cupid.Services;

public record CustomerResponse(CustomerDataObject? Value, string Message, bool Error)
    : TResponse<CustomerDataObject>(Value, Message, Error);

public record CustomerListResponse(List<CustomerDataObject>? Value, string Message, bool Error)
    : TListResponse<CustomerDataObject>(Value, Message, Error);

public class CustomerService
{
    public CustomerService(IHttpClientFactory httpClientFactory)
    {
        client = httpClientFactory.CreateClient("Api");
    }

    private readonly HttpClient client;
    private readonly string ApiName = "customer";

    public async ValueTask<CustomerListResponse> GetCustomers()
    {
        try
        {
            var httpResponse = await client.GetAsync(ApiName);

            if (!httpResponse.IsSuccessStatusCode)
            {
                return new(null, $"{(int)httpResponse.StatusCode} {httpResponse.ReasonPhrase}", true);
            }

            var created = await httpResponse.Content.ReadFromJsonAsync<List<CustomerDataObject>>();

            return new(created, httpResponse.StatusCode.ToString(), false);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            return new(null, "Error sending content to server.", true);
        }
    }

    public async ValueTask<CustomerResponse> PostCustomer(CustomerDataObject customerDataObject)
    {
        try
        {
            var httpResponse = await client.PostAsJsonAsync($"{ApiName}", customerDataObject);

            if (!httpResponse.IsSuccessStatusCode)
            {
                return new(null, $"{(int)httpResponse.StatusCode} {httpResponse.ReasonPhrase}", true);
            }

            var created = await httpResponse.Content.ReadFromJsonAsync<CustomerDataObject>();

            return new(created, httpResponse.StatusCode.ToString(), false);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            return new(null, "Error sending content to server.", true);
        }
    }
}
