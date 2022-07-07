import { Component, OnInit } from '@angular/core';
import { KeyValuePair } from 'src/app/services/models/key-value-pair';
import { ShowReel } from 'src/app/services/models/show-reel';
import { VideoDefinitionService } from 'src/app/services/video-definitions/video-definition.service';
import { VideoStandardService } from 'src/app/services/video-standards/video-standard.service';
import { ShowReelsService } from '../../services/ShowReels/show-reels.service';

@Component({
  selector: 'app-show-reel-list',
  templateUrl: './show-reel-list.component.html',
  styleUrls: ['./show-reel-list.component.css']
})
export class ShowReelListComponent implements OnInit {

  constructor(
    private showReelService: ShowReelsService,
    private videoDefinitionService: VideoDefinitionService,
    private videoStandardService: VideoStandardService) { }

  showReels?: ShowReel[];
  videoDefinitions?: KeyValuePair[];
  videoStandards?: KeyValuePair[];

  ngOnInit(): void {
    this.showReelService.get().subscribe(response => {
      this.showReels = response;
    });

    this.videoDefinitionService.get().subscribe(response => {
      this.videoDefinitions = response;
    });

    this.videoStandardService.get().subscribe(response => {
      this.videoStandards = response;
    });
  }

}
