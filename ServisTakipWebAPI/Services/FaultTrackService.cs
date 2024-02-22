using Microsoft.EntityFrameworkCore;
using ServisTakipWebAPI.Models;
using ServisTakipWebAPI.Models.Request;
using ServisTakipWebAPI.Models.Response;

namespace ServisTakipWebAPI.Services
{
    public interface IFaultTrackService
    {
        List<FaultTrackResponseModel> GetAllFaultTracks();
        FaultTrackResponseModel GetFaultTrackById(int faultTrackId);
        void CreateFaultTrack(FaultTrackRequestModel faultTrackRequest);
        void UpdateFaultTrack(int faultTrackId, FaultTrackRequestModel faultTrackRequest);
        void DeleteFaultTrack(int faultTrackId);
        int? ValidateCredentials(LoginRequestModel requestModel);
    }

    public class FaultTrackService : IFaultTrackService
    {
        private readonly ServisTakipDbContext _dbContext;

        public FaultTrackService(ServisTakipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<FaultTrackResponseModel> GetAllFaultTracks()
        {
            var faultTracks = _dbContext.FaultTracks
                .Include(ft => ft.Customer)
                .Include(ft => ft.Product)
               .ToList();

            if (faultTracks == null)
            {
                return null;
            }
            var faultTrackResponses = faultTracks.Select(MapToFaultTrackResponse).ToList();
            return faultTrackResponses;
        }

        public FaultTrackResponseModel GetFaultTrackById(int faultTrackId)
        {
            var faultTrack = _dbContext.FaultTracks
                .Include(ft => ft.Customer)
                .Include(ft => ft.Product)
                .FirstOrDefault(ft => ft.FaultTrackingID == faultTrackId);

            if (faultTrack == null)
            {
                return null;
            }

            return MapToFaultTrackResponse(faultTrack);
        }

        public void UpdateFaultTrack(int faultTrackId, FaultTrackRequestModel faultTrackRequest)
        {
            var existingFaultTrack = _dbContext.FaultTracks.Find(faultTrackId);
            if (existingFaultTrack == null)
            {
                return;
            }

            existingFaultTrack.FaultDefinition = faultTrackRequest.FaultDefinition;
            existingFaultTrack.FaultWorkerName = faultTrackRequest.FaultWorkerName;
            existingFaultTrack.FaultDocumentNumber = faultTrackRequest.FaultDocumentNumber;
            existingFaultTrack.FaultCreateDate = faultTrackRequest.FaultCreateDate;
            existingFaultTrack.FaultUpdateDate = faultTrackRequest.FaultUpdateDate;
            existingFaultTrack.EstimatedDeliveryDate = faultTrackRequest.EstimatedDeliveryDate;
            existingFaultTrack.FaultDescription = faultTrackRequest.FaultDescription;


            _dbContext.SaveChanges();
        }

        public void CreateFaultTrack(FaultTrackRequestModel request)
        {

            // Yeni Customer oluştur
            var newCustomer = new Customer
            {
                CustomerName = request.Customer.CustomerName,
                CustomerPhone = request.Customer.CustomerPhone,
                CustomerEmail = request.Customer.CustomerEmail,
                CustomerCity = request.Customer.CustomerCity,
                // Diğer Customer özelliklerini de burada atayabilirsiniz
            };

            _dbContext.Customers.Add(newCustomer);

            // Yeni Product oluştur
            var newProduct = new Product
            {
                ProductName = request.Product.ProductName,
                ProductType = request.Product.ProductType,
                ProductSerialNumber = request.Product.ProductSerialNumber,
                ProductAccessories = request.Product.ProductAccessories,
                // Diğer Product özelliklerini de burada atayabilirsiniz
            };

            _dbContext.Products.Add(newProduct);

            // Yeni FaultTrack oluştur
            var newFaultTrack = new FaultTrack
            {
                FaultDefinition = request.FaultDefinition,
                FaultWorkerName = request.FaultWorkerName,
                FaultDocumentNumber = request.FaultDocumentNumber,
                FaultCreateDate = request.FaultCreateDate,
                FaultUpdateDate = request.FaultUpdateDate,
                EstimatedDeliveryDate = request.EstimatedDeliveryDate,
                FaultDescription = request.FaultDescription,
                FaultStage = request.FaultStage,
                Customer = newCustomer,
                Product = newProduct
            };


            // Yeni FaultTrack'i veritabanına ekliyoruz.
            _dbContext.FaultTracks.Add(newFaultTrack);
            _dbContext.SaveChanges();
        }

        public void DeleteFaultTrack(int faultTrackId)
        {
            var faultTrackToDelete = _dbContext.FaultTracks.Find(faultTrackId);
            if (faultTrackToDelete == null)
            {
                return;
            }

            _dbContext.FaultTracks.Remove(faultTrackToDelete);
            _dbContext.SaveChanges();
        }

        private FaultTrackResponseModel MapToFaultTrackResponse(FaultTrack faultTrack)
        {
            CustomerResponseModel crm = new CustomerResponseModel
            {
                CustomerID = faultTrack.Customer.CustomerID,
                CustomerName = faultTrack.Customer.CustomerName,
                CustomerCity = faultTrack.Customer.CustomerCity,
                CustomerCounty = faultTrack.Customer.CustomerCounty,
                CustomerEmail = faultTrack.Customer.CustomerEmail,
                CustomerPhone = faultTrack.Customer.CustomerPhone
            };

            ProductResponseModel prm = new ProductResponseModel
            {
                ProductID = faultTrack.Product.ProductID,
                ProductName = faultTrack.Product.ProductName,
                ProductType = faultTrack.Product.ProductType,
                ProductAccessories = faultTrack.Product.ProductAccessories,
                ProductSerialNumber = faultTrack.Product.ProductSerialNumber
            };

            return new FaultTrackResponseModel
            {
                FaultTrackingID = faultTrack.FaultTrackingID,
                FaultDefinition = faultTrack.FaultDefinition,
                FaultWorkerName = faultTrack.FaultWorkerName,
                FaultDocumentNumber = faultTrack.FaultDocumentNumber,
                FaultCreateDate = faultTrack.FaultCreateDate,
                FaultUpdateDate = faultTrack.FaultUpdateDate,
                EstimatedDeliveryDate = faultTrack.EstimatedDeliveryDate,
                FaultDescription = faultTrack.FaultDescription,
                FaultStage = faultTrack.FaultStage,
                CustomerID = faultTrack.Customer.CustomerID,
                ProductID = faultTrack.Product.ProductID,
                Customer = crm,
                Product = prm

            };
        }

        public int? ValidateCredentials(LoginRequestModel requestModel)
        {
            var faultTrack = _dbContext.FaultTracks.FirstOrDefault(ft => ft.Product.ProductSerialNumber == requestModel.ProductSerialNumber &&
                                                                          ft.FaultDocumentNumber == requestModel.FaultDocumentNumber);

            if (faultTrack != null)
            {
                return faultTrack.FaultTrackingID;
            }
            else
            {
                return null;
            }
        }
    }
}