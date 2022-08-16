using Microsoft.AspNetCore.Mvc;
using PlataformaUpskill_API.Data.Models;
using System.Net.Http.Headers;

namespace Client_PlataformaUpskill.Controllers
{
    public class LocalController : Controller
    {
        private readonly ILogger<LocalController> _logger;

        public LocalController(ILogger<LocalController> logger)
        {
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("token") != null)
            {

                List<Local> locals = new List<Local>();
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

                    using (var response = await httpClient.GetAsync("https://localhost:7252/LocalControllers/All"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        locals = JsonConvert.DeserializeObject<List<Local>>(apiResponse);
                    }

                }
                return View(locals);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }


        public IActionResult LocalCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LocalCreate(Local local)
        {

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

                StringContent content = new StringContent(JsonConvert.SerializeObject(local), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:7252/LocalControllers", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    local = JsonConvert.DeserializeObject<Local>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> LocalEdit(int id)
        {
            Local local = new Local();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

                using (var response = await httpClient.GetAsync("https://localhost:7252/LocalControllers?id=" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    local = JsonConvert.DeserializeObject<Local>(apiResponse);
                }
            }
            return View(local);
        }
        [HttpPost]
        public async Task<IActionResult> LocalEdit(Local local)
        {

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

                StringContent content = new StringContent(JsonConvert.SerializeObject(local), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("https://localhost:7252/LocalControllers", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    local = JsonConvert.DeserializeObject<Local>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> LocalDelete(int id)
        {
            List<Sala> salas = new List<Sala>();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

                //get salas in local
                using (var response = await httpClient.GetAsync("https://localhost:7252/SalaControllers/All"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    salas = JsonConvert.DeserializeObject<List<Sala>>(apiResponse);
                }
                if (salas is null)
                {
                    using (var response = await httpClient.DeleteAsync("https://localhost:7252/LocalControllers?id=" + id))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> SalaIndex(int id)
        {
            List<Sala> salas = new List<Sala>();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

                //call sala with localid
                using (var response = await httpClient.GetAsync("https://localhost:7252/SalaControllers/GetByLocal?id="+id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    salas = JsonConvert.DeserializeObject<List<Sala>>(apiResponse);
                }

            }
            return View(salas);
        }
        public async Task<IActionResult> SalaCreate()
        {
            Local_Sala obj = new Local_Sala();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

                using (var response = await httpClient.GetAsync("https://localhost:7252/LocalControllers/All"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    obj.Local = JsonConvert.DeserializeObject<List<Local>>(apiResponse);
                }
            }
            return View(obj);
        }
        [HttpPost]
        public async Task<IActionResult> SalaCreate(Sala sala)
        {
            using (var httpClient = new HttpClient())
                {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

                
                using (var response = await httpClient.GetAsync("https://localhost:7252/LocalControllers?id=" + sala.LocalId))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    sala.Local = JsonConvert.DeserializeObject<Local>(apiresponse);
                }
                StringContent content = new StringContent(JsonConvert.SerializeObject(sala), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:7252/SalaControllers", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        //sala = JsonConvert.DeserializeObject<Sala>(apiResponse);
                    }
                }
                return RedirectToAction("SalaIndex","Local", new { id = sala.LocalId });
        }

        public async Task<IActionResult> SalaDetails(int id)
        {
            Sala sala = new Sala();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

                using (var response = await httpClient.GetAsync("https://localhost:7252/SalaControllers?id=" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    sala = JsonConvert.DeserializeObject<Sala>(apiResponse);
                }
            }
            return View(sala);
        }
        public async Task<IActionResult> SalaEdit(int id)
        {
            Local_Sala obj = new Local_Sala();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

                using (var response = await httpClient.GetAsync("https://localhost:7252/SalaControllers?id=" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    obj.Sala = JsonConvert.DeserializeObject<Sala>(apiResponse);
                }
                using (var response = await httpClient.GetAsync("https://localhost:7252/LocalControllers/All"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    obj.Local = JsonConvert.DeserializeObject<List<Local>>(apiResponse);
                }
            }
            return View(obj);
        }
        [HttpPost]
        public async Task<IActionResult> SalaEdit(Sala sala)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                using (var response = await httpClient.GetAsync("https://localhost:7252/LocalControllers?id=" + sala.LocalId))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    sala.Local = JsonConvert.DeserializeObject<Local>(apiresponse);
                }
                StringContent content = new StringContent(JsonConvert.SerializeObject(sala), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("https://localhost:7252/SalaControllers", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //sala = JsonConvert.DeserializeObject<Sala>(apiResponse);
                }
            }
            return RedirectToAction("SalaIndex", "Local", new { id = sala.LocalId });
        }
        [HttpPost]
        public async Task<IActionResult> SalaDelete(int id)
        {
            Sala sala = new Sala();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                using (var response = await httpClient.GetAsync("https://localhost:7252/SalaControllers?id=" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    sala = JsonConvert.DeserializeObject<Sala>(apiResponse);
                }
                using (var response = await httpClient.DeleteAsync("https://localhost:7252/SalaControllers?id=" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("SalaIndex", "Local", new { id = sala.LocalId });
        }
    }
}

