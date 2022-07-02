using Microsoft.AspNetCore.Mvc;
using TelepathyLabs.ShowReels.Api.RequestHandlers;

namespace TelepathyLabs.ShowReels.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VideoStandardController : ControllerBase
    {
        private readonly GetVideoStandardsHandler _getVideoStandardsHandler;

        public VideoStandardController(GetVideoStandardsHandler getVideoStandardsHandler)
        {
            _getVideoStandardsHandler = getVideoStandardsHandler;
        }

        [HttpGet]
        public ObjectResult Get()
        {
            var values = _getVideoStandardsHandler.Handle();

            return new ObjectResult(values);
        }
    }
}
