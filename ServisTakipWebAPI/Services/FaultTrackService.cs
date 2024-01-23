using ServisTakipWebAPI.Models;
using ServisTakipWebAPI.Models.Request;
using ServisTakipWebAPI.Models.Response;

namespace ServisTakipWebAPI.Services
{
    public interface IFaultTrackService
    {
        List<FaultTrackResponseModel> GetAllFaultTracks();
        FaultTrackResponseModel GetFaultTrackById(int faultTrackId);
        int CreateFaultTrack(FaultTrackRequestModel faultTrackRequest);
        void UpdateFaultTrack(int faultTrackId, FaultTrackRequestModel faultTrackRequest);
        void DeleteFaultTrack(int faultTrackId);
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
            var faultTracks = _dbContext.FaultTracks.ToList();
            var faultTrackResponses = faultTracks.Select(MapToFaultTrackResponse).ToList();
            return faultTrackResponses;
        }

        public FaultTrackResponseModel GetFaultTrackById(int faultTrackId)
        {
            var faultTrack = _dbContext.FaultTracks.Find(faultTrackId);
            if (faultTrack == null)
            {
                return null;
            }

            return MapToFaultTrackResponse(faultTrack);
        }

        public int CreateFaultTrack(FaultTrackRequestModel faultTrackRequest)
        {
            var newFaultTrack = new FaultTrack
            {
                FaultDefinition = faultTrackRequest.FaultDefinition,
                FaultWorkerName = faultTrackRequest.FaultWorkerName,
                FaultDocumentNumber = faultTrackRequest.FaultDocumentNumber,
                FaultCreateDate = faultTrackRequest.FaultCreateDate,
                FaultUpdateDate = faultTrackRequest.FaultUpdateDate,
                EstimatedDeliveryDate = faultTrackRequest.EstimatedDeliveryDate,
                FaultDescription = faultTrackRequest.FaultDescription,
                ProductID = faultTrackRequest.ProductID
                // Other properties can be set similarly
            };

            _dbContext.FaultTracks.Add(newFaultTrack);
            _dbContext.SaveChanges();

            return newFaultTrack.FaultTrackingID;
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
            existingFaultTrack.ProductID = faultTrackRequest.ProductID;
            // Update other properties similarly

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
                ProductID = faultTrack.ProductID
                // Other properties can be mapped similarly
            };
        }


    }
}
