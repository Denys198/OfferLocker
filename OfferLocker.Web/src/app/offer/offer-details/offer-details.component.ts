import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';

import {OfferModel} from '../models';
import {OfferService } from '../services/offer.service';

@Component({
  selector: 'app-offer-details',
  templateUrl: './offer-details.component.html',
  styleUrls: ['./offer-details.component.css'],
  providers: [FormBuilder]
})
export class OfferDetailsComponent implements OnInit {
  formGroup: FormGroup;
  isAddMode: boolean;

  private routeSub: Subscription = new Subscription();

  get description(): string {
    return this.formGroup.get('description').value;
  }

  get price(): number {
    return this.formGroup.get("price").value;
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
    private service: OfferService) { }

  ngOnInit(): void {
    this.formGroup = this.formBuilder.group({
      id: new FormControl(),
      name: new FormControl('',[Validators.required]),
      description: new FormControl('',[Validators.required]),
      price: new FormControl('',[Validators.required]),
    });

    if (this.router.url === '/create-offer') {
      this.isAddMode = true;
    } else {
      this.routeSub = this.activatedRoute.params.subscribe((params) => {
        this.service.get(params['id']).subscribe((data: OfferModel) => {
          this.formGroup.patchValue(data);
        })
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
      this.router.navigate(['offer-list']);
    } else {
      this.service.patch(this.formGroup.getRawValue()).subscribe();
    }
    this.formGroup.disable();
  }
}
