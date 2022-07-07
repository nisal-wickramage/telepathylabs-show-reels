export class TimeCode {

    private minutesPerHour = 60;
    private secondsPerMinute = 60;
    private secondsPerHour = 3600;

    constructor(
        hours: number,
        minutes: number,
        seconds:number,
        frames: number,
        framesPerSecond: number
    ) {
        if (frames >= framesPerSecond)
        {
            throw new Error("Frames should be less than frame rate.");
        }

        if (framesPerSecond <= 1)
        {
            throw new Error("Frame rate should be greater than 1");
        }

        if (hours < 0 || minutes < 0 || seconds < 0 || frames < 0)
        {
            throw new Error("Hour, Minute, Second and Frame parameters should be positive.");
        }

        if (minutes >= this.minutesPerHour || seconds >= this.secondsPerMinute)
        {
            throw new Error("Minute and second parameters should be less than 60.");
        }

        this.hours = hours;
        this.minutes = minutes;
        this.seconds = seconds;
        this.frames = frames;
        this.framesPerSecond = framesPerSecond;
    }

    private hours: number;
    public get Hours(){
        return this.hours;
    }

    private minutes: number;
    public get Minutes(){
        return this.minutes;
    }

    private seconds: number;
    public get Seconds(){
        return this.seconds;
    }

    private frames: number;
    public get Frames(){
        return this.frames;
    }

    private framesPerSecond: number;
    public get FramesPerSecond(){
        return this.framesPerSecond;
    }

    public get TotalFrames(){
        return this.frames + (this.seconds + this.minutes * this.secondsPerMinute 
            + this.Hours * this.secondsPerHour) * this.framesPerSecond;
    }
    
    public Add(timeCode: TimeCode): TimeCode
    {
        this.AssertFrameRate(this, timeCode);

        var totalFrames = this.frames + timeCode.Frames;
        var framesToPromote = totalFrames / this.FramesPerSecond;
        var frames = totalFrames % this.FramesPerSecond;

        var totalSeconds = this.Seconds + timeCode.Seconds + framesToPromote;
        var secondsToPromote = totalSeconds / this.secondsPerMinute;
        var seconds = totalSeconds % this.secondsPerMinute;

        var totalMinutes = this.Minutes + timeCode.Minutes + secondsToPromote;
        var minutesToPromote = totalMinutes / this.minutesPerHour;
        var minutes = totalMinutes % this.minutesPerHour;

        var totalHours = this.Hours + timeCode.Hours + minutesToPromote;

        return new TimeCode(totalHours, minutes, seconds, frames, this.FramesPerSecond);
    }

    IsLargerThan(timeCode: TimeCode): boolean {
        this.AssertFrameRate(this, timeCode);

        return this.TotalFrames > timeCode.TotalFrames;
    }

    IsEqualTo(timeCode: TimeCode): boolean {
        this.AssertFrameRate(this, timeCode);

        return this.TotalFrames === timeCode.TotalFrames;
    }

    public get ToString() {
        return `${String(this.hours).padStart(2, "0")}:${String(this.minutes).padStart(2, "0")}:${String(this.seconds).padStart(2, "0")}:${String(this.frames).padStart(2, "0")}`;
    }

    private AssertFrameRate(a: TimeCode,b: TimeCode)
    {
        if (a.FramesPerSecond != b.FramesPerSecond)
        {
            throw new Error("Frame rates doesn't match.");
        }
    }
}