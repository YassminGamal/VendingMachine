using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using VendingMachine.Interface;
using VendingMachine.Model;
using VendingMachine.Resources;

namespace VendingMachine.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IConfiguration _configuration;
        public decimal balance = 0;
        public PaymentService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void insertCoins(decimal amount)
        {
            List<decimal> invalidCoins = _configuration.GetSection("InvalidCoins").Get<List<decimal>>();
            decimal MaxAmount = _configuration.GetValue<decimal>("MaxAmount");
            if (!invalidCoins.Contains(amount) && amount > 0 && amount <= MaxAmount)
            {
                balance += amount;
                Console.WriteLine(string.Format(Resource.InsertSuccess, (amount + ServiceConfigurations.ToCurrencySymbol())));
            }
            else
            {
                Console.WriteLine(Resource.InvalidCoins);
            }

        }
        public bool CheckBalance(decimal priceOfItem, out decimal change)
        {
            change = 0;
            if (balance >= priceOfItem)
            {
                change = balance - priceOfItem;
                return true;
            }
            else
                return false;

        }
        public decimal GetBalance()
        {
            return balance;
        }
        public void ClearBalance()
        {
            balance = 0;
        }
    }
}
