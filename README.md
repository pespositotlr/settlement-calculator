# Settlement Calculator

## Overview

This project was part of a coding challenge to build a full stack application to function as a settlement calculator.

The front-end is written in Angular using Typescript and the back-end is written in C# using .NET Core. 

The goal is to allow a user to input an amount of money and then show what payments they would make splitting it up into a pre-set number of weeks (set on the back-end). Then output the result in a form showing the dates and the price.

It's meant to have thorough unit tests on the back end and use clean-coding and SOLID design principles to allow every part of it to be easy to understand and extend as requirements change.

The front-end had requirements to have navigation, an input form with validation, and a separate URI for the user to be sent to when they submit their payment amount.

### For example:

- The number of installments is set to 4.
- The payment interval is set to 2 weeks.
- The user is entering this information on December 1st 2020.
- The user inputs 1000.00 as their total.

This should be the result:

  - `Dec 1, 2020	$250.00`
  - `Dec 15, 2020	$250.00`
  - `Dec 29, 2020	$250.00`
  - `Jan 12, 2021	$250.00`





