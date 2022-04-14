import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { DashboardModule } from '@private/dashboard/dashboard.module';
import { LoginComponent } from '@public/login/login.component';
import { SharedModule } from '@shared/shared.module';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

export const modules = [
  BrowserModule,
  FormsModule,
  ReactiveFormsModule,
  HttpClientModule,
  AppRoutingModule,
  SharedModule,
  DashboardModule
];

export const declarations = [
  AppComponent,
  LoginComponent
];

@NgModule({
  declarations: [declarations],
  imports: [modules],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
