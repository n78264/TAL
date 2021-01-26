import { __decorate } from "tslib";
import { Component } from '@angular/core';
import { Validators } from '@angular/forms';
let MonthlyPremiumComponent = class MonthlyPremiumComponent {
    constructor(formBuilder, httpService) {
        this.formBuilder = formBuilder;
        this.httpService = httpService;
        this.pageTitle = 'Premium Calculator';
        this.errorMessage = '';
        this.submitted = false;
        this.occupationRatingFactorList = [];
    }
    ngOnInit() {
        this.premiumCalculatorForm = this.formBuilder.group({
            fullName: [''],
            dob: ['', Validators.required],
            age: [''],
            occupation: ['', Validators.required],
            sumInsured: ['', [Validators.required, Validators.min(1)]]
        });
        this.getRatingFactorByOccupation();
    }
    get f() { return this.premiumCalculatorForm.controls; }
    onSubmit() {
        this.submitted = true;
        if (this.premiumCalculatorForm.valid) {
            this.calculatePremium();
        }
    }
    onDateOfBirthChange(dateofBirth) {
        if (dateofBirth) {
            let dateRange = new Date(dateofBirth);
            let minDate = new Date('1900-01-01');
            let maxDate = new Date('2021-02-01');
            if (dateRange > minDate && dateRange < maxDate) {
                let age = this.getAgeFromDateOfBirth(dateofBirth);
                this.premiumCalculatorForm.patchValue({ age: age });
            }
            else {
                this.premiumCalculatorForm.patchValue({ dob: null });
                this.premiumCalculatorForm.patchValue({ age: null });
            }
        }
    }
    calculatePremium() {
        if (this.premiumCalculatorForm.valid) {
            let dateOfBirth = this.premiumCalculatorForm.get('dob').value;
            let occupation = this.premiumCalculatorForm.get('occupation').value;
            let deathSumInsured = this.premiumCalculatorForm.get('sumInsured').value;
            if (dateOfBirth && occupation && deathSumInsured) {
                let InsurancePremiumParams = {};
                let dateofBirth = this.premiumCalculatorForm.get('dob').value;
                InsurancePremiumParams.age = +this.getAgeFromDateOfBirth(dateofBirth);
                InsurancePremiumParams.occupationRatingFactor = +this.premiumCalculatorForm.get('occupation').value;
                InsurancePremiumParams.deathSumInsured = +this.premiumCalculatorForm.get('sumInsured').value;
                this.premiumAmount = this.getMonthlyPremium(InsurancePremiumParams);
            }
            else
                this.premiumAmount = null;
        }
    }
    getAgeFromDateOfBirth(dob) {
        var now = new Date();
        var birthDate = new Date(dob);
        var timeDiff = Math.abs(now.getTime() - birthDate.getTime());
        var age = parseFloat((timeDiff / (1000 * 3600 * 24 * 365)).toFixed(2));
        return age;
    }
    getMonthlyPremium(insurancePremiumParams) {
        const monthlyPremium = parseFloat(((insurancePremiumParams.deathSumInsured *
            insurancePremiumParams.occupationRatingFactor * insurancePremiumParams.age) / (1000 * 12)).toFixed(2));
        return monthlyPremium;
    }
    getRatingFactorByOccupation() {
        this.httpService.get()
            .subscribe((data) => {
            this.occupationRatingFactorList = data;
        });
    }
};
MonthlyPremiumComponent = __decorate([
    Component({
        selector: 'app-monthly-premium',
        templateUrl: './monthly-premium.component.html',
        styleUrls: ['./monthly-premium.component.css']
    })
], MonthlyPremiumComponent);
export { MonthlyPremiumComponent };
//# sourceMappingURL=monthly-premium.component.js.map