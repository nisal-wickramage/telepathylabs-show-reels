import { Component, Input, OnInit } from '@angular/core';
import { ShowReel } from 'src/app/services/models/show-reel';

@Component({
  selector: 'app-show-reel-information',
  templateUrl: './show-reel-information.component.html',
  styleUrls: ['./show-reel-information.component.css']
})
export class ShowReelInformationComponent implements OnInit {

  @Input() showReel: ShowReel| null = null;

  constructor() { }

  ngOnInit(): void {
    console.log(this.showReel);
    console.log(this.showReel?.TotalDuration);
  }

}
