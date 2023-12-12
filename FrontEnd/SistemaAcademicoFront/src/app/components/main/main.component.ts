import { Component } from '@angular/core';
import {MatGridListModule} from '@angular/material/grid-list';
import { CalendarioComponent } from '../auxiliar/calendario/calendario.component';
import { InfoComponent } from '../auxiliar/info/info.component';
import { NoticiasComponent } from '../auxiliar/noticias/noticias.component';
import { UserInfoComponent } from '../auxiliar/user-info/user-info.component';


@Component({
  selector: 'app-main',
  standalone: true,
  imports: [MatGridListModule, CalendarioComponent, InfoComponent, NoticiasComponent, UserInfoComponent],
  templateUrl: './main.component.html',
  styleUrl: './main.component.css'
})
export class MainComponent {

}
