import { Component, OnInit } from '@angular/core';
import { VideoStandardService } from '../../services/video-standards/video-standard.service';
import { VideoDefinitionService } from '../../services/video-definitions/video-definition.service';
import { ShowReelsService } from '../../services/ShowReels/show-reels.service';
import { FormBuilder, FormArray} from '@angular/forms';
import { KeyValuePair } from 'src/app/services/models/key-value-pair';
import { VideoClip } from 'src/app/services/models/video-clip';
import { TimeCode } from 'src/app/services/models/time-code';
import { ShowReel } from 'src/app/services/models/show-reel';

@Component({
  selector: 'app-show-reel-editor',
  templateUrl: './show-reel-editor.component.html',
  styleUrls: ['./show-reel-editor.component.css']
})
export class ShowReelEditorComponent implements OnInit {
  frameRates = new Map<number, number>();

  showReelForm = this.formBuilder.group({
    name: [''],
    description: [''],
    videoDefinition: [''],
    videoStandard: [''],
    totalDuration: [''],
    videoClips: this.formBuilder.array([
      this.formBuilder.group({
        clipName:[''],
        clipDescription: [''],
        clipVideoDefinition: [''],
        clipVideoStandard:[''],
        clipStartTimeCodeHours:[''],
        clipStartTimeCodeMinutes:[''],
        clipStartTimeCodeSeconds:[''],
        clipStartTimeCodeFrames:[''],
        clipEndTimeCodeHours:[''],
        clipEndTimeCodeMinutes:[''],
        clipEndTimeCodeSeconds:[''],
        clipEndTimeCodeFrames:['']
      })
    ])
  });

  videoDefinitions?: KeyValuePair[];
  videoStandards?: KeyValuePair[];

  constructor(
    private videoDefinitionService: VideoDefinitionService,
    private videoStandardService: VideoStandardService,
    private showReelService: ShowReelsService,
    private formBuilder: FormBuilder) {
      this.frameRates.set(1, 25);
      this.frameRates.set(2, 30);
     }

  ngOnInit(): void {
    this.videoDefinitionService.get().subscribe(response => {
      this.videoDefinitions = response
    });

    this.videoStandardService.get().subscribe(response => {
      this.videoStandards = response;
    });
  }

  public get videoClips(){
    return this.showReelForm.get('videoClips') as FormArray;
  }

  AddClip() {
    this.videoClips.push(this.formBuilder.group({
      clipName:[''],
      clipDescription: [''],
      clipVideoDefinition: [''],
      clipVideoStandard:[''],
      clipStartTimeCodeHours:[''],
      clipStartTimeCodeMinutes:[''],
      clipStartTimeCodeSeconds:[''],
      clipStartTimeCodeFrames:[''],
      clipEndTimeCodeHours:[''],
      clipEndTimeCodeMinutes:[''],
      clipEndTimeCodeSeconds:[''],
      clipEndTimeCodeFrames:['']
    }));
  }

  removeClip(i: number) {
    if(this.videoClips.length > 1){
      this.videoClips.removeAt(i);
    }
  }

  onSubmit() {
    let clips = this.showReelForm.value.videoClips?.map(v => {
      var startTimeCode = new TimeCode(
        parseInt(v.clipStartTimeCodeHours??''),
        parseInt(v.clipStartTimeCodeMinutes??''),
        parseInt(v.clipStartTimeCodeSeconds??''),
        parseInt(v.clipStartTimeCodeFrames??''),
        this.frameRates.get(parseInt(v.clipVideoStandard??''))??0
      );
      var endTimeCode = new TimeCode(
        parseInt(v.clipEndTimeCodeHours??''),
        parseInt(v.clipEndTimeCodeMinutes??''),
        parseInt(v.clipEndTimeCodeSeconds??''),
        parseInt(v.clipEndTimeCodeFrames??''),
        this.frameRates.get(parseInt(v.clipVideoStandard??''))??0
      );

      return new VideoClip(v.clipName ?? '', v.clipDescription ?? '', parseInt(v.clipVideoDefinition??''), parseInt(v.clipVideoStandard??''), startTimeCode, endTimeCode);
    });

    var showReel = new ShowReel(
      this.showReelForm.value.name ?? '',
      this.showReelForm.value.description ?? '',
      parseInt(this.showReelForm.value.videoDefinition ?? ''),
      parseInt(this.showReelForm.value.videoStandard ?? ''),
      clips ?? []
    );
    console.log(showReel);
  }

}
