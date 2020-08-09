import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import {MeetupService } from '../services/meetup.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css'],
})
export class CreateComponent implements OnInit {
  public form: FormGroup;
  constructor(
    private router: Router,
    private service: MeetupService,
  ) {}

  ngOnInit(): void {
    this.form = new FormGroup({
      meetupName: new FormControl('', [Validators.required]),
      meetupDescription: new FormControl('', [Validators.required]),
      meetupDate: new FormControl('',[Validators.required]),
    });
  }

  public get isFormValid(): boolean {
    return this.form.valid;
  }

  public clicked(): void {
    console.log(this.form.value);
  }
}
