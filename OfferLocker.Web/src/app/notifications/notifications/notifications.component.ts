import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { OfferService } from 'src/app/offer/services/offer.service';
import { NotificationsService } from '../services/notifications';
import { NotificationsModel } from '../models/notifications.model';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-notifications',
  templateUrl: './notifications.component.html',
  styleUrls: ['./notifications.component.css']
})
export class NotificationsComponent implements OnInit {

  private id;
  public notificationList = []; //din serviciu
  private routeSub: Subscription;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private service: NotificationsService) {
  }

  ngOnInit(): void {
    this.routeSub = this.route.params.subscribe(params => {
      this.id = params['id'];
      console.log(this.id);
    });

    this.service.get(this.id).subscribe((data: NotificationsModel) => {
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
