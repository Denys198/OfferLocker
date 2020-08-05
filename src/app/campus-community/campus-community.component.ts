import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SharedModule } from 'src/app/shared/shared.module';

@Component({
  selector: 'app-campus-community',
  templateUrl: './campus-community.component.html',
  styleUrls: ['./campus-community.component.css']
})
export class CampusCommunityComponent implements OnInit {

  public placeholder: string = "../assets/images/placeholder.png";
  public userDescription: string = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

  public communityName: string = "Campus Tudor Vladimirescu";
  public communityType: string = "University";

  constructor() { }

  ngOnInit(): void {
  }

}
