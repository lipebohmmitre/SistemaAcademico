import { CursoService } from './../../services/curso.service';
import { SubCategoriaService } from './../../services/sub-categoria.service';
import { Component } from '@angular/core';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatSelectModule} from '@angular/material/select';
import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';
import { NgFor } from '@angular/common';
import { FormBuilder, FormsModule, ReactiveFormsModule } from '@angular/forms';


@Component({
  selector: 'app-add-curso',
  standalone: true,
  imports: [MatFormFieldModule, MatSelectModule, MatInputModule, MatButtonModule, NgFor, FormsModule, ReactiveFormsModule],
  templateUrl: './add-curso.component.html',
  styleUrl: './add-curso.component.css'
})
export class AddCursoComponent {

  subCategorias: any[] = [];

  nome: string = "";
  descricao: string = "";
  subCategoriaId: number = 0;

  constructor(private subCategoriaService: SubCategoriaService, private cursoService: CursoService, private formBuilder: FormBuilder) { }

  cadastroCursoForm = this.formBuilder.group({
    nome: "",
    descricao: "",
    subCategoriaId: 0
  });


  ngOnInit(){
    this.subCategoriaService.getCursosAndSubCategoria().subscribe(data => {
      data.forEach((element: any) => {
        this.subCategorias.push(element);
        console.log("elementos ", element);
      });
    });
    console.log(this.subCategorias);
  }

  salvar(){
    console.log(this.cadastroCursoForm.value);
    this.cursoService.postCurso(this.cadastroCursoForm.value).subscribe(data => {
      console.log(data);
    });
  }


}
