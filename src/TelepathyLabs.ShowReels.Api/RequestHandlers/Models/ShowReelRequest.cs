using System;
using TelepathyLabs.ShowReels.Domain;

namespace TelepathyLabs.ShowReels.Api.RequestHandlers
{
    public class ShowReelRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public VideoStandard VideoStandard { get; set; }
        public VideoDefinition VideoDefinition { get; set; }
        public VideoClipRequest[] VideoClips { get; set; }
    }
}

