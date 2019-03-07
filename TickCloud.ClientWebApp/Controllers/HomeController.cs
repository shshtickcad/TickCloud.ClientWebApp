using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Newtonsoft.Json;
using TickCloud.ClientWebApp.Config;
using TickCloud.ClientWebApp.Models;

namespace TickCloud.ClientWebApp.Controllers
{
    public class HomeController : Controller
    {
        Helper _api = new Helper();

        public async Task<IActionResult> Index()
        {
            //List<Folder> folders = new List<Folder>();

            HttpClient client = _api.Initial();
            var resp = await client.GetAsync("api/Folders");
            var result = await resp.Content.ReadAsAsync<IEnumerable<Folder>>();
            //folders = JsonConvert.DeserializeObject<List<Folder>>(result);

            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new Models.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
