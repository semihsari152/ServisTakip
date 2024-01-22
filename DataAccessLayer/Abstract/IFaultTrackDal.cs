using ServisTakipWebAPI.Models.Request;
using ServisTakipWebAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IFaultTrackDal
    {
        List<FaultTrackResponseModel> GetAllFaultTracks();
        FaultTrackResponseModel GetFaultTrackById(int faultTrackId);
        int CreateFaultTrack(FaultTrackRequestModel faultTrackRequest);
        void UpdateFaultTrack(int faultTrackId, FaultTrackRequestModel faultTrackRequest);
        void DeleteFaultTrack(int faultTrackId);
    }
}
