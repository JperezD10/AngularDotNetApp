import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { PagesComponent } from './pages.component';
import { RouterModule } from '@angular/router';
import { MoviesComponent } from './movies/movies.component';


@NgModule({
  declarations: [
    HomeComponent,
    PagesComponent,
    MoviesComponent
  ],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports:[
    HomeComponent
  ]
})
export class PagesModule { }
