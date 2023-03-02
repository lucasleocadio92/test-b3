import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { take } from 'rxjs/operators';
import { Investment } from 'src/app/models/investment.model';
import { InvestmentService } from 'src/app/services/investment.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  form: FormGroup = this.formBuilder.group({
    value: [5250.00, [Validators.required]],
    month: [24, [Validators.required]]
  });

  investment: Investment;

  constructor(
    private formBuilder: FormBuilder,
    private investmentService: InvestmentService
  ) { }

  ngOnInit(): void {
    this.calculateCDB();
  }

  removeMoney(){
    this.form.patchValue({value: this.form.value.value - 250});
    this.calculateCDB();
  }

  addMoney(){
    this.form.patchValue({value: this.form.value.value + 250});
    this.calculateCDB();
  }

  calculateCDB(){
    this.investmentService.simulateCDB({
      valor: this.form.value.value,
      prazoMeses: this.form.value.month
    }).pipe(take(1)).subscribe((res) => {
      this.investment = res;
    });
  }
 
}
