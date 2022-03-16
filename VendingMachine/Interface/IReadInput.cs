using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Interface
{
    public interface IReadInput
    {
        public string ReadStringInput(bool state);
        public string GetSelectedValue(string text);
    }
}
