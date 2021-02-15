import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { CoinDetails } from '../models/coin-details';

@Injectable({
  providedIn: 'root'
})
export class CoinTreeService {

  constructor(private http: HttpClient) { }

  getCoins() {
    return this.http.get<string[]>(`${environment.cointreeApiUrl}/api/CoinTree`);
  }

  getCoinDetails(coin : string) {
    return this.http.get<CoinDetails>(`${environment.cointreeApiUrl}/api/CoinTree/GetCoinDetails/${coin}`);
  }
  
}
