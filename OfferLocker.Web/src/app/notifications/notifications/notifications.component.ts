import { NotificationsModel } from './../models/notifications.model';
import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { OfferService } from 'src/app/offer/services/offer.service';
import { NotificationsService } from '../services/notifications';
//import { NotifyModel } from '../models/notifications';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-notifications',
  templateUrl: './notifications.component.html',
  styleUrls: ['./notifications.component.css']
})
export class NotificationsComponent implements OnInit {

  public notificationList = []; //din serviciu
  private routeSub: Subscription = new Subscription();

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private service: NotificationsService) {
  }

  ngOnInit(): void {

    this.service.getAll().subscribe((data: NotificationsModel) => {
      this.notificationList = data.results;
    });
  }

  goToOffer(id: string): void {
    console.log(id);
    this.router.navigate(['/offers/${id}']);
  }

  getImage(name: string) {
    if (name.indexOf(' ') != -1) {
      let length = name.indexOf(' ');
      return name.substring(0, length).toLowerCase();
    }
    else return name.toLowerCase();
  }

}
