import { Component, OnInit } from '@angular/core';
import { CakeService } from '../services/cake.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Cake } from '../Entities/Cake';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {
  cake: Cake = new Cake;
  pageErrors: string = "";
  
  constructor(
    public fb: FormBuilder,
    private router: Router,
    public cakeService: CakeService) { }

  ngOnInit(): void {
  }

  submitForm() {
    
    this.cakeService.create(this.cake).subscribe(
      data => {
        this.router.navigateByUrl('home')
      },
    error => {
      this.pageErrors = error;
    })
  }
}

