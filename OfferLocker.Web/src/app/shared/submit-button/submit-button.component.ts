import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
@Component({
  selector: 'app-submit-button',
  templateUrl: './submit-button.component.html',
  styleUrls: ['./submit-button.component.css'],
})
export class SubmitButtonComponent implements OnInit {
  @Input()
  public formState: boolean;

  @Output()
  public onClick: EventEmitter<any> = new EventEmitter();

  constructor(private readonly router: Router) {}

  ngOnInit(): void {}

  public get buttonDisabled(): boolean {
    if (this.formState) {
      return false;
    }
    return true;
  }

  public click(event: any): void {
    console.log('submit button, click');
    this.onClick.emit(event);
  }
}
