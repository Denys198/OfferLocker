import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { Router } from '@angular/router';
import {OfferService } from '../services/offer.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {
  public formGroup: FormGroup;
  constructor(
    private router: Router,
    private service: OfferService,
  ) { }

  ngOnInit(): void {
    this.formGroup = new FormGroup({
      offerName: new FormControl('', [Validators.required]),
      offerDescription: new FormControl('', []),
      offerPrice: new FormControl('', [Validators.required]),
    });
  }

  public get isFormValid(): boolean {
    return this.formGroup.valid;
  }

  public clicked(): void {
    console.log(this.formGroup.value);
  }

}
