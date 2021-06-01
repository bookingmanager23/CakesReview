import { Component, OnInit } from '@angular/core';
import { Cake } from '../Entities/Cake';
import { CakeService } from '../services/cake.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
  
  currentCake?: Cake | null;

  constructor(private cakeService: CakeService, private route: ActivatedRoute) { }

  ngOnInit(): void {

    this.getCake(Number(this.route.snapshot.paramMap.get('id')));
  }

  getCake(id: number) {
    this.cakeService.getCake(id)
      .subscribe(
        data => {
          this.currentCake = data;
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }
}
