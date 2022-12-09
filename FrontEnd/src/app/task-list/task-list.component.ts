import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ITask } from 'src/interfaces/task.interface';
import { TaskListService } from 'src/app/task-list.service';
import { Time } from '@angular/common';

@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.scss']
})
export class TaskListComponent implements OnInit {
  tasks: ITask[] = [];
  constructor(
    private _snackBar: MatSnackBar, private taskService: TaskListService
  ) { }

  ngOnInit(): void {
    this.taskService.getTasks()
    .subscribe(data => this.tasks = data);
  }

  deleteTask(task: ITask)
  {
    this.taskService.deleteTask(task.id!)
    .subscribe(data => {
      this.tasks = data
      this._snackBar.open('Task ' + task.id + ' has been deleted!');
    });
  }

  updateTask(id : number, status: string, time: Time, text: string)
  {
    let task = {
      id : id,
      time : time,
      status : status,
      text : text
    }
    this.taskService.updateTask(task)
    .subscribe(data => {
      this.tasks = data
      this._snackBar.open('Task ' + id + ' has been updated!');
    })
  }

  addTask(status: string,time:Time, text: string)
  {
    this.taskService.createTask({id:null,status:status, text:text, time:time})
    .subscribe(data => {
      this.tasks = data
      this._snackBar.open('Task has been added!');
    })
  }
}
