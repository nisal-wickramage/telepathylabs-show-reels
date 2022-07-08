import { Component, OnInit } from '@angular/core';
import { VideoStandardService } from '../../services/video-standards/video-standard.service';
import { VideoDefinitionService } from '../../services/video-definitions/video-definition.service';
import { ShowReelsService } from '../../services/ShowReels/show-reels.service';
import { FormBuilder, FormArray, Validators} from '@angular/forms';
import { KeyValuePair } from 'src/app/services/models/key-value-pair';
import { VideoClip } from 'src/app/services/models/video-clip';
import { TimeCode } from 'src/app/services/models/time-code';
import { ShowReel } from 'src/app/services/models/show-reel';
import { Router } from '@angular/router';

@Component({
  selector: 'app-show-reel-editor',
  templateUrl: './show-reel-editor.component.html',
  styleUrls: ['./show-reel-editor.component.css']
})
export class ShowReelEditorComponent implements OnInit {

  frameRates = new Map<number, number>();
  totalTime: TimeCode;

  showReelForm = this.formBuilder.group({
    name: ['', [Validators.required]],
    description: ['', [Validators.required]],
    videoDefinition: ['', [Validators.required, Validators.min(1), Validators.max(2)]],
    videoStandard: ['', [Validators.required, Validators.min(1), Validators.max(2)]],
    videoClips: this.formBuilder.array([
      this.formBuilder.group({
        clipName:[''],
        clipDescription: [''],
        clipStartTimeCodeHours:['00', [Validators.required, Validators.min(0), Validators.max(59)]],
        clipStartTimeCodeMinutes:['00', [Validators.required, Validators.min(0), Validators.max(59)]],
        clipStartTimeCodeSeconds:['00', [Validators.required, Validators.min(0), Validators.max(59)]],
        clipStartTimeCodeFrames:['00', [Validators.required, Validators.min(0), Validators.max(59)]],
        clipEndTimeCodeHours:['00', [Validators.required, Validators.min(0), Validators.max(59)]],
        clipEndTimeCodeMinutes:['00', [Validators.required, Validators.min(0), Validators.max(59)]],
        clipEndTimeCodeSeconds:['00', [Validators.required, Validators.min(0), Validators.max(59)]],
        clipEndTimeCodeFrames:['00', [Validators.required, Validators.min(0), Validators.max(59)]]
      })
    ])
  });

  videoDefinitions?: KeyValuePair[];
  videoStandards?: KeyValuePair[];

  constructor(
    private videoDefinitionService: VideoDefinitionService,
    private videoStandardService: VideoStandardService,
    private showReelService: ShowReelsService,
    private formBuilder: FormBuilder,
    private router: Router) {
      this.frameRates.set(1, 25);
      this.frameRates.set(2, 30);

      this.totalTime = new TimeCode(0,0,0,0,2);
     }

  ngOnInit(): void {
    this.videoDefinitionService.get().subscribe(response => {
      this.videoDefinitions = response
    });

    this.videoStandardService.get().subscribe(response => {
      this.videoStandards = response;
    });

    var self = this;
    this.videoClips.disable();


    this.showReelForm.get('videoStandard')?.valueChanges.subscribe(v => {
      if(parseInt(v ?? '')> 0)
      {
        this.totalTime = new TimeCode(0,0,0,0,this.frameRates.get(parseInt(v ?? ''))??0);
        self.videoClips.enable();
      }
    });

    this.videoClips.valueChanges.subscribe(v => {
        var timeInfo = v as VideoClipTimeCodes[];
        var lastTimeInfo = timeInfo[timeInfo.length - 1];

        if(this.videoClips.enabled)
        {
          var timeCode = new TimeCode(
            parseInt(lastTimeInfo.clipEndTimeCodeHours ?? ''),
            parseInt(lastTimeInfo.clipEndTimeCodeMinutes ?? ''),
            parseInt(lastTimeInfo.clipEndTimeCodeSeconds ?? ''),
            parseInt(lastTimeInfo.clipEndTimeCodeFrames ?? ''),
            this.totalTime.FramesPerSecond
          );
          
          this.totalTime = timeCode;
        }
      });
  }

  public get videoClips(){
    return this.showReelForm.get('videoClips') as FormArray;
  }

  AddClip() {
    var startTimeCode = this.totalTime.Add(new TimeCode(0,0,0,1, this.totalTime.FramesPerSecond));
    console.log(startTimeCode);
    var endTimeCode = this.totalTime.Add(new TimeCode(0,0,0,2, this.totalTime.FramesPerSecond));
    console.log(endTimeCode);
    this.videoClips.push(this.formBuilder.group({
      clipName:[''],
      clipDescription: [''],
      clipVideoDefinition: [''],
      clipVideoStandard:[''],
      clipStartTimeCodeHours:[startTimeCode.Hours],
      clipStartTimeCodeMinutes:[startTimeCode.Minutes],
      clipStartTimeCodeSeconds:[startTimeCode.Seconds],
      clipStartTimeCodeFrames:[startTimeCode.Frames],
      clipEndTimeCodeHours:[endTimeCode.Hours],
      clipEndTimeCodeMinutes:[endTimeCode.Minutes],
      clipEndTimeCodeSeconds:[endTimeCode.Seconds],
      clipEndTimeCodeFrames:[endTimeCode.Frames]
    }));

    this.totalTime = endTimeCode;
  }

  removeClip(i: number) {
    if(this.videoClips.length > 1){
      this.videoClips.removeAt(i);
    }
  }

  onSubmit() {
    try{
      let clips = this.showReelForm.value.videoClips?.map(v => {
        var startTimeCode = new TimeCode(
          parseInt(v.clipStartTimeCodeHours??''),
          parseInt(v.clipStartTimeCodeMinutes??''),
          parseInt(v.clipStartTimeCodeSeconds??''),
          parseInt(v.clipStartTimeCodeFrames??''),
          this.frameRates.get(parseInt(this.showReelForm.value.videoStandard??''))??0
        );
        var endTimeCode = new TimeCode(
          parseInt(v.clipEndTimeCodeHours??''),
          parseInt(v.clipEndTimeCodeMinutes??''),
          parseInt(v.clipEndTimeCodeSeconds??''),
          parseInt(v.clipEndTimeCodeFrames??''),
          this.frameRates.get(parseInt(this.showReelForm.value.videoStandard??''))??0
        );
  
        return new VideoClip(
          v.clipName ?? '', 
          v.clipDescription ?? '', 
          parseInt(this.showReelForm.value.videoDefinition??''), 
          parseInt(this.showReelForm.value.videoStandard??''), 
          startTimeCode, 
          endTimeCode);
      });
  
      var showReel = new ShowReel(
        this.showReelForm.value.name ?? '',
        this.showReelForm.value.description ?? '',
        parseInt(this.showReelForm.value.videoDefinition ?? ''),
        parseInt(this.showReelForm.value.videoStandard ?? ''),
        clips ?? []
      );
      console.log(showReel);
      this.showReelService.save(showReel).subscribe(response => {
        console.log(response);
        this.router.navigate(['list-show-reels']);
      });
    }catch(error: any){
      alert(error);
    }
  }

  get isVideoStandardSelected(): boolean {
    if(this.showReelForm.value.videoStandard)
    {
      return parseInt(this.showReelForm.value.videoStandard) > 0;
    }
    return false;
  }

}

interface VideoClipTimeCodes {
  clipStartTimeCodeHours: string;
  clipStartTimeCodeMinutes: string;
  clipStartTimeCodeSeconds: string;
  cliStartTimeCodeFrames: string;
  clipEndTimeCodeHours: string;
  clipEndTimeCodeMinutes: string;
  clipEndTimeCodeSeconds: string;
  clipEndTimeCodeFrames: string;
}