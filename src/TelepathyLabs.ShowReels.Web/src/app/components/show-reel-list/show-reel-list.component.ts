import { Component, OnInit } from '@angular/core';
import { ShowReel } from 'src/app/services/models/show-reel';
import { ShowReelsService } from '../../services/ShowReels/show-reels.service';

@Component({
  selector: 'app-show-reel-list',
  templateUrl: './show-reel-list.component.html',
  styleUrls: ['./show-reel-list.component.css']
})
export class ShowReelListComponent implements OnInit {

  constructor(private showReelService: ShowReelsService) { }

  showReels?: ShowReel[];

  ngOnInit(): void {
    this.showReelService.get().subscribe(response => {
      this.showReels = response;
    });
  }

}
