import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SharedModule } from 'src/app/shared/shared.module';
import { CampusCommunityModel, CampusCommunitiesModel } from '../models';
import { CampusCommunityService } from '../services/campusCommunity.service';

@Component({
  selector: 'app-campus-list',
  templateUrl: './campus-list.component.html',
  styleUrls: ['./campus-list.component.css'],
  providers: [CampusCommunityService],
})
export class CampusListComponent implements OnInit {

  public communityList: CampusCommunityModel[];

  constructor(
    private router: Router,
    private service: CampusCommunityService
  ) { }

  ngOnInit(): void {
    this.service.getAll().subscribe((data: CampusCommunitiesModel) => {
      this.communityList = data.results;
    });
  }

  goToCommunity(id: string): void {
    console.log(id);
    this.router.navigate(['/communities/${id}']);
  }
}
