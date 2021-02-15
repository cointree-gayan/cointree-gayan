import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';
import {CoinTreeService} from '../app/services/coin-tree.service';
import { CoinDetails } from '../app/models/coin-details';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  
  coins: string[] = [];
  coinDetails : CoinDetails; 

  title = 'CoinTree';

  constructor(private cointreeService: CoinTreeService) { }

  ngOnInit(): void {
    this.getCoins();
}

getCoins(){    
  this.cointreeService.getCoins()
          .pipe(first())
          .subscribe(coins => 
            {              
              this.coins = coins;              
            } 
            );
}

getCoinDetails(preferredCoin : string)
{
  this.cointreeService.getCoinDetails(preferredCoin)
          .pipe(first())
          .subscribe(coinDetails => 
            { 
              //console.log(coinDetails);             
              this.coinDetails = coinDetails;              
            } 
            );
}
}
