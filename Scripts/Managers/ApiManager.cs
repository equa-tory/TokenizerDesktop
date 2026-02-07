using System.Net.Http;
using System.Threading.Tasks;

namespace TicketApp
{

    public static class ApiClient
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<string> GetTicketTypes()
        {
            var url = "https://equatory.ddns.net:8000/ticket/types/";
            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}