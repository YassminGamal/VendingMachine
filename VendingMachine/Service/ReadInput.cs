using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VendingMachine.Interface;

namespace VendingMachine.Service
{
    public class ReadInput : IReadInput
    {
        /// <summary>
        /// Reads string from input device
        /// </summary>
        /// <returns>The text string.</returns>
        public string ReadStringInput(bool state)
        {
            do
            {
                if (!System.Console.KeyAvailable)
                {
                    Thread.Sleep(100);
                }
                else
                {
                    var key = System.Console.ReadLine();
                    if (!string.IsNullOrEmpty(key))
                    {
                        return key.ToLower();
                    }
                }

            } while (!state);

            return string.Empty;
        }
        public string GetSelectedValue(string text)
        {
            string value = string.Empty;
            if (text.Contains(" "))
            {
                string[] arrtext = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                value = arrtext[arrtext.Length - 1];
            }
            return value;
        }
    }
}
