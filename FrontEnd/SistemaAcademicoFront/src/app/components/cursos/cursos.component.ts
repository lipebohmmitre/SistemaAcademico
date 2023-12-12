import { TrafegaDadosDisciplinasService } from './../../services/trafega-dados-disciplinas.service';
import { NgFor, NgIf } from '@angular/common';
import { CursoService } from './../../services/curso.service';
import { Component, NgModule } from '@angular/core';
import { DisciplinaComponent } from '../disciplina/disciplina.component';
import {MatButtonModule} from '@angular/material/button';

@Component({
  selector: 'app-cursos',
  standalone: true,
  imports: [NgFor, NgIf, DisciplinaComponent, MatButtonModule],
  templateUrl: './cursos.component.html',
  styleUrl: './cursos.component.css'
})
export class CursosComponent {

  cursos: any;
  mostrar: boolean = false;
  disciplinas: any[] = [];
  displayedColumns = ['nome', 'descricao', 'subCategoria.nome', 'subCategoria.categoria.nome', 'cursoId'];

  constructor(private cursoService: CursoService, private trafegaDados: TrafegaDadosDisciplinasService) { }

  ngOnInit(){
    this.cursoService.getCursosAndCategoria().subscribe(data => {
      this.cursos = data;
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
