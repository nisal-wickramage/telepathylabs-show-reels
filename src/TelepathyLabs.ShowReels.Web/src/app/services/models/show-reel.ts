import { TimeCode } from "./time-code";
import { VideoClip } from "./video-clip";

export class ShowReel {

    constructor(
        name: string,
        description: string,
        videoDefinition: number,
        videoStandard: number,
        videoClips: VideoClip[]
    ) {
        if(!name) {
            throw new Error("Name cannot be null or empty.");
        }
        
        if(!description) {
            throw new Error("Description cannot be null or empty.");
        }

        if(!videoClips || videoClips.length < 1){
            throw new Error("Atleast on video clip is required.");
        }
        
        var isVideoStandardnNotConsistant =
            videoClips.filter(v => v.VideoStandard === videoStandard).length !== videoClips.length;

        if (isVideoStandardnNotConsistant)
        {
            throw new Error("All video clips should be in same video standard as the show reel.");
        }

        var isVideoDefinitionNotConsistant =
            videoClips.filter(v => v.VideoDefinition === videoDefinition).length !== videoClips.length;

        if (isVideoDefinitionNotConsistant)
        {
            throw new Error("All video clips should be in same video definition as the show reel.");
        }

        for (let x = 1; x < videoClips.length; x++)
        {
            if (videoClips[x - 1].EndTimeCode >= videoClips[x].StartTimeCode)
            {
                throw new Error("Video clips cannot overlap.");
            }
        }

        this.name = name;
        this.description = description;
        this.videoStandard = videoStandard;
        this.videoDefinition = videoDefinition;
        this.videoClips = videoClips;
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

    private videoClips: VideoClip[];
    public get VideoClips(){
        return this.videoClips;
    }

    public get TotalDuration() {
        let totalDuration =  this.VideoClips.length > 0 ? this.VideoClips[this.VideoClips.length - 1].EndTimeCode: 
            new TimeCode(0,0,0,0, 10);
        return totalDuration.ToString;
    }

    AddClip(videoClip: VideoClip)
    {
        if (videoClip.VideoStandard !== this.VideoStandard)
        {
            throw new Error("Clip should be in same video standard as the show reel.");
        }

        if (videoClip.VideoDefinition !== this.VideoDefinition)
        {
            throw new Error("Clip should be in same video definition as the show reel.");
        }

        let lastVideoEndTimeCode = this.VideoClips[this.VideoClips.length - 1].EndTimeCode;
        if (lastVideoEndTimeCode.IsLargerThan(videoClip.StartTimeCode) || 
            lastVideoEndTimeCode.IsEqualTo(videoClip.StartTimeCode))
        {
            throw new Error("Video clips cannot overlap.");
        }

        this.VideoClips.push(videoClip);
    }
    
}