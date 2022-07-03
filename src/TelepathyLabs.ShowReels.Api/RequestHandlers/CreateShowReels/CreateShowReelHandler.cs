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
            var videoClips = request.VideoClips.Select(v =>
            new VideoClip(
                    v.Name,
                    v.Description,
                    v.VideoStandard,
                    v.VideoDefinition,
                    new TimeCode(
                        v.StartTimeCode.Hours,
                        v.StartTimeCode.Minutes,
                        v.StartTimeCode.Seconds,
                        v.StartTimeCode.Frames,
                        FrameRates.values[v.VideoStandard]
                        ),
                    new TimeCode(
                        v.EndTimeCode.Hours,
                        v.EndTimeCode.Minutes,
                        v.EndTimeCode.Seconds,
                        v.EndTimeCode.Frames,
                        FrameRates.values[v.VideoStandard]
                        )
                )).ToList();
            var showReel = new ShowReel(
                request.Name,
                request.Description,
                request.VideoStandard,
                request.VideoDefinition,
                videoClips);

            _showReelRepository.Create(showReel);
            return new ShowReelResponse();
        }
    }
}

