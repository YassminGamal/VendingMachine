using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;
using VendingMachine.Interface;
using VendingMachine.Service;
using VendingMachine.Resources;
using VendingMachine.Model;

namespace VendingMachine
{
    class Program
    {
        public static IConfiguration configuration;
        public static void Main(string[] args)
        {
            try
            {
                StartApp(args).Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); 
            }
        }
        private static async Task StartApp(string[] args)
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            SetDefaultConfigurations(serviceProvider, args);
            //start application process 
            var vendingService = serviceProvider.GetService<IVendingMachineService>();
            await vendingService.StartService();
        }
        private static void SetDefaultConfigurations(IServiceProvider serviceProvider,string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            //Set Culture depend on configuration
            serviceProvider.GetService<ILanguage>().SetCurrentLanguage(configuration.GetValue<string>("Localization:CultureInfoValue"));
            Console.WriteLine(Resource.WelcomeText);
            ServiceConfigurations.SetConfigurations(configuration);
            var readInput = serviceProvider.GetService<IReadInput>();
            // check --slots 5 , --currency and --help
            foreach (string arg in args)
            {
                if (arg.StartsWith("--"))
                {
                    if (arg.ToLower().Contains("help"))
                    {
                        Console.WriteLine(Resource.HelpText);
                    }
                    else if (arg.ToLower().Contains("currency"))
                    {
                        var currencyinput = readInput.GetSelectedValue(arg.Substring(2));
                        ServiceConfigurations.Currency = string.IsNullOrEmpty(currencyinput) ? configuration.GetValue<string>("Currency") : currencyinput;
                    }
                    else if (arg.ToLower().Contains("slots"))
                    {
                        var slotinput = readInput.GetSelectedValue(arg.Substring(2));
                        ServiceConfigurations.Slot = string.IsNullOrEmpty(slotinput) ? configuration.GetValue<int>("Slots") : int.Parse(slotinput);
                    }
                }
            }

        }
        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IVendingMachineService, VendingMachineService>();
            serviceCollection.AddSingleton<IPaymentService, PaymentService>();
            serviceCollection.AddSingleton<IReadInput, ReadInput>();
            serviceCollection.AddSingleton<ILanguage, Language>();
            serviceCollection.AddSingleton<IProductsRepository, ProductsRepository>();
            // Build configuration
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false, true)
                .Build();
            serviceCollection.AddSingleton<IConfiguration>(configuration);


        }
    }
}
