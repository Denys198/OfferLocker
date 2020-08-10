import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-button',
  templateUrl: './button.component.html',
  styleUrls: ['./button.component.css']
})
export class ButtonComponent implements OnInit {

  @Input() public buttonText: string = "";

  constructor(
    private readonly router: Router
  ) { }

  ngOnInit(): void {
  }

}
