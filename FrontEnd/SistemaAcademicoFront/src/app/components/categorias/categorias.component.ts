import { NgFor } from '@angular/common';
import { CategoriaService } from './../../services/categoria.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-categorias',
  standalone: true,
  imports: [NgFor],
  templateUrl: './categorias.component.html',
  styleUrl: './categorias.component.css'
})
export class CategoriasComponent {

  categorias: any[] = [];

  constructor(private categoriaService: CategoriaService) { }

  ngOnInit(){
    this.categoriaService.getCategorias().subscribe(data => {
      data.forEach((element: any) => {
        this.categorias.push(element);
      });
    });
  }
}
