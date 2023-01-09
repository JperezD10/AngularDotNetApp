import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NoPageFoundComponent } from './no-page-found/no-page-found.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    NoPageFoundComponent
  ],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    NoPageFoundComponent
  ]
})
export class SharedModule { }
