import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddSubCategoriaComponent } from './add-sub-categoria.component';

describe('AddSubCategoriaComponent', () => {
  let component: AddSubCategoriaComponent;
  let fixture: ComponentFixture<AddSubCategoriaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddSubCategoriaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AddSubCategoriaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
