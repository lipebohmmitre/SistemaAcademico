import { NgFor } from '@angular/common';
import { SubCategoriaService } from './../../services/sub-categoria.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-sub-categorias',
  standalone: true,
  imports: [NgFor],
  templateUrl: './sub-categorias.component.html',
  styleUrl: './sub-categorias.component.css'
})
export class SubCategoriasComponent {

  subCategorias: any[] = [];

  constructor(private subCategoriaService: SubCategoriaService) { }

  ngOnInit(){
    this.subCategoriaService.getCursosAndSubCategoria().subscribe(data => {
      data.forEach((element: any) => {
        this.subCategorias.push(element);
      });
    });
  }

}
