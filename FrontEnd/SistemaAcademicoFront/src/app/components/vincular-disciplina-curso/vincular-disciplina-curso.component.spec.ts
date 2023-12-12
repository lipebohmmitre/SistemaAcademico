import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VincularDisciplinaCursoComponent } from './vincular-disciplina-curso.component';

describe('VincularDisciplinaCursoComponent', () => {
  let component: VincularDisciplinaCursoComponent;
  let fixture: ComponentFixture<VincularDisciplinaCursoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [VincularDisciplinaCursoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(VincularDisciplinaCursoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
