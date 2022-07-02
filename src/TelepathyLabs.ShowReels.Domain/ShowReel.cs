using System.Linq;

namespace TelepathyLabs.ShowReels.Domain
{
    public class ShowReel
    {
        // max calculated assuming 30 frames per second and reel has capasity of 2 hours
        private const int MaxFrames = 216000;

        public ShowReel(
            string name,
            string description,
            VideoStandard videoStandard,
            VideoDefinition videoDefinition,
            List<VideoClip> videoClips)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Name cannot be null or empty.");
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                throw new Exception("Description cannot be null or empty.");
            }

            if (videoClips == null || videoClips.Count < 1)
            {
                throw new Exception("Atleast on video clip is required.");
            }

            var isVideoStandardnNotConsistant =
                videoClips.Where(v => v.VideoStandard == videoStandard).Count() != videoClips.Count();

            if (isVideoStandardnNotConsistant)
            {
                throw new Exception("All video clips should be in same video standard as the show reel.");
            }

            var isVideoDefinitionNotConsistant =
                videoClips.Where(v => v.VideoDefinition == videoDefinition).Count() != videoClips.Count();

            if (isVideoDefinitionNotConsistant)
            {
                throw new Exception("All video clips should be in same video definition as the show reel.");
            }

            for (int x = 1; x < videoClips.Count; x++)
            {
                if (videoClips[x - 1].EndTimeCode >= videoClips[x].StartTimeCode)
                {
                    throw new Exception("Video clips cannot overlap.");
                }
            }

            Name = name;
            Description = description;
            VideoStandard = videoStandard;
            VideoDefinition = videoDefinition;
            VideoClips = videoClips;
        }
 
        public string Name { get; private set; }
        public string Description { get; private set; }
        public VideoStandard VideoStandard { get; private set; }
        public VideoDefinition VideoDefinition { get; private set; }
        public List<VideoClip> VideoClips { get; private set; }
        public TimeCode TotalDuration
        {
            get
            {
                return VideoClips.Last().EndTimeCode;
            }
        }

        public void AddClip(VideoClip videoClip)
        {
            if (videoClip.VideoStandard != VideoStandard)
            {
                throw new Exception("Clip should be in same video standard as the show reel.");
            }
            if (videoClip.VideoDefinition != VideoDefinition)
            {
                throw new Exception("Clip should be in same video definition as the show reel.");
            }
            if (VideoClips.Last().EndTimeCode >= videoClip.StartTimeCode)
            {
                throw new Exception("Video clips cannot overlap.");
            }

            VideoClips.Add(videoClip);
        }
    }


}

