using System;
using TelepathyLabs.ShowReels.Domain;

namespace TelepathyLabs.ShowReels.Api.RequestHandlers
{
    public class TimeCodeRequest
    {
        public TimeCodeRequest(){}

        public TimeCodeRequest(TimeCode timeCode)
        {
            Hours = timeCode.Hours;
            Minutes = timeCode.Minutes;
            Seconds = timeCode.Seconds;
            Frames = timeCode.Frames;
        }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public int Frames { get; set; }
    }
}

