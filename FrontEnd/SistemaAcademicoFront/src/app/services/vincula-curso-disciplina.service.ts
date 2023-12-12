import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class VinculaCursoDisciplinaService {

  private URL = "http://localhost:5069/api/CursoDisciplina/{idCurso}/{idDisciplina}";

  constructor(private httpCliente: HttpClient) { }

  vincularDisciplinaNoCurso(idCurso: any, idDisciplina: any): Observable<any>{
      return this.httpCliente.post(`http://localhost:5069/api/CursoDisciplina/${idCurso}/${idDisciplina}`, {});
  }


}
