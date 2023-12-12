import { Component } from '@angular/core';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatSelectModule} from '@angular/material/select';
import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';
import { NgFor } from '@angular/common';
import { FormBuilder, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DisciplinaService } from '../../services/disciplina.service';


@Component({
  selector: 'app-add-disciplina',
  standalone: true,
  imports: [MatFormFieldModule, MatSelectModule, MatInputModule, MatButtonModule, NgFor, FormsModule, ReactiveFormsModule],
  templateUrl: './add-disciplina.component.html',
  styleUrl: './add-disciplina.component.css'
})
export class AddDisciplinaComponent {

  nome: string = "";
  cargaHoraria: number = 0;
  tipoDisciplina: string = "";

  constructor(private formBuilder: FormBuilder, private disciplinaService: DisciplinaService) { }

  cadastroFormDisciplinas = this.formBuilder.group({
    nome: "",
    cargaHoraria: 0,
    tipoDisciplina: ""
  });

  salvar(){
    this.disciplinaService.postDisciplina(this.cadastroFormDisciplinas.value).subscribe(data => {
      console.log(data);
    });
  }

}
