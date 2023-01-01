import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NoPageFoundComponent } from './no-page-found/no-page-found.component';



@NgModule({
  declarations: [
    NoPageFoundComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    NoPageFoundComponent
  ]
})
export class SharedModule { }
