using BizzLand.Models;
using BizzLand.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BizzLand.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();

            var categories = await client.GetFromJsonAsync<List<Category>>("https://localhost:7269/api/Category");
            var sliders = await client.GetFromJsonAsync<List<Slider>>("https://localhost:7269/api/Sliders");
            var services = await client.GetFromJsonAsync<List<Service>>("https://localhost:7269/api/Services");
            var members = await client.GetFromJsonAsync<List<Member>>("https://localhost:7269/api/members");
            var port = await client.GetFromJsonAsync<List<Portfolio>>("https://localhost:7269/api/Portfolio");
            var prof = await client.GetFromJsonAsync<List<Profession>>("https://localhost:7269/api/Professions");


            HomeViewModel viewModel = new HomeViewModel
            {
                Categories = categories,
                Sliders = sliders,
                Services = services,
                Members = members,
                Portfolios = port,
                Professions = prof
            };

            return View(viewModel);
        }

        

        
    }
}