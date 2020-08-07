import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';

import {CampusCommunityModel} from '../models';
import {CampusCommunityService} from '../services/campusCommunity.service';

@Component({
  selector: 'app-campus-details',
  templateUrl: './campus-details.component.html',
  styleUrls: ['./campus-details.component.css'],
  providers: [FormBuilder]
})
export class CampusDetailsComponent implements OnInit, OnDestroy {
  fileToUpload: any;
  imageUrl: any;

  formGroup: FormGroup;
  isAddMode: boolean;
  photos: Blob[] = [];

  private routeSub: Subscription = new Subscription();

  get description(): string {
    return this.formGroup.get('description').value;
  }

  get isFormDisabled(): boolean {
    return this.formGroup.disabled;
  }

  public goToPage(page: string): void {
    this.router.navigate([page]);
  }

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private formBuilder: FormBuilder,
    private service: CampusCommunityService) { }

  ngOnInit(): void {
    this.formGroup = this.formBuilder.group({
      id: new FormControl(),
      title: new FormControl(),
      description: new FormControl(),
  });
  if (this.router.url === '/create-community') {
    this.isAddMode = true;
  } else {
    //Getting id from url
    this.routeSub = this.activatedRoute.params.subscribe(params => {
      //Getting details for the trip with the id found
      this.service.get(params['id']).subscribe((data: CampusCommunityModel) => {
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
      this.router.navigate(['community']);
    } else {
      this.service.patch(this.formGroup.getRawValue()).subscribe();
    }

    this.photos.push(this.imageUrl);
    this.imageUrl = null;
    this.formGroup.disable();
  }

  handleFileInput(file: FileList) {
    this.fileToUpload = file.item(0);

    let reader = new FileReader();
    reader.onload = (event: any) => {
      this.imageUrl = event.target.result;
    }
    reader.readAsDataURL(this.fileToUpload);
  }

}
