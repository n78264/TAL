import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { MonthlyPremiumComponent } from './calculator/monthly-premium.component';

@NgModule({
  declarations: [
    AppComponent,
    MonthlyPremiumComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [MonthlyPremiumComponent]
})
export class AppModule { }
