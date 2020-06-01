using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Mvc5HttpClientFactoryDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> About()
        {
            var client = this._httpClientFactory.CreateClient();

            var result = await client.GetAsync("https://blog.miniasp.com");
            ViewBag.Message = await result.Content.ReadAsStringAsync();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}