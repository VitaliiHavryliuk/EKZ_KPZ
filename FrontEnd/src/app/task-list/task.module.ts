import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TaskListComponent } from './task-list.component';
import {MatCardModule} from '@angular/material/card';
import {MatSnackBarModule} from '@angular/material/snack-bar';



@NgModule({
  declarations: [
    TaskListComponent
  ],
  imports: [
    CommonModule,
    MatCardModule,
    MatSnackBarModule
  ],
  exports:[
    TaskListComponent
  ]
})
export class TaskModule { }
