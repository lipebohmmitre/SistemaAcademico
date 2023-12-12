import { VincularDisciplinaCursoComponent } from './components/vincular-disciplina-curso/vincular-disciplina-curso.component';
import { Routes } from '@angular/router';
import { CursosComponent } from './components/cursos/cursos.component';
import { MainComponent } from './components/main/main.component';
import { AddCursoComponent } from './components/add-curso/add-curso.component';
import { AddCategoriaComponent } from './components/add-categoria/add-categoria.component';
import { CategoriasComponent } from './components/categorias/categorias.component';
import { AddSubCategoriaComponent } from './components/add-sub-categoria/add-sub-categoria.component';
import { SubCategoriasComponent } from './components/sub-categorias/sub-categorias.component';
import { DisciplinaComponent } from './components/disciplina/disciplina.component';
import { DisciplinasComponent } from './components/disciplinas/disciplinas.component';
import { AddDisciplinaComponent } from './components/add-disciplina/add-disciplina.component';

export const routes: Routes = [
  { path: 'cursos', component: CursosComponent },
  { path: '', component: MainComponent },
  { path: 'addCursos', component: AddCursoComponent },
  { path: 'addCategoria', component: AddCategoriaComponent },
  { path: 'categorias', component: CategoriasComponent },
  { path: 'addSubCategoria', component: AddSubCategoriaComponent },
  { path: 'subCategorias', component: SubCategoriasComponent },
  { path: 'disciplinas', component: DisciplinasComponent },
  { path: 'addDisciplina', component: AddDisciplinaComponent },
  { path: 'vincularDisciplinaCurso', component: VincularDisciplinaCursoComponent }
];

