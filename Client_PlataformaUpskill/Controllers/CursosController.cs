using Microsoft.AspNetCore.Mvc;

namespace Client_PlataformaUpskill.Controllers
{
    public class CursosController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Curso> cursos = new List<Curso>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7252/FormadorControllers/All"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    cursos = JsonConvert.DeserializeObject<List<Curso>>(apiResponse);
                }

            }
            return View(cursos);
        }
    }
}
