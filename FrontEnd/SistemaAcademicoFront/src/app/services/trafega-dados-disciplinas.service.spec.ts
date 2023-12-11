import { TestBed } from '@angular/core/testing';

import { TrafegaDadosDisciplinasService } from './trafega-dados-disciplinas.service';

describe('TrafegaDadosDisciplinasService', () => {
  let service: TrafegaDadosDisciplinasService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TrafegaDadosDisciplinasService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
