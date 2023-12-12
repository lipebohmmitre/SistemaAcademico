import { VinculaCursoDisciplinaService } from './../../services/vincula-curso-disciplina.service';
import { CursoService } from './../../services/curso.service';
import { Component } from '@angular/core';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatSelectModule} from '@angular/material/select';
import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';
import { NgFor, NgIf } from '@angular/common';
import { FormBuilder, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DisciplinaService } from '../../services/disciplina.service';
import {MatListModule} from '@angular/material/list';



@Component({
  selector: 'app-vincular-disciplina-curso',
  standalone: true,
  imports: [MatFormFieldModule, MatSelectModule, MatInputModule, MatButtonModule, NgFor, NgIf, FormsModule, ReactiveFormsModule, MatListModule],
  templateUrl: './vincular-disciplina-curso.component.html',
  styleUrl: './vincular-disciplina-curso.component.css'
})
export class VincularDisciplinaCursoComponent {

  cursos: any[] = [];
  disciplinas: any[] = [];
  idCurso: number = 0;
  idDisciplina: number = 0;
  idsDisciplinas: number[] = [];

  exibeDiv: boolean = false;


  constructor(private formBuilder: FormBuilder,
    private cursoService: CursoService,
    private disciplinaService: DisciplinaService,
    private vincularService: VinculaCursoDisciplinaService
    ) { }

  vinculoCursoDisciplinaForm = this.formBuilder.group({
    idCurso: 0,
    idDisciplina: 0,
    idsDisciplinas: []
  });

  vinculoCursoDisciplinaListForm = this.formBuilder.group({
    idCurso: 0,
    idsDisciplinas: []
  });

  ngOnInit(){
    this.buscaCursos();
    this.buscaDisciplina();
  }


  buscaCursos(){
    this.cursoService.getCursos().subscribe(data => {
      data.forEach((element: any) => {
        this.cursos.push(element);
      });
    });
  }

  buscaDisciplina(){
    this.disciplinaService.getDisciplinas().subscribe(data => {
      data.forEach((element: any) => {
        this.disciplinas.push(element);
      });
    });
  }

  salvar(){
    this.vincularService.vincularDisciplinaNoCurso(this.vinculoCursoDisciplinaForm.value.idCurso, this.vinculoCursoDisciplinaForm.value.idDisciplina).subscribe(data => {
      console.log(data);
    });
  }

  salvarList(){
    console.log(this.vinculoCursoDisciplinaForm.value);
  }

  exibirEsconderDivs(){
    this.exibeDiv = !this.exibeDiv;
  }
}
