using TelepathyLabs.ShowReels.Domain;

namespace TelepathyLabs.ShowReels.Api.RequestHandlers
{
    public class CreateShowReelHandler
    {
        private readonly IShowReelRepository _showReelRepository;

        public CreateShowReelHandler(IShowReelRepository showReelRepository)
        {
            _showReelRepository = showReelRepository;
        }
        public ShowReelResponse Handle(ShowReelRequest request)
        {
            var showReel = new ShowReel(
                "ShowReel001",
                "Test 001 description",
                VideoStandard.PAL,
                VideoDefinition.HD,
                new List<VideoClip>() {
                    new VideoClip(
                        "Clip001",
                        "clip description",
                        VideoStandard.PAL,
                        VideoDefinition.HD,
                        new TimeCode(1,1,1,1,10),
                        new TimeCode(2,2,2,2,10)),
                });

            _showReelRepository.Create(showReel);
            return new ShowReelResponse();
        }
    }
}

