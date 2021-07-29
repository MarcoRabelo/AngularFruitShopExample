import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable()
export class FruitDataService {
  module: string = '/api/fruits';
  addToCart: string = '/addtocart';

  constructor(private http: HttpClient) { }

  get() {
    return this.http.get(this.module);
  }

  put(data) {
    return this.http.put(`${this.module}${this.addToCart}`, { "id": data.id, "qtt": 1 });
  }
}
