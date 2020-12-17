import { Component, Inject } from '@angular/core';

@Component({
  selector: 'settlement-result',
  templateUrl: './settlement-result.component.html'
})
export class SettlementResultComponent {
  public paymentPlan: PaymentPlan;

  constructor() {
    const paymentPlanJSON = localStorage.getItem('paymentPlan');
    if (paymentPlanJSON.length > 0)
      this.paymentPlan = JSON.parse(paymentPlanJSON);
  }  
}

//Interfaces for back-end objects
export interface PaymentPlan {
  id: number;
  settlementAmount: number;
  installments: Installment[];
}

export interface Installment {
  id: number;
  dueDate: Date;
  amount: number;
}

