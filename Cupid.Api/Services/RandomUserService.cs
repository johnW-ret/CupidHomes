using Cupid.Api.Data;
using Cupid.Models.Data;
using System.Diagnostics;
using System.Web;

namespace Cupid.Api.Services;

public class RandomUserService
{
    public RandomUserService(IHttpClientFactory httpClientFactory)
    {
        client = httpClientFactory.CreateClient("RandomApi");
    }

    private readonly HttpClient client;
    private readonly string ApiName = "users";

    public async Task<List<RandomUser>> GetRandomUsers(int size)
    {
        try
        {
            // Add the query parameters using expression trees
            var query = HttpUtility.ParseQueryString(string.Empty);
            query.Add(nameof(size), size.ToString());

            string url = $"{ApiName}?{query}";

            var httpResponse = await client.GetAsync(url);

            if (!httpResponse.IsSuccessStatusCode)
            {
                Console.Error.WriteLine($"GET request to URL {url} failed with {(int)httpResponse.StatusCode} {httpResponse.ReasonPhrase}");
                return new();
            }

            var created = await httpResponse.Content.ReadFromJsonAsync<List<RandomUser>>();

            return created ?? new();
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            return new();
        }
    }
}
