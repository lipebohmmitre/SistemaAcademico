import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SubCategoriaService {

  private URL = "http://localhost:5069/api/SubCategoria";

  private URLPOST = "http://localhost:5069/api/SubCategoria";

  constructor(private httpCliente: HttpClient) { }

  getCursosAndSubCategoria(): Observable<any>{
    return this.httpCliente.request('GET', this.URL, {responseType:'json'});
  }

  postSubCategoria(subCategoria: any): Observable<any>{
    return this.httpCliente.post(this.URLPOST, subCategoria);
  }


}
