using System;
using TelepathyLabs.ShowReels.Domain;

namespace TelepathyLabs.ShowReels.Api.RequestHandlers
{
    public class GetVideoDefinitionsHandler
    {
        public List<KeyValuePair<int, string>> Handle()
        {
            var values = Enum.GetValues(typeof(VideoDefinition))
                .Cast<VideoDefinition>()
                .Select(v => new KeyValuePair<int, string>((int)v, v.ToString()))
                .ToList();

            return values;
        }
    }
}

