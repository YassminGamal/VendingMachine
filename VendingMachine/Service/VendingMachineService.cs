using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Interface;
using VendingMachine.Resources;

namespace VendingMachine.Service
{
    public class VendingMachineService : IVendingMachineService
    {
        private bool IsStateOn { get; set; }
        private readonly IReadInput _readInput;
        private readonly ILanguage _language;
        private readonly IProductsRepository _product;
        private readonly IPaymentService _payment;
        public VendingMachineService(IReadInput readInput, ILanguage language, IProductsRepository products, IPaymentService payment)
        {
            _readInput = readInput;
            _language = language;
            _product = products;
            _payment = payment;
        }
        public async Task StartService()
        {
            try
            {
                IsStateOn = true;
                ReadInstructions();
            }
            catch (Exception ex)
            {
                EndService();
            }

        }
        private void ReadInstructions()
        {
            do
            {
                string code = _readInput.ReadStringInput(IsStateOn);

                if (code.Contains("language"))
                {
                    string language = _readInput.GetSelectedValue(code);
                    _language.SetCurrentLanguage(language);
                }
                else if (code.Contains("enter"))
                {
                    string value = _readInput.GetSelectedValue(code);
                    decimal coins;
                    if (decimal.TryParse(value, out coins))
                        _payment.insertCoins(coins);
                    else
                        Console.WriteLine(Resource.InsertCoin);

                }
                else if (code.Contains("select"))
                {
                    if (_payment.GetBalance() <= 0)
                        Console.WriteLine(Resource.InsertCoin);
                    else
                    {
                        string value = _readInput.GetSelectedValue(code);
                        int productNo;
                        if (int.TryParse(value, out productNo))
                        {
                            _product.SelectProduct(productNo);
                        }
                        else
                            Console.WriteLine(Resource.InsertCoin);
                    }

                }
                else if (code.Contains("show"))
                {
                    _product.FillProdcts();
                }
                else if (code.Contains("cancel"))
                {
                    EndService();
                }
            }
            while (IsStateOn);
        }
        public void EndService()
        {
            IsStateOn = false;
            Console.WriteLine(Resource.ThankYou);
        }
    }
}
