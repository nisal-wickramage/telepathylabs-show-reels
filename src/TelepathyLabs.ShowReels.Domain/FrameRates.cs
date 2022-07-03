namespace TelepathyLabs.ShowReels.Domain
{
    public static class FrameRates
    {
        public static Dictionary<VideoStandard, int> values = new Dictionary<VideoStandard, int>()
        {
            { VideoStandard.NTSC, 30 },
            { VideoStandard.PAL, 25 }
        };
    }
}

