using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServisTakip.Models.Customer.request;
using ServisTakip.Models.Customer.response;
using ServisTakip.Models.FaultTrack.request;
using ServisTakip.Models.FaultTrack.response;
using ServisTakip.Models.Product.request;
using ServisTakip.Models.Product.response;
using ServisTakipWebAPI.Models;
using System.Text;

namespace ServisTakip.Controllers
{
    public class AdminController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AdminController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FaultTracks()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44389");

            var response = client.GetAsync("/api/FaultTrack/get").Result;

            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content.ReadAsStringAsync().Result;
                var fault = JsonConvert.DeserializeObject<List<FaultTrackResponseModel>>(responseContent);

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

        public IActionResult FaultTrackDetails(int id)
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

    //FaultTrack   (AREA'LARA BÖL BU ALANLARI)

        public IActionResult AddFaultTrack()
        {
               return View();
        }

        [HttpPost]
        public IActionResult AddFaultTrack(FaultTrackRequestModel faultTrack)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44389");

                var json = JsonConvert.SerializeObject(faultTrack);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = client.PostAsync("/api/FaultTrack/create", content).Result;

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
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    ViewBag.ErrorContent = responseContent;

                    return View();
                }
            }
        }

        public IActionResult UpdateFaultTrack()
        {
            return View();
        }

        [HttpPut]
        public IActionResult UpdateFaultTrack(FaultTrackRequestModel faultTrack)
        {
            return View();
        }

        [HttpDelete]
        public IActionResult DeleteFaultTrack(int id)
        {
            return View();
        }

        //Customer
        public IActionResult Customers()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44389");

            var response = client.GetAsync("/api/Customer/get").Result;

            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content.ReadAsStringAsync().Result;
                var customer = JsonConvert.DeserializeObject<List<CustomerResponseModel>>(responseContent);

                return View(customer);
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

        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCustomer(CustomerRequestModel requestModel)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44389");

                var json = JsonConvert.SerializeObject(requestModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = client.PostAsync("/api/Customer/create", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    var customer = JsonConvert.DeserializeObject<FaultTrackResponseModel>(responseContent);

                    return View(customer);
                }
                else
                {
                    // Başarısız durumu işleyin
                    ViewBag.ErrorMessage = "HTTP isteği başarısız. Durum Kodu: " + (int)response.StatusCode;

                    // API'den gelen içeriği göster
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    ViewBag.ErrorContent = responseContent;

                    return View();
                }
            }
        }

        public IActionResult UpdateCustomer()
        {
            return View();
        }

        [HttpPut]
        public IActionResult UpdateCustomer(CustomerRequestModel requestModel)
        {
            return View();
        }

        [HttpDelete]
        public IActionResult DeleteCustomer(int id)
        {
            return View();
        }

        //Product

        public IActionResult Products()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44389");

            var response = client.GetAsync("/api/Product/get").Result;

            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content.ReadAsStringAsync().Result;
                var product = JsonConvert.DeserializeObject<List<ProductResponseModel>>(responseContent);

                return View(product);
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

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(ProductRequestModel requestModel)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44389");

                var json = JsonConvert.SerializeObject(requestModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = client.PostAsync("/api/Product/create", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    var product = JsonConvert.DeserializeObject<FaultTrackResponseModel>(responseContent);

                    return View(product);
                }
                else
                {
                    // Başarısız durumu işleyin
                    ViewBag.ErrorMessage = "HTTP isteği başarısız. Durum Kodu: " + (int)response.StatusCode;

                    // API'den gelen içeriği göster
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    ViewBag.ErrorContent = responseContent;

                    return View();
                }
            }
        }

        public IActionResult UpdateProduct()
        {
            return View();
        }

        [HttpPut]
        public IActionResult UpdateProduct(ProductRequestModel requestModel)
        {
            return View();
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username,string password)
        {
            return View();
        }
    }
}
