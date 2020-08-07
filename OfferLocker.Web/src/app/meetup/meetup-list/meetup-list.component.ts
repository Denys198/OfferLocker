import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { MeetupModel, MeetupsModel } from '../models';
import { MeetupService } from '../services/meetup.service';

@Component({
  selector: 'app-meetup-list',
  templateUrl: './meetup-list.component.html',
  styleUrls: ['./meetup-list.component.scss'],
  providers: [MeetupService],
})
export class MeetupListComponent implements OnInit {
  public meetupList: MeetupModel[];

  constructor(private router: Router, private service: MeetupService) { }

  public ngOnInit(): void {
    this.service.getAll().subscribe((data: MeetupsModel) => {
      this.meetupList = data.results;
    });
  }

  goToMeetup(id: string): void {
    console.log(id);
    this.router.navigate([`/meetup/details/${id}`]);
  }
}
