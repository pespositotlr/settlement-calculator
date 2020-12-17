using Microsoft.Extensions.Configuration;
using System;

namespace SettlementCalculator
{
    /// <summary>
    /// This class is responsible for building the PaymentPlan.
    /// </summary>
    public class PaymentPlanFactory : IPaymentPlanFactory
    {
        private IConfiguration _config;

        public PaymentPlanFactory(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// Builds the PaymentPlan instance.
        /// </summary>
        /// <param name="settlementAmount">The total amount for the purchase that the customer is making.</param>
        /// <returns>The PaymentPlan created with all properties set.</returns>
        public PaymentPlan CreatePaymentPlan(decimal settlementAmount)
        {
            PaymentPlan paymentPlan = new PaymentPlan();
            paymentPlan.SettlementAmount = settlementAmount;
            int numberOfInstallments = Convert.ToInt32(_config["NumberOfInstallments"]);
            int installmentIntervalInDays = Convert.ToInt32(_config["InstallmentIntervalInDays"]);
            decimal installmentAmount = settlementAmount / numberOfInstallments;

            paymentPlan.Installments = new Installment[numberOfInstallments];

            for (int i = 0; i < numberOfInstallments; i++)
            {
                TimeSpan timeFromPresent = new TimeSpan(i * installmentIntervalInDays, 0, 0, 0);
                DateTime currentDueDate = DateTime.Now.Add(timeFromPresent);

                Installment newInstallment = new Installment();
                newInstallment.DueDate = currentDueDate;
                newInstallment.Amount = installmentAmount;

                paymentPlan.Installments[i] = newInstallment;
            }

            return paymentPlan;
        }
    }
}
