using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;


namespace Client_PlataformaUpskill.Controllers
{
    public class LoginController : Controller
    {

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Login request)
        {
            Pessoa user = new Pessoa();
            using (var httpClient = new HttpClient())
            {

                    StringContent stringcontent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync("https://localhost:7252/api/Login", stringcontent))
                    {
                        string token = await response.Content.ReadAsStringAsync();
                        HttpContext.Session.SetString("token", token);
                    }

                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                using (var response = await httpClient.GetAsync("https://localhost:7252/PessoaControllers/GetEmail?email=" + request.Email))
                {

                    string apiResponse = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<Pessoa>(apiResponse);
                    HttpContext.Session.SetString("role", user.Perfil.Nome);
                }


                    return RedirectToAction("Index", "Home");
            }
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }

    }
}
