using Microsoft.AspNetCore.Mvc;
using ServisTakip.Models.ProductMovements.response;
using ServisTakipWebAPI.Models;

namespace ServisTakip.ViewComponents.AdminNotifications
{
    public class AdminNotifications : ViewComponent
    {
        private readonly ServisTakipDbContext _context;

        public AdminNotifications(ServisTakipDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
