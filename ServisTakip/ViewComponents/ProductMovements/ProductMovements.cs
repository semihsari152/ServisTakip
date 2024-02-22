using Microsoft.AspNetCore.Mvc;
using ServisTakip.Models.ProductMovements.response;
using ServisTakipWebAPI.Models;

namespace ServisTakip.ViewComponents.ProductMovements
{
    public class ProductMovements : ViewComponent
    {
        private readonly ServisTakipDbContext _context;

        public ProductMovements(ServisTakipDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke(int faultTrackingID)
        {
            var productMovements = _context.ProductMovements
        .Where(pm => pm.FaultTrack.FaultTrackingID == faultTrackingID)
        .OrderBy(pm => pm.MovementDate)
        .Select(pm => new ProductMovementsResponseModel
        {
            FaultTrackID = pm.FaultTrack.FaultTrackingID,
            MovementDate = pm.MovementDate,
            MovementDescription = pm.MovementDescription,
            MovementID = pm.MovementID,
        })
        .ToList();
            return View(productMovements);
        }

    }
}
