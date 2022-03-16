using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Model
{
    public static class ServiceConfigurations
    {
        public static string Currency { get; set; }
        public static int Slot { get; set; }
        public static string ToCurrencySymbol()
        {
            RegionInfo region = CultureInfo.GetCultures(CultureTypes.SpecificCultures).Select(x => new RegionInfo(x.LCID)).FirstOrDefault(p => p.ISOCurrencySymbol == Currency.ToUpper());
            return region?.CurrencySymbol ?? Currency;
        }
        public static void SetConfigurations(IConfiguration configuration)
        {
           Currency = configuration.GetValue<string>("Currency");
           Slot = configuration.GetValue<int>("Slots");
        }
    }
}
