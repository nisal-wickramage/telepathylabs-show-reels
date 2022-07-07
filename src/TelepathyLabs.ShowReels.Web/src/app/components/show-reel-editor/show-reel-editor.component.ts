import { Component, OnInit } from '@angular/core';
import { VideoStandardService } from '../../services/video-standards/video-standard.service';
import { VideoDefinitionService } from '../../services/video-definitions/video-definition.service';
import { ShowReelsService } from '../../services/ShowReels/show-reels.service';
import { FormGroup, FormControl , FormBuilder, FormArray} from '@angular/forms';
import { KeyValuePair } from 'src/app/services/models/key-value-pair';

@Component({
  selector: 'app-show-reel-editor',
  templateUrl: './show-reel-editor.component.html',
  styleUrls: ['./show-reel-editor.component.css']
})
export class ShowReelEditorComponent implements OnInit {
  showReelForm = this.formBuilder.group({
    name: [''],
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
    private formBuilder: FormBuilder) { }

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
    console.log(this.showReelForm.value);
  }

}
