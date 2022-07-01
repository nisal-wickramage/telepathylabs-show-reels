using System;
using Xunit;

namespace TelepathyLabs.ShowReels.Domain.Tests
{
    public class ShowReelTest
    {
        // name, standard, definition should not be null
        // add least one video clip
        public ShowReelTest()
        {
        }

        [Fact]
        public void AllConstructorParametersShouldNotBeNullOrWhiteSpace()
        {
            Assert.Throws<Exception>(() => new ShowReel(
                null,
                "Test 001 description",
                VideoStandard.PAL,
                VideoDefinition.HD,
                new VideoClip[0]));

            Assert.Throws<Exception>(() => new ShowReel(
                "ShowReel001",
                null,
                VideoStandard.PAL,
                VideoDefinition.HD,
                new VideoClip[0]));
        }

        [Fact]
        public void ShowReelShouldAtleastHaveOneVideoClip()
        {
            Assert.Throws<Exception>(() => new ShowReel(
                "ShowReel001",
                "Test 001 description",
                VideoStandard.PAL,
                VideoDefinition.HD,
                new VideoClip[0]));


            Assert.True(new ShowReel(
                    "ShowReel001",
                    "Test 001 description",
                    VideoStandard.PAL,
                    VideoDefinition.HD,
                    new VideoClip[1] {
                        new VideoClip(
                        "Clip001",
                        "clip description",
                        VideoStandard.PAL,
                        VideoDefinition.HD,
                        new TimeCode(1,1,1,1,2),
                        new TimeCode(2,2,2,1,2)) }
                ) != null);
        }


        [Fact]
        public void VideoClipShouldHaveTheSameVideoStandard()
        {
            Assert.Throws<Exception>(() => new ShowReel(
                   "ShowReel001",
                   "Test 001 description",
                   VideoStandard.PAL,
                   VideoDefinition.HD,
                   new VideoClip[1] {
                    new VideoClip(
                        "Clip001",
                        "clip description",
                        VideoStandard.NTSC,
                        VideoDefinition.HD,
                        new TimeCode(1,1,1,1,2),
                        new TimeCode(2,2,2,1,2))
                   }));
        }

        [Fact]
        public void AllClipsInShowReelShouldHaveSameVideoDefinition()
        {

            Assert.Throws<Exception>(() => new ShowReel(
                "ShowReel001",
                "Test 001 description",
                VideoStandard.PAL,
                VideoDefinition.HD,
                new VideoClip[2] {
                    new VideoClip(
                        "Clip001",
                        "clip description",
                        VideoStandard.PAL,
                        VideoDefinition.HD,
                        new TimeCode(1,1,1,1,2),
                        new TimeCode(2,2,2,2,2)),
                    new VideoClip(
                        "Clip002",
                        "clip description",
                        VideoStandard.NTSC,
                        VideoDefinition.HD,
                        new TimeCode(2,2,2,1,2),
                        new TimeCode(3,3,3,1,2))
                }));


            var showReel = new ShowReel(
                "ShowReel001",
                "Test 001 description",
                VideoStandard.PAL,
                VideoDefinition.HD,
                new VideoClip[1] {
                    new VideoClip(
                        "Clip001",
                        "clip description",
                        VideoStandard.PAL,
                        VideoDefinition.HD,
                        new TimeCode(1,1,1,1,2),
                        new TimeCode(2,2,2,1,2)),
                });

            Assert.Throws<Exception>(() => showReel.AddClip(
                    new VideoClip(
                        "Clip002",
                        "clip description",
                        VideoStandard.NTSC,
                        VideoDefinition.HD,
                        new TimeCode(2, 2, 2, 1, 2),
                        new TimeCode(3, 3, 3, 1, 2))));
        }

        [Fact]
        public void ClipsShouldNotOverlap()
        {
            Assert.Throws<Exception>(() => new ShowReel(
                "ShowReel001",
                "Test 001 description",
                VideoStandard.PAL,
                VideoDefinition.HD,
                new VideoClip[2] {
                    new VideoClip(
                        "Clip001",
                        "clip description",
                        VideoStandard.PAL,
                        VideoDefinition.HD,
                        new TimeCode(1,1,1,1,2),
                        new TimeCode(2,2,2,2,2)),
                    new VideoClip(
                        "Clip002",
                        "clip description",
                        VideoStandard.PAL,
                        VideoDefinition.HD,
                        new TimeCode(1,1,1,1,2),
                        new TimeCode(2,2,2,1,2)),
                }));


            var showReel = new ShowReel(
                "ShowReel001",
                "Test 001 description",
                VideoStandard.PAL,
                VideoDefinition.HD,
                new VideoClip[1] {
                    new VideoClip(
                        "Clip001",
                        "clip description",
                        VideoStandard.PAL,
                        VideoDefinition.HD,
                        new TimeCode(1,1,1,1,2),
                        new TimeCode(2,2,2,1,2)),
                });

            Assert.Throws<Exception>(() => showReel.AddClip(
                    new VideoClip(
                        "Clip002",
                        "clip description",
                        VideoStandard.PAL,
                        VideoDefinition.HD,
                        new TimeCode(1, 1, 1, 1, 2),
                        new TimeCode(2, 2, 2, 1, 2))));
        }

        [Fact]
        public void CorrectParametersShouldCreateShowReelAndAddClips()
        {
            var showReel = new ShowReel(
                "ShowReel001",
                "Test 001 description",
                VideoStandard.PAL,
                VideoDefinition.HD,
                new VideoClip[1] {
                    new VideoClip(
                        "Clip001",
                        "clip description",
                        VideoStandard.PAL,
                        VideoDefinition.HD,
                        new TimeCode(1,1,1,1,10),
                        new TimeCode(2,2,2,2,10)),
                });

            Assert.True(showReel.VideoClips.Length == 1);

            showReel.AddClip(
                    new VideoClip(
                        "Clip002",
                        "clip description",
                        VideoStandard.PAL,
                        VideoDefinition.HD,
                        new TimeCode(2, 2, 2, 3, 10),
                        new TimeCode(3, 3, 3, 3, 10)
                    )
                );

            Assert.True(showReel.VideoClips.Length == 2);
        }
    }
}

