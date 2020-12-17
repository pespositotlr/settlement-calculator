using Microsoft.Extensions.Configuration;
using Shouldly;
using System;
using System.Collections.Generic;
using Xunit;

namespace SettlementCalculator.Tests
{
    public class PaymentPlanFactoryTests
    {
        private IConfiguration _config;

        public PaymentPlanFactoryTests()
        {
            var myConfiguration = new Dictionary<string, string>
                {
                    {"NumberOfInstallments", "4"},
                    {"InstallmentIntervalInDays", "14"},
                    {"AllowedHosts", "*"}
                };

            _config = new ConfigurationBuilder()
                .AddInMemoryCollection(myConfiguration)
                .Build();
        }

        [Fact]
        public void WhenCreatePaymentPlanWithValidOrderAmount_ShouldReturnValidPaymentPlan()
        {
            // Arrange
            var paymentPlanFactory = new PaymentPlanFactory(_config);
            
            // Act
            var paymentPlan = paymentPlanFactory.CreatePaymentPlan(123.45M);

            // Assert
            paymentPlan.ShouldNotBeNull();
        }

        [Fact]
        public void WhenCreatePaymentPlanWithValidOrderAmount_ShouldReturnCorretNumberOfInstallments()
        {
            // Arrange
            var paymentPlanFactory = new PaymentPlanFactory(_config);

            // Act
            var paymentPlan = paymentPlanFactory.CreatePaymentPlan(123.45M);

            // Assert
            paymentPlan.Installments.Length.ShouldBe(4);
        }

        [Fact]
        public void WhenCreatePaymentPlanWithValidOrderAmount_ShouldReturnCorretInstallmentAmounts()
        {
            // Arrange
            var paymentPlanFactory = new PaymentPlanFactory(_config);

            // Act
            var paymentPlan = paymentPlanFactory.CreatePaymentPlan(123.45M);

            // Assert
            paymentPlan.Installments[0].Amount.ShouldBeEquivalentTo(30.8625M);
            paymentPlan.Installments[1].Amount.ShouldBeEquivalentTo(30.8625M);
            paymentPlan.Installments[2].Amount.ShouldBeEquivalentTo(30.8625M);
            paymentPlan.Installments[3].Amount.ShouldBeEquivalentTo(30.8625M);
        }

        [Fact]
        public void WhenCreatePaymentPlanWithValidOrderAmount_ShouldReturnCorretInstallmentDates()
        {
            // Arrange
            var paymentPlanFactory = new PaymentPlanFactory(_config);

            // Act
            var paymentPlan = paymentPlanFactory.CreatePaymentPlan(123.45M);

            // Assert
            paymentPlan.Installments[0].DueDate.Day.ShouldBeEquivalentTo(DateTime.Now.Day);
            paymentPlan.Installments[1].DueDate.Day.ShouldBeEquivalentTo(DateTime.Now.Add(new TimeSpan(14, 0, 0, 0)).Day);
            paymentPlan.Installments[2].DueDate.Day.ShouldBeEquivalentTo(DateTime.Now.Add(new TimeSpan(28, 0, 0, 0)).Day);
            paymentPlan.Installments[3].DueDate.Day.ShouldBeEquivalentTo(DateTime.Now.Add(new TimeSpan(42, 0, 0, 0)).Day);
        }
    }
}
