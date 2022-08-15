using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PlataformaUpskill_API.Data.Models;

namespace Client_PlataformaUpskill.Controllers
{
    public class FormandoController : Controller
    {

        private readonly ILogger<FormandoController> _logger;

        public FormandoController(ILogger<FormandoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            
            List<Formando> formando = new List<Formando>();

            using (var httpClient = new HttpClient())
            {
                using(var response = await httpClient.GetAsync("https://localhost:7252/FormandoControllers/All"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    formando = JsonConvert.DeserializeObject<List<Formando>>(apiResponse);
                }
                
            }
            return View(formando);
            
            
        }
        [HttpGet]
        public async Task<IActionResult> Index1()
        {

            List<Formando> formando = new List<Formando>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7252/FormandoControllers/All"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    formando = JsonConvert.DeserializeObject<List<Formando>>(apiResponse);
                }

            }
            return View(formando);


        }


    }
}
