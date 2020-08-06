import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit {
  public projectTitle: string = "OfferLocker";
  constructor(
    public readonly userService: UserService,
    private readonly router: Router
  ) { }

  ngOnInit() {
  }

  logout(): void {
    this.userService.email.next(null);
    this.router.navigate(['authentication']);
  }
}
