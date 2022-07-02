using System;
using TelepathyLabs.ShowReels.Domain;

namespace TelepathyLabs.ShowReels.Api.RequestHandlers
{
    public class GetShowReelsHandler
    {
        private readonly IShowReelRepository _showReelRepository;

        public GetShowReelsHandler(IShowReelRepository showReelRepository)
        {
            _showReelRepository = showReelRepository;
        }
        public IEnumerable<ShowReelResponse> Handle()
        {
            var showReels = _showReelRepository.Get().Select(s => new ShowReelResponse
            {
                Name = s.Name,
                Description = s.Description,
                VideoStandard = s.VideoStandard,
                VideoDefinition = s.VideoDefinition,
                VideoClips = s.VideoClips.Select(v => new VideoClipRequest(v)).ToArray()
            });
            return showReels;

        }
    }
}

