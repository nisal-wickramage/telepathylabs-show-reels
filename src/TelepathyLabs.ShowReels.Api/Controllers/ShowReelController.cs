using Microsoft.AspNetCore.Mvc;
using TelepathyLabs.ShowReels.Api.RequestHandlers;

namespace TelepathyLabs.ShowReels.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShowReelController : ControllerBase
    {
        private readonly CreateShowReelHandler _createShowReelHandler;

        public ShowReelController(CreateShowReelHandler createShowReelHandler)
        {
            _createShowReelHandler = createShowReelHandler;
        }
        
        // async Task return type
        [HttpPost]
        public ObjectResult Post(ShowReelRequest request)
        {
            try
            {
                var response = _createShowReelHandler.Handle(request);
                return new ObjectResult(response);
            }
            catch (NotImplementedException ex)
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
    }
}
