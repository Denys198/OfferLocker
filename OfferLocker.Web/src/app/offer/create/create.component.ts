import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {
  public form: FormGroup;
  constructor() { }

  ngOnInit(): void {
    this.form = new FormGroup({
      offerName: new FormControl('', [Validators.required]),
      offerDetails: new FormControl('', []),
    });
  }

  public get isFormValid(): boolean {
    return this.form.valid;
  }

  public clicked(): void {
    console.log(this.form.value);
  }

}
