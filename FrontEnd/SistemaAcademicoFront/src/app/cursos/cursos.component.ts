import { NgFor } from '@angular/common';
import { CursoService } from './../services/curso.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-cursos',
  standalone: true,
  imports: [NgFor],
  templateUrl: './cursos.component.html',
  styleUrl: './cursos.component.css'
})
export class CursosComponent {

  cursos: any;

  constructor(private cursoService: CursoService) { }

  ngOnInit(){
    this.cursoService.getCursosAndCategoria().subscribe(data => {
      this.cursos = data;
      console.log(this.cursos);
    });
  }

}
