using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PlataformaUpskill_API.Data.Models;

namespace Client_PlataformaUpskill.Controllers
{
    public class FormadorController : Controller
    {

        private readonly ILogger<FormadorController> _logger;

        public FormadorController(ILogger<FormadorController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            
            List<Formador> formadores = new List<Formador>();

            using (var httpClient = new HttpClient())
            {
                using(var response = await httpClient.GetAsync("https://localhost:7252/FormadorControllers/All"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    formadores = JsonConvert.DeserializeObject<List<Formador>>(apiResponse);
                }
                
            }
            return View(formadores);
            
            
        }
        

    }
}
