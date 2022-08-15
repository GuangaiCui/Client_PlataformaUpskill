
using Microsoft.AspNetCore.Mvc;
using PlataformaUpskill_API.Data.Models;

namespace Client_PlataformaUpskill.Controllers
{
    public class TurmaController : Controller
    {
        private readonly ILogger<TurmaController> _logger;

        public TurmaController(ILogger<TurmaController> logger)
        {
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            List<Turma> turmas = new List<Turma>();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

                using (var response = await httpClient.GetAsync("https://localhost:7252/TurmaControllers/All"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    turmas = JsonConvert.DeserializeObject<List<Turma>>(apiResponse);
                }

            }
            return View(turmas);
        }
        public async Task<IActionResult> Create()
        { 
            Turma_Curso obj= new Turma_Curso();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

                using (var response = await httpClient.GetAsync("https://localhost:7252/CursoControllers/All"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    obj.cursos= JsonConvert.DeserializeObject<List<Curso>>(apiResponse);
                }
            }
                return View(obj);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Turma turma)
        {
            //turma.Id = 0;
            using (var httpclient = new HttpClient())
            {
                httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

                StringContent content = new StringContent(JsonConvert.SerializeObject(turma), Encoding.UTF8, "application/json");
                using (var response = await httpclient.GetAsync("https://localhost:7252/CursoControllers?id=" + turma.CursoId))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    turma.Curso = JsonConvert.DeserializeObject<Curso>(apiresponse);
                }
                using (var response = await httpclient.PostAsync("https://localhost:7252/TurmaControllers", content))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    turma = JsonConvert.DeserializeObject<Turma>(apiresponse);
                }
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int id)
        {
            Turma turma = new Turma();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

                using (var response = await httpClient.GetAsync("https://localhost:7252/TurmaControllers?id=" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    turma = JsonConvert.DeserializeObject<Turma>(apiResponse);
                }
            }
            return View(turma);
        }
        public async Task<IActionResult> Edit(int id)
        {
            Turma_Curso obj = new Turma_Curso();
           
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

                using (var response = await httpClient.GetAsync("https://localhost:7252/CursoControllers/All"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    obj.cursos = JsonConvert.DeserializeObject<List<Curso>>(apiResponse);
                }
                using (var response = await httpClient.GetAsync("https://localhost:7252/TurmaControllers?id=" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    obj.turma = JsonConvert.DeserializeObject<Turma>(apiResponse);
                }
            }
            return View(obj);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Turma turma)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

                StringContent content = new StringContent(JsonConvert.SerializeObject(turma), Encoding.UTF8, "application/json");
                using (var response = await httpClient.GetAsync("https://localhost:7252/CursoControllers?id=" + turma.CursoId))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    turma.Curso = JsonConvert.DeserializeObject<Curso>(apiresponse);
                }
                using (var response = await httpClient.PutAsync("https://localhost:7252/TurmaControllers", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    turma = JsonConvert.DeserializeObject<Turma>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

                using (var response = await httpClient.DeleteAsync("https://localhost:7252/TurmaControllers?id=" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("Index");
        }
    }
}

