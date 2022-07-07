import { Component, OnInit } from '@angular/core';
import { VideoStandardService } from '../../services/video-standards/video-standard.service';
import { VideoDefinitionService } from '../../services/video-definitions/video-definition.service';
import { ShowReelsService } from '../../services/ShowReels/show-reels.service';

@Component({
  selector: 'app-show-reel-editor',
  templateUrl: './show-reel-editor.component.html',
  styleUrls: ['./show-reel-editor.component.css']
})
export class ShowReelEditorComponent implements OnInit {

  constructor(
    private videoDefinitionService: VideoDefinitionService,
    private videoStandardService: VideoStandardService,
    private showReelService: ShowReelsService) { }

  ngOnInit(): void {
    this.videoDefinitionService.get().subscribe(res => {
      console.log(res);
    });

    this.videoStandardService.get().subscribe(res => {
      console.log(res);
    });
  }

}
