import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'tile',
  templateUrl: './tile.component.html',
  styleUrls: ['./tile.component.css'],
})
export class TileComponent implements OnInit {

  @Input() public imageLink: string = 'assets/images/placeholder.png';
  @Input() public tileName: string = '';

  public hasPicture: boolean;

  ngOnInit(): void {
  }
}

