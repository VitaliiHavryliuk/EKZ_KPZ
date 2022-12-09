import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, switchMap } from 'rxjs';
import { ITask } from '../interfaces/task.interface';

@Injectable({
  providedIn: 'root'
})
export class TaskListService {
  private url = "https://localhost:7241/api/v1/"
  constructor(private http: HttpClient) { }

  getTasks(): Observable<ITask[]>{
    return this.http.get<ITask[]>(this.url + "ProjectTask");
  }

  updateTask(body: ITask): Observable<ITask[]>{
    return this.http.put<ITask[]>(this.url + "ProjectTask", body, { responseType: 'json'})
    .pipe(
      switchMap(() => this.getTasks())
    )
  }

  deleteTask(id:number): Observable<ITask[]>
  {
    return this.http.delete<ITask[]>(`${this.url}ProjectTask/${id}`, { responseType: 'json'})
    .pipe(
      switchMap(() => this.getTasks())
    )
  }

  createTask(body: ITask): Observable<ITask[]>
  {
    return this.http.post<ITask[]>(this.url + "ProjectTask", body, { responseType: 'json'})
    .pipe(
      switchMap(() => this.getTasks())
    )
  }
}
