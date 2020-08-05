import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon'; import { NgModule, CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA } from '@angular/core';

import { HeaderComponent } from './header/header.component';
import { TileComponent } from './tile/tile.component';
import { FooterComponent } from './footer/footer.component';
import { ReviewComponent } from './review/review.component';
import { ButtonComponent } from './button/button.component';

@NgModule({
  declarations: [TileComponent, HeaderComponent, FooterComponent, ReviewComponent, ButtonComponent],
  imports: [CommonModule, MatIconModule],
  exports: [TileComponent, HeaderComponent, FooterComponent, ReviewComponent, ButtonComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA]
})
export class SharedModule { }
