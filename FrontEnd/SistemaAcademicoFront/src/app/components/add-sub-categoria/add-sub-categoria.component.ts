import { CategoriaService } from './../../services/categoria.service';
import { Component } from '@angular/core';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatSelectModule} from '@angular/material/select';
import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';
import { NgFor } from '@angular/common';
import { FormBuilder, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SubCategoriaService } from '../../services/sub-categoria.service';


@Component({
  selector: 'app-add-sub-categoria',
  standalone: true,
  imports: [MatFormFieldModule, MatSelectModule, MatInputModule, MatButtonModule, NgFor, FormsModule, ReactiveFormsModule],
  templateUrl: './add-sub-categoria.component.html',
  styleUrl: './add-sub-categoria.component.css'
})
export class AddSubCategoriaComponent {

  categorias: any[] = [];
  nome: string = "";
  descricao: string = "";
  categoriaId: number = 0;

  constructor(private formBuilder: FormBuilder, private categoriaService: CategoriaService, private subCategoriaService: SubCategoriaService) { }

  cadastroFormSubCategoria = this.formBuilder.group({
    nome: "",
    descricao: "",
    categoriaId: 0
  });

  ngOnInit(){
    this.categoriaService.getCategorias().subscribe(data => {
      data.forEach((element: any) => {
        this.categorias.push(element);
      });
    });
  }

  salvar(){
    this.subCategoriaService.postSubCategoria(this.cadastroFormSubCategoria.value).subscribe(data => {
      console.log(data);
    });
  }

}
