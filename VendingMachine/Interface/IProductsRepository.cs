using System.Collections.Generic;
using System.Threading.Tasks;
using VendingMachine.Model;

namespace VendingMachine.Interface
{
    public interface IProductsRepository
    {
        Dictionary<int, Product> Products { get; }

        public void FillProdcts();
        public void SelectProduct(int productNo);
    }
}