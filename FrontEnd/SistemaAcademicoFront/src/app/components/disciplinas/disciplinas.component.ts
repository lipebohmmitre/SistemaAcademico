import { NgFor } from '@angular/common';
import { Component } from '@angular/core';
import { DisciplinaService } from '../../services/disciplina.service';

@Component({
  selector: 'app-disciplinas',
  standalone: true,
  imports: [NgFor],
  templateUrl: './disciplinas.component.html',
  styleUrl: './disciplinas.component.css'
})
export class DisciplinasComponent {

  disciplinas: any[] = [];

  constructor(private disciplinaService: DisciplinaService) { }

  ngOnInit(){
    this.disciplinaService.getDisciplinas().subscribe(data => {
      console.log("disc ", data);
      data.forEach((element: any) => {
        this.disciplinas.push(element);
      });
    });
  }

}
