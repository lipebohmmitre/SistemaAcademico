import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TrafegaDadosDisciplinasService {

  private disciplinasSource = new BehaviorSubject<any[]>([]);
  disciplinas$ = this.disciplinasSource.asObservable();

  constructor() { }

  setDisciplinas(disciplinas: any[]) {
    this.disciplinasSource.next(disciplinas);
  }
}
