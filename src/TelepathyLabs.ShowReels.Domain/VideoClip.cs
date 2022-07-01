using System;
namespace TelepathyLabs.ShowReels.Domain
{
    public class VideoClip
    {
        public VideoClip(
            string name,
            string description,
            VideoStandard videoStandard,
            VideoDefinition videoDefinition,
            TimeCode startTimeCode,
            TimeCode endTimeCode)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Name cannot be null or empty.");
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                throw new Exception("Description cannot be null or empty.");
            }

            if (startTimeCode == null)
            {
                throw new Exception("Start timecode cannot be null.");
            }

            if (endTimeCode == null)
            {
                throw new Exception("End timecode cannot be null.");
            }

            if (startTimeCode.FramesPerSecond != endTimeCode.FramesPerSecond)
            {
                throw new Exception("Frame rates for start time and end time should match.");
            }

            if (startTimeCode > endTimeCode)
            {
                throw new Exception("Start time should be smaller than end time.");
            }

            Name = name;
            Description = description;
            VideoDefinition = videoDefinition;
            VideoStandard = videoStandard;
            StartTimeCode = startTimeCode;
            EndTimeCode = endTimeCode;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public VideoStandard VideoStandard { get; private set; }
        public VideoDefinition VideoDefinition { get; private set; }
        public TimeCode StartTimeCode { get; private set; }
        public TimeCode EndTimeCode { get; private set; }
    }
}

