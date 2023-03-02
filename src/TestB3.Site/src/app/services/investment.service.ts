import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

const SERVER_URL = environment.APIEndpoint;

@Injectable({
  providedIn: 'root'
})
export class InvestmentService {

  constructor(private http: HttpClient) { }

  simulateCDB(values: any): Observable<any> {
    return this.http.post(`${SERVER_URL}/investimento`, values, httpOptions);
  }
}
