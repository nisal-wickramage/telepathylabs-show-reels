using System;

namespace TelepathyLabs.ShowReels.Domain
{
    public class TimeCode
    {
        public TimeCode(int hours, int minutes, int seconds, int frames, int framesPerSecond)
        {
            if (frames >= framesPerSecond)
            {
                // add custom exception
                throw new Exception("Frames should be less than frame rate.");
            }

            if (framesPerSecond <= 1)
            {
                // add custom exception
                throw new Exception("Frame rate should be greater than 1");
            }

            if (hours < 0 || minutes < 0 || seconds < 0 || frames < 0)
            {
                // add custom exception
                throw new Exception("Hour, Minute, Second and Frame parameters should be positive.");
            }

            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
            Frames = frames;
            FramesPerSecond = framesPerSecond;
        }

        public int Hours { get; private set; }
        public int Minutes { get; private set; }
        public int Seconds { get; private set; }
        public int Frames { get; private set; }
        public int FramesPerSecond { get; private set; }
        public int TotalFrames
        {
            get
            {
                return Frames + (Seconds + Minutes * 60 + Hours * 3600) * FramesPerSecond;
            }
        }

        public TimeCode Add(TimeCode timeCode)
        {
            if (timeCode.FramesPerSecond != FramesPerSecond)
            {
                // add custom exception
                throw new Exception("Frame rates doesn't match.");
            }
            var totalFrames = Frames + timeCode.Frames;
            var framesToPromote = totalFrames / FramesPerSecond;
            var frames = totalFrames % FramesPerSecond;

            var totalSeconds = Seconds + timeCode.Seconds + framesToPromote;
            var secondsToPromote = totalSeconds / 60;
            var seconds = totalSeconds % 60;

            var totalMinutes = Minutes + timeCode.Minutes + secondsToPromote;
            var minutesToPromote = totalMinutes / 60;
            var minutes = totalMinutes % 60;

            var totalHours = Hours + timeCode.Hours + minutesToPromote;

            return new TimeCode(totalHours, minutes, seconds, frames, FramesPerSecond);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not TimeCode)
            {
                return false;
            }

            return obj is TimeCode timeCode &&
                FramesPerSecond == timeCode.FramesPerSecond &&
                Hours == timeCode.Hours && Minutes == timeCode.Minutes && Seconds == timeCode.Seconds && Frames == timeCode.Frames;

        }

        public static bool operator <(TimeCode a, TimeCode b)
        {
            if (a.FramesPerSecond != b.FramesPerSecond)
            {
                // add custom exception
                throw new Exception("Frame rates doesn't match.");
            }

            return a.TotalFrames < b.TotalFrames;
        }


        public static bool operator >(TimeCode a, TimeCode b)
        {
            if (a.FramesPerSecond != b.FramesPerSecond)
            {
                // add custom exception
                throw new Exception("Frame rates doesn't match.");
            }

            return a.TotalFrames > b.TotalFrames;
        }
    }
}

