import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'tile',
  templateUrl: './tile.component.html',
  styleUrls: ['./tile.component.css'],
})
export class TileComponent implements OnInit {

  @Input() public label: string = '';
  @Input() public icon: string = '';
  @Input() public background: string = '';

  public placeholder: string = "../../assets/images/placeholder.png";
  public tileTitle: string = "This is a tile";

  public hasPicture: boolean;

  ngOnInit(): void {
    if (this.background) {
      this.background = "url('" + this.background + "')";
    } else {
      this.background = "linear-gradient(to bottom right, #27ae60, #87bc27)";
    }
  }
}

