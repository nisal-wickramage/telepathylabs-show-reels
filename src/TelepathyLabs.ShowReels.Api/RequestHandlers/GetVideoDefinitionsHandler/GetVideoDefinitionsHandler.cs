using System;
using TelepathyLabs.ShowReels.Domain;

namespace TelepathyLabs.ShowReels.Api.RequestHandlers
{
    public class GetVideoDefinitionsHandler
    {
        public Dictionary<int, string> Handle()
        {
            var values = Enum.GetValues(typeof(VideoDefinition))
                .Cast<VideoDefinition>().
                ToDictionary(v => (int)v, v => v.ToString());

            return values;
        }
    }
}

