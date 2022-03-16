using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VendingMachine.Interface;
using VendingMachine.Model;
using VendingMachine.Resources;

namespace VendingMachine.Service
{
    public class ProductsRepository : IProductsRepository
    {
        public Dictionary<int, Product> Products { get; } = new Dictionary<int, Product>();

        private readonly IConfiguration _configuration;
        private readonly IPaymentService _payment;
        public ProductsRepository(IConfiguration configuration, IPaymentService payment)
        {
            _configuration = configuration;
            _payment = payment;
        }
        public void FillProdcts()
        {
            var ProductConfig = new List<Product>();
            _configuration.GetSection($"ProductsConfig").Bind(ProductConfig);
            int ProductNo = 1;
            foreach (var p in ProductConfig)
            {
                if (!Products.ContainsKey(ProductNo))
                {
                    Products[ProductNo] = p;
                }
                string msg = ProductNo + ". " + Products[ProductNo].Name + " " + Products[ProductNo].Price + ServiceConfigurations.ToCurrencySymbol() + " - " + (Products[ProductNo].Quantity > 0 ? (Products[ProductNo].Quantity + " " + Resource.ItemLeft) : Resource.SoldOut);
                Console.WriteLine(msg);
                ProductNo++;
            }
        }

        public void SelectProduct(int productNo)
        {
            var product = Products.ContainsKey(productNo) ? Products[productNo] : null;
            if (product != null)
            {
                if (product.Quantity > 0)
                {
                    if (_payment.CheckBalance(product.Price, out decimal change))
                    {
                        // decrease stock 
                        Products[productNo].UpdateQuantity();
                        Console.WriteLine(Resource.ProductPurchased);
                        if (change > 0)
                            Console.WriteLine(string.Format(Resource.ChangeText, (product.Price + ServiceConfigurations.ToCurrencySymbol())));
                        _payment.ClearBalance();
                        Console.WriteLine(Resource.ThankYou);
                    }
                    else
                        Console.WriteLine(Resource.PriceText + " " + product.Price + ServiceConfigurations.ToCurrencySymbol());
                }
                else
                    Console.WriteLine(Resource.SoldOut);
            }
            else
                Console.WriteLine(Resource.InvalidProduct);
        }
    }
}
