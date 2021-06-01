import { Injectable } from '@angular/core';
import { catchError, retry } from 'rxjs/internal/operators';
import { Cake } from '../Entities/Cake';
import { HttpResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {  throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CakeService {

  private CAKES_SERVICE_URL = "https://localhost:44355";

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  cakes: Cake[] = [];

  constructor(private httpClient: HttpClient) { }

  getCakes(): Observable<Cake[]>  {
    return this.httpClient.get<Cake[]>(this.CAKES_SERVICE_URL+ "/cakes", this.httpOptions).pipe();  
  }

  getCake(id: number) {
    
    return this.httpClient.get<Cake>(this.CAKES_SERVICE_URL+ "/cakes/" + id)
    .pipe(
            catchError(this.handleError<Cake>('getCake')));
  }

  create(cake: Cake): Observable<Cake> {
    return this.httpClient.post<Cake>(this.CAKES_SERVICE_URL + '/cakes/', cake, this.httpOptions)
    .pipe(
          catchError(this.errorHandler)
    )
  } 
  
  delete(id: number){
    return this.httpClient.delete<Cake>(this.CAKES_SERVICE_URL + '/cakes/' + id, this.httpOptions)
    .pipe(
      catchError(this.errorHandler)
    )
  }

  errorHandler(error: any) {
    let errorMessage = '';
    if(error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } 
    else if(error.error?.detail) {

      errorMessage = error.error.detail;
    }
    else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
 }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      this.log(`${operation} failed: ${error.message}`);
        return of(result as T);
    };
  }

  private log(message: string) {
    console.log(message);
  }
}
