using Microsoft.AspNetCore.Mvc;
using TelepathyLabs.ShowReels.Api.RequestHandlers;
using TelepathyLabs.ShowReels.Domain;

namespace TelepathyLabs.ShowReels.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShowReelController : ControllerBase
    {
        private readonly CreateShowReelHandler _createShowReelHandler;
        private readonly GetShowReelsHandler _getShowReelsHandler;

        public ShowReelController(
            CreateShowReelHandler createShowReelHandler,
            GetShowReelsHandler getShowReelsHandler)
        {
            _createShowReelHandler = createShowReelHandler;
            _getShowReelsHandler = getShowReelsHandler;
        }
        
        [HttpPost]
        public ObjectResult Post(ShowReelRequest request)
        {
            try
            {
                var response = _createShowReelHandler.Handle(request);
                return new ObjectResult(response);
            }
            catch (ShowReelsException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
            catch (Exception ex)
            {
                var errorResponse = new ObjectResult("Unknown error occured. Please try again or contact administrator.");
                errorResponse.StatusCode = 500;
                return errorResponse;
            }
        }

        [HttpGet]
        public ObjectResult Get()
        {
            try
            {
                var response = _getShowReelsHandler.Handle();
                return new ObjectResult(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ObjectResult("Unknown error occured. Please try again or contact administrator.");
                errorResponse.StatusCode = 500;
                return errorResponse;
            }
        }
    }
}
