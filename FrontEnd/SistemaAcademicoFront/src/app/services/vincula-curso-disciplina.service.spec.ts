import { TestBed } from '@angular/core/testing';

import { VinculaCursoDisciplinaService } from './vincula-curso-disciplina.service';

describe('VinculaCursoDisciplinaService', () => {
  let service: VinculaCursoDisciplinaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(VinculaCursoDisciplinaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
