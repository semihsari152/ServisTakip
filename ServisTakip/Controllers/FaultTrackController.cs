using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServisTakip.Models.FaultTrack.response;
using ServisTakip.Models.Login.request;

namespace ServisTakip.Controllers
{
    public class FaultTrackController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public FaultTrackController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult FaultTrack(int id)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44389");

            var response = client.GetAsync("/api/FaultTrack/getbyid/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content.ReadAsStringAsync().Result;
                var fault = JsonConvert.DeserializeObject<FaultTrackResponseModel>(responseContent);

                return View(fault);
            }
            else
            {
                // Başarısız durumu işleyin
                ViewBag.ErrorMessage = "HTTP isteği başarısız. Durum Kodu: " + (int)response.StatusCode;

                // API'den gelen içeriği göster
                var responseContent = response.Content.ReadAsStringAsync();
                ViewBag.ErrorContent = responseContent;

                return View();
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginRequestModel model)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44389");

            try
            {
                var response = client.PostAsJsonAsync("/api/FaultTrack/login/", model).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    var faultTrackId = JsonConvert.DeserializeObject<int?>(responseContent);

                    if (faultTrackId != null)
                    {
                        // Başarılı yanıt alındığında FaultTrackController'a yönlendir
                        return RedirectToAction("FaultTrack", "FaultTrack", new { id = faultTrackId });
                    }
                    else
                    {
                        // Geçersiz ise hata mesajı döndür
                        ViewBag.ErrorMessage = "Geçersiz seri numarası veya servis takip numarası.";
                        return View();
                    }
                }
                else
                {
                   
                    ViewBag.ErrorMessage = "Geçersiz seri numarası veya servis takip numarası. ";
                    return View();
                }
            }
            catch (Exception ex)
            {
                // Hata durumunu işleyin
                ViewBag.ErrorMessage = "Bir hata oluştu: " + ex.Message;
                return View();
            }
        }

    }
}