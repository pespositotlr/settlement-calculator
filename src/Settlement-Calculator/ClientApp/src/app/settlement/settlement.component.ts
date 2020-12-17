import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormGroup } from '@angular/forms';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'settlement',
  templateUrl: './settlement.component.html'
})
export class SettlementComponent {
  private http: HttpClient;
  private baseUrl: string;
  private router: Router;
  settlementFormGroup: FormGroup;

  _headers: HttpHeaders = new HttpHeaders({
    'Content-Type': 'application/json; charset=utf-8'
  });

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, router: Router) {
    this.http = http;
    this.baseUrl = baseUrl;
    this.router = router;
  }
  
  ngOnInit() {
    this.settlementFormGroup = new FormGroup({
      'settlementAmount': new FormControl("0.00")
    });
  }

  onSubmit() {
    //Get value from form
    const submittedAmount = this.settlementFormGroup.value["settlementAmount"];
    this.http.post<any>(this.baseUrl + 'payment', Number(submittedAmount), { headers: this._headers }).subscribe(result => {
      //Store result in local storage to load in new component
      localStorage.setItem('paymentPlan', JSON.stringify(result));
      this.router.navigate(['/settlement-result/']);
    }, error => console.error(error));
  }

}
