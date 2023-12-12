import { Component } from '@angular/core';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatSelectModule} from '@angular/material/select';
import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';
import { FormBuilder, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CategoriaService } from '../../services/categoria.service';

@Component({
  selector: 'app-add-categoria',
  standalone: true,
  imports: [MatFormFieldModule, MatSelectModule, MatInputModule, MatButtonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './add-categoria.component.html',
  styleUrl: './add-categoria.component.css'
})
export class AddCategoriaComponent {

  nome: string = "";
  descricao: string = "";

  constructor(private formBuilder: FormBuilder, private categoriaService: CategoriaService) { }

  cadastroCategoriaForm = this.formBuilder.group({
    nome: "",
    descricao: ""
  });



  salvar(){
    console.log("log ", this.cadastroCategoriaForm.value);
    this.categoriaService.postCategoria(this.cadastroCategoriaForm.value).subscribe(data => {
      console.log("data ", data);
    });
  }
}
