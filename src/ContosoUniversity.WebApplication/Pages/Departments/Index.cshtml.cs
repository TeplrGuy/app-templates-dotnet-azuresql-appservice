using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace ContosoUniversity.WebApplication.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory client;

        public IndexModel(IHttpClientFactory client)
        {
            this.client = client;
        }

        public Models.APIViewModels.DepartmentResult Department { get; set; }

        public async Task OnGetAsync()
        {
             using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(client.CreateClient().BaseAddress+"/api/Departments");
                   Department = JsonConvert.DeserializeObject<Models.APIViewModels.DepartmentResult>(response);
            }
        }
    }
}