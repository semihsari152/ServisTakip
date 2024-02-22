using Microsoft.AspNetCore.Mvc;
using ServisTakipWebAPI.Models.Request;
using ServisTakipWebAPI.Services;

namespace ServisTakipWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaultTrackController : ControllerBase
    {
        public readonly IFaultTrackService _faultTrackService;

        public FaultTrackController(IFaultTrackService faultTrackService)
        {
            _faultTrackService = faultTrackService;
        }

        [HttpGet("get")]
        public IActionResult GetAllFaultTracks()
        {
            var faultTracks = _faultTrackService.GetAllFaultTracks();
            return Ok(faultTracks);
        }

        [HttpGet("getbyid/{id}")]
        public IActionResult GetFaultTrackById(int id)
        {
            var faultTracks = _faultTrackService.GetFaultTrackById(id);
            return Ok(faultTracks);
        }

        [HttpPost("create")]
        public IActionResult CreateFaultTrack([FromBody] FaultTrackRequestModel faultTrack)
        {
            _faultTrackService.CreateFaultTrack(faultTrack);
            return Ok();
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateFaultTrack([FromBody] FaultTrackRequestModel faultTrack, int id)
        {
            _faultTrackService.UpdateFaultTrack(id, faultTrack);
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult DeleteFaultTrack(int id)
        {
            _faultTrackService.DeleteFaultTrack(id);
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestModel model)
        {
            var faultTrackId = _faultTrackService.ValidateCredentials(model);

            if (faultTrackId != null)
            {
                // Başarılı yanıt alındığında FaultTrackController'a yönlendir
                return Ok(faultTrackId);
            }
            else
            {
                // Geçersiz ise hata mesajı döndür
                return BadRequest();
            }
        }
    }
}
