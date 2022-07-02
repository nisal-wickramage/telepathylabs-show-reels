using System;
using TelepathyLabs.ShowReels.Domain;

namespace TelepathyLabs.ShowReels.Api.RequestHandlers
{
    public class GetVideoStandardsHandler
    {
        public Dictionary<int, string> Handle()
        {
            var values = Enum.GetValues(typeof(VideoStandard))
                .Cast<VideoStandard>().
                ToDictionary(v => (int)v, v => v.ToString());

            return values;
        }
    }
}

