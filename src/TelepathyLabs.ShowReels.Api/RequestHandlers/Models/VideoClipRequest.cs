using System;
using TelepathyLabs.ShowReels.Domain;

namespace TelepathyLabs.ShowReels.Api.RequestHandlers
{
    public class VideoClipRequest
    {
        public VideoClipRequest() {}

        public VideoClipRequest(VideoClip videoClip)
        {
            Name = videoClip.Name;
            Description = videoClip.Description;
            VideoDefinition = videoClip.VideoDefinition;
            VideoStandard = videoClip.VideoStandard;
            StartTimeCode = new TimeCodeRequest(videoClip.StartTimeCode);
            EndTimeCode = new TimeCodeRequest(videoClip.EndTimeCode);
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public VideoStandard VideoStandard { get; set; }
        public VideoDefinition VideoDefinition { get; set; }
        public TimeCodeRequest StartTimeCode { get; set; }
        public TimeCodeRequest EndTimeCode { get; set; }
    }
}

