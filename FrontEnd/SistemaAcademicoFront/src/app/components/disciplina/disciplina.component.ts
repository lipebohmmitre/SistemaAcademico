import { NgFor } from '@angular/common';
import { TrafegaDadosDisciplinasService } from './../../services/trafega-dados-disciplinas.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-disciplina',
  standalone: true,
  imports: [NgFor],
  templateUrl: './disciplina.component.html',
  styleUrl: './disciplina.component.css'
})
export class DisciplinaComponent {

  disciplinas: any[] =[];

  constructor(private trafegaDados: TrafegaDadosDisciplinasService) {}

  ngOnInit(){
    this.trafegaDados.disciplinas$.subscribe(data => {
      this.disciplinas = data;
      console.log("data: ", data);
    });
  }

}
