import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CursoService {

  private URL = "http://localhost:5069/cursosDetails";

  private URLDISCIPLINASBYIDCURSO = "http://localhost:5069/api/CursoDisciplina/";

  private URLCADASTRARCURSO = "http://localhost:5069/api/Curso";

  constructor(private httpCliente: HttpClient) { }


  getCursos(): Observable<any>{
    return this.httpCliente.request('GET', this.URLCADASTRARCURSO, {responseType:'json'});
  }


  getCursosAndCategoria(): Observable<any>{
    return this.httpCliente.request('GET', this.URL, {responseType:'json'});
  }

  getDisciplinasByIdCurso(id: number): Observable<any>{
    return this.httpCliente.request('GET', this.URLDISCIPLINASBYIDCURSO + `${id}`, {responseType:'json'});
  }

  postCurso(curso: any): Observable<any>{
    return this.httpCliente.post(this.URLCADASTRARCURSO, curso);
  }

}
