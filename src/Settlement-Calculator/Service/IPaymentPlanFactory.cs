namespace SettlementCalculator
{
    public interface IPaymentPlanFactory
    {
        public PaymentPlan CreatePaymentPlan(decimal settlementAmount);            
    }
}