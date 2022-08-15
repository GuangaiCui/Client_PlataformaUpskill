using Microsoft.AspNetCore.Mvc;
using PlataformaUpskill_API.Data.Models;

namespace Client_PlataformaUpskill.Controllers
{
    public class AulaController : Controller
    {
        private readonly ILogger<AulaController> _logger;

        public AulaController(ILogger<AulaController> logger)
        {
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            List<Aula> aulas = new List<Aula>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7252/AulaControllers/All"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    aulas = JsonConvert.DeserializeObject<List<Aula>>(apiResponse);
                }

            }
            return View(aulas);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Aula aula)
        {
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(aula), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync("https://localhost:7252/AulaControllers/All", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        aula = JsonConvert.DeserializeObject<Aula>(apiResponse);
                    }
                }
                return View(aula);
            }
            return View();
        }
        public async Task<IActionResult> Details(int id)
        {
            Aula aula = new Aula();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7252/AulaControllers?id=" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    aula = JsonConvert.DeserializeObject<Aula>(apiResponse);
                }
            }
            return View(aula);
        }
        public async Task<IActionResult> Edit(int id)
        {
            Aula aula = new Aula();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7252/AulaControllers?id=" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    aula = JsonConvert.DeserializeObject<Aula>(apiResponse);
                }
            }
            return View(aula);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Aula aula)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(aula), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("https://localhost:7252/AulaControllers", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    aula = JsonConvert.DeserializeObject<Aula>(apiResponse);
                }
            }
            return View(aula);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:7252/AulaControllers?id=" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("Index");
        }
    }
}

