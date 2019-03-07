using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using TickToolCloud.Entities.Entity;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        public async Task<List<Folder>> OnGetAsync()
        {
            var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:6600/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                List<Folder> folders = new List<Folder>();

                HttpResponseMessage resp = await client.GetAsync("api/Folders");

                if (resp.IsSuccessStatusCode)
                {
                    var result = resp.Content.ReadAsStringAsync().Result;

                    folders = JsonConvert.DeserializeObject<List<Folder>>(result);
                }
                return folders;
        }
    }
}