import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoriaService {

  private URLPOST = "http://localhost:5069/api/Categoria";

  private URLGETALL = "http://localhost:5069/api/Categoria";


  constructor(private httpCliente: HttpClient) { }


  getCategorias(): Observable<any>{
    return this.httpCliente.request('GET', this.URLGETALL, {responseType:'json'});
  }

  postCategoria(categoria: any): Observable<any>{
    return this.httpCliente.post(this.URLPOST, categoria);
  }


}
