import { Component, Input, OnInit } from '@angular/core';
import { KeyValuePair } from 'src/app/services/models/key-value-pair';
import { ShowReel } from 'src/app/services/models/show-reel';

@Component({
  selector: 'app-show-reel-information',
  templateUrl: './show-reel-information.component.html',
  styleUrls: ['./show-reel-information.component.css']
})
export class ShowReelInformationComponent implements OnInit {

  @Input() showReel?: ShowReel;
  @Input() videoDefinitions?: KeyValuePair[];
  @Input() videoStandards?: KeyValuePair[];

  constructor() { }

  ngOnInit(): void {
  }

  getVideoDefinition(key: number | undefined): string | undefined {
    return this.videoDefinitions?.filter(vd => vd.Key === key)[0].Value;
  }

  getVideoStandard(key: number | undefined): string | undefined {
    return this.videoStandards?.filter(vs => vs.Key === key)[0].Value;
  }

}
