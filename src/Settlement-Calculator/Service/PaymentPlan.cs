using System;

namespace SettlementCalculator
{
    /// <summary>
    /// Data structure which defines all the properties for a settlement installment plan.
    /// </summary>
    public class PaymentPlan
    {
        public Guid Id { get; set; }

		public decimal SettlementAmount { get; set; }

        public Installment[] Installments { get; set; }
    }
}
