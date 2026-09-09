using ICE4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ICE4.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;
        public HomeController(IHttpClientFactory httpClientFactory) 
        {
            _httpClient=httpClientFactory.CreateClient("StudentApi");
            
        }

        public async Task<IActionResult> Index()
        {
            var students = await _httpClient.GetFromJsonAsync<List<Student>>("api/students");

            return View(students ?? new List<Student>());
        }

        public async Task<IActionResult> Studentt(int d)
        {
            var response = await _httpClient.GetAsync($"api/students/{d}");

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            var student = await response.Content.ReadFromJsonAsync<Student>();

            return View("Student",student);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
