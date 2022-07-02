using Microsoft.AspNetCore.Mvc;
using TelepathyLabs.ShowReels.Api.RequestHandlers;

namespace TelepathyLabs.ShowReels.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VideoDefinitionController : ControllerBase
    {
        private readonly GetVideoDefinitionsHandler _getVideoDefinitionHandler;

        public VideoDefinitionController(GetVideoDefinitionsHandler getVideoDefinitionHandler)
        {
            _getVideoDefinitionHandler = getVideoDefinitionHandler;
        }

        [HttpGet]
        public ObjectResult Get()
        {
            var values = _getVideoDefinitionHandler.Handle();

            return new ObjectResult(values);
        }
    }
}
