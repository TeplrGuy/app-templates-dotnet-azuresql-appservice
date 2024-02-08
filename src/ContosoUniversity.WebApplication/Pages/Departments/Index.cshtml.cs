using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ContosoUniversity.WebApplication.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory client; 
        string URLAPI = Environment.GetEnvironmentVariable("URLAPI");
       

        public IndexModel(IHttpClientFactory client)
        {
            this.client = client;
        }

        public Models.APIViewModels.DepartmentResult Department { get; set; }

        public async Task OnGetAsync()
        {
            var request = HttpWebRequest.Create(URLAPI + "/api/Departments");
            var response = request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var responseContent = await streamReader.ReadToEndAsync();
                Department = JsonConvert.DeserializeObject<Models.APIViewModels.DepartmentResult>(responseContent);
            }
        }
    }
}
