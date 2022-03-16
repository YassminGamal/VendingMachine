namespace VendingMachine.Interface
{
    public interface IPaymentService
    {
        public void insertCoins(decimal amount);
        public bool CheckBalance(decimal priceOfItem, out decimal change);
        public decimal GetBalance();
        public void ClearBalance();
    }
}