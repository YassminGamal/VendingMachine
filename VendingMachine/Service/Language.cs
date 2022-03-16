using Microsoft.Extensions.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using VendingMachine.Interface;
using VendingMachine.Resources;

namespace VendingMachine.Service
{
    public class Language : ILanguage
    {
        private readonly IConfiguration _configuration;
        public Language(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// set language
        /// </summary>
        /// <returns></returns>
        public void SetCurrentLanguage(string culture)
        {
            var availableLanguges = _configuration.GetSection($"Localization:AcceptedLanguages").Get<string[]>();
            if (!availableLanguges.Contains(culture))
            {
               System.Console.WriteLine($"Invalid Language, Please select from available languages <{string.Join(",", availableLanguges)}>");
            }
            else
            {
                Resource.Culture = CultureInfo.GetCultureInfo(culture);
            }
        }
    }
}
