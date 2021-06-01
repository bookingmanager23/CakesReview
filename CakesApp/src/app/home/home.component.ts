import { Component, OnInit } from '@angular/core';
import { Cake } from '../Entities/Cake';
import { CakeService } from '../services/cake.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  currentCake?: Cake | null;
  currentIndex = -1;
  cakes: Cake[] = [];

	constructor(public cakeService: CakeService) { }
	ngOnInit() {
    
    this.getAllCakes();
	}

  getAllCakes() {
    this.cakeService.getCakes().subscribe((data: Cake[])=>{
      this.cakes = data;
    }) 
  }

  setActiveCake(cake: Cake, index: number) {
    this.currentCake = cake;
    this.currentIndex = index;
  }

  deleteCake(id: number) {
    this.cakeService.delete(id).subscribe(()=> {

      this.getAllCakes();
    }) 
  }
}

