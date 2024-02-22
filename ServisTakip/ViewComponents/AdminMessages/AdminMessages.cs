using Microsoft.AspNetCore.Mvc;
using ServisTakipWebAPI.Models;

namespace ServisTakip.ViewComponents.AdminMessages
{
    public class AdminMessages : ViewComponent
    {

        private readonly ServisTakipDbContext _context;

        public AdminMessages(ServisTakipDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}