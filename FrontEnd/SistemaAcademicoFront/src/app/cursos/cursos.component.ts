import { TrafegaDadosDisciplinasService } from './../services/trafega-dados-disciplinas.service';
import { NgFor, NgIf } from '@angular/common';
import { CursoService } from './../services/curso.service';
import { Component } from '@angular/core';
import { DisciplinaComponent } from '../disciplina/disciplina.component';

@Component({
  selector: 'app-cursos',
  standalone: true,
  imports: [NgFor, NgIf, DisciplinaComponent],
  templateUrl: './cursos.component.html',
  styleUrl: './cursos.component.css'
})
export class CursosComponent {

  cursos: any;
  mostrar: boolean = false;
  disciplinas: any[] = [];

  constructor(private cursoService: CursoService, private trafegaDados: TrafegaDadosDisciplinasService) { }

  ngOnInit(){
    this.cursoService.getCursosAndCategoria().subscribe(data => {
      this.cursos = data;
      console.log(this.cursos);
    });
  }

  mostrarComponente(id: number){
    while(this.disciplinas.length){
      this.disciplinas.pop();
    }
    this.mostrar = true;

    this.cursoService.getDisciplinasByIdCurso(id).subscribe(data => {

      data.disciplinas.forEach((item: any) => {
        this.disciplinas.push(item);
      });
    });

    this.trafegaDados.setDisciplinas(this.disciplinas);
  }

  fechar(){
    this.mostrar = false;
  }

}
