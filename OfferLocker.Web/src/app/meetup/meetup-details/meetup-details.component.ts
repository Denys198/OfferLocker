import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { Router, ActivatedRoute } from '@angular/router';

import { MeetupService } from '../services/meetup.service';
import { MeetupModel } from '../models';

@Component({
  selector: 'app-meetup-details',
  templateUrl: './meetup-details.component.html',
  styleUrls: ['./meetup-details.component.scss'],
  providers: [FormBuilder],
})
export class MeetupDetailsComponent implements OnInit {
  formGroup: FormGroup;
  isAddMode: boolean;

  private routeSub: Subscription = new Subscription();

  get description(): string {
    return this.formGroup.get('description').value;
  }

  get date(): Date {
    return this.formGroup.get('date').value;
  }

  public get isFormValid(): boolean {
    return this.formGroup.valid;
  }

  get isFormDisabled(): boolean {
    return this.formGroup.disabled;
  }

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private formBuilder: FormBuilder,
    private service: MeetupService) { }

  ngOnInit(): void {
    this.formGroup = this.formBuilder.group({
      id: new FormControl(),
      name: new FormControl('', [Validators.required]),
      description: new FormControl('', [Validators.required]),
      date: new FormControl('', [Validators.required]),
    });

    if (this.router.url == 'meetups/create') {
      this.isAddMode = true;
    } else {
      this.routeSub = this.activatedRoute.params.subscribe((params) => {
        this.service.get(params['id']).subscribe((data: MeetupModel) => {
          this.formGroup.patchValue(data);
        });
        this.formGroup.disable();
      });
      this.isAddMode = false;
    }
  }

  ngOnDestroy(): void {
    this.routeSub.unsubscribe();
  }

  startUpdating() {
    this.formGroup.enable();
  }

  save() {
    if (this.isAddMode) {
      this.service.post(this.formGroup.getRawValue()).subscribe();
      this.router.navigate(['meetup-list']);
    } else {
      this.service.patch(this.formGroup.getRawValue()).subscribe();
    }
    this.formGroup.disable();
  }
}
