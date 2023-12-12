import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DisciplinaService {

  private URLGET = "http://localhost:5069/api/Disciplina";

  private URLPOST = "http://localhost:5069/api/Disciplina";

  constructor(private httpClient: HttpClient) { }

  getDisciplinas(): Observable<any>{
    return this.httpClient.request('GET', this.URLGET, {responseType:'json'});
  }

  postDisciplina(disc: any): Observable<any>{
    return this.httpClient.post(this.URLPOST, disc);
  }

}
