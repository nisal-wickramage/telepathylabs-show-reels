import { TimeCode } from "./time-code";

export class VideoClip {

    constructor(
        name: string,
        description: string,
        videoDefinition: number,
        videoStandard: number,
        startTimeCode: TimeCode,
        endTimeCode: TimeCode
    ) {
        if (!name)
        {
            throw new Error("Name cannot be null or empty.");
        }

        if (!description)
        {
            throw new Error("Description cannot be null or empty.");
        }

        if (startTimeCode === null)
        {
            throw new Error("Start timecode cannot be null.");
        }

        if (endTimeCode === null)
        {
            throw new Error("End timecode cannot be null.");
        }

        if (startTimeCode.FramesPerSecond !== endTimeCode.FramesPerSecond)
        {
            throw new Error("Frame rates for start time and end time should match.");
        }

        if (startTimeCode.IsLargerThan(endTimeCode) || startTimeCode.IsEqualTo(endTimeCode))
        {
            throw new Error("Start time should be smaller than end time.");
        }

        this.name = name;
        this.description = description;
        this.videoDefinition = videoDefinition;
        this.videoStandard = videoStandard;
        this.startTimeCode = startTimeCode;
        this.endTimeCode = endTimeCode;
    }

    private name: string;
    public get Name(){
        return this.name;
    }

    private description: string;
    public get Description(){
        return this.description;
    }

    private videoDefinition: number;
    public get VideoDefinition(){
        return this.videoDefinition;
    }

    private videoStandard: number;
    public get VideoStandard(){
        return this.videoStandard;
    }

    private startTimeCode: TimeCode;
    public get StartTimeCode(){
        return this.startTimeCode;
    }

    private endTimeCode: TimeCode;
    public get EndTimeCode(){
        return this.endTimeCode;
    }
}