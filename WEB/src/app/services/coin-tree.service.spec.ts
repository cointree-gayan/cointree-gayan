import { TestBed } from '@angular/core/testing';

import { CoinTreeService } from './coin-tree.service';

describe('CoinTreeService', () => {
  let service: CoinTreeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CoinTreeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
