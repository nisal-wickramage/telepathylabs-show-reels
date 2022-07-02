using System;
using TelepathyLabs.ShowReels.Domain;

namespace TelepathyLabs.ShowReels.DataAccess
{
    internal class ShowReelDbModel
    {
        internal int Id { get; set; }
        internal string Name { get;  set; }
        internal string Description { get; set; }
        internal VideoStandard VideoStandard { get; set; }
        internal VideoDefinition VideoDefinition { get; set; }
        internal List<VideoClip> VideoClips { get; set; }
    }
}

