import { Routes } from '@angular/router';
import { CursosComponent } from './components/cursos/cursos.component';
import { MainComponent } from './components/main/main.component';

export const routes: Routes = [
  { path: 'cursos', component: CursosComponent },
  { path: '', component: MainComponent }
];

