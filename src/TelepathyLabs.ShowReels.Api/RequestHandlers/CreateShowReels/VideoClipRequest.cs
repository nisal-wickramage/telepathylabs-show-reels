using System;
using TelepathyLabs.ShowReels.Domain;

namespace TelepathyLabs.ShowReels.Api.RequestHandlers
{
    public class VideoClipRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public VideoStandard VideoStandard { get; set; }
        public VideoDefinition VideoDefinition { get; set; }
        public TimeCodeRequest StartTimeCode { get; set; }
        public TimeCodeRequest EndTimeCode { get; set; }
    }
}

