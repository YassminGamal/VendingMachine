using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Interface
{
    public interface IVendingMachineService
    {
        public Task StartService();
        public void EndService();
    }
}
