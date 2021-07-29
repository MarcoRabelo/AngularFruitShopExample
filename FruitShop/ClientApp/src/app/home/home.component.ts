import { Component, OnInit } from '@angular/core';
import { FruitDataService } from '../_data-services/fruit.data-service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent implements OnInit {

  fruits: any[] = [];

  constructor(private fruitDataService: FruitDataService) { }

  ngOnInit() {
    this.get();
  }

  get() {
    this.fruitDataService.get().subscribe(
      (data: any[]) => {
        this.fruits = data;
      },
      error => {
        console.log(error);
      })
  }

  addToCart(fruit) {
    this.fruitDataService.put(fruit).subscribe(data => {
      alert(`A fruta ${fruit.name} foi colocada no carrinho.`);
      //this.get();
    }, error => {
      console.log(error);
    });
  }
}
