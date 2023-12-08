import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CursoService {

  private URL = "http://localhost:5069/cursosDetails";

  constructor(private httpCliente: HttpClient) { }

  getCursosAndCategoria(): Observable<any>{
    return this.httpCliente.request('GET', this.URL, {responseType:'json'});
  }

}
