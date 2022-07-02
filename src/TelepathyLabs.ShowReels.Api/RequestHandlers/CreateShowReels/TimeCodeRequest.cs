using System;
namespace TelepathyLabs.ShowReels.Api.RequestHandlers
{
    public class TimeCodeRequest
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public int Frames { get; set; }
    }
}

