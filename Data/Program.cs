using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Pomelo.EntityFrameworkCore.MySql;

namespace Data {
    class Program {
        static void Main (string[] args) {
            IConfiguration config = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", optional:true,reloadOnChange: true)
           .Build();


            string connectionString = config.GetValue<string>("DBConnection:ReactLab");
            Console.WriteLine(connectionString);
            // var serverVersion = new MySqlServerVersion (new Version (8, 0, 27));

            var servicesProvider =
                //新增 service connection
                new ServiceCollection ()
                //設定每次 request 都會建立 Runner(YowkoRunner)
                .AddDbContext<ReactLabContext> (
                    dbContextOptions => dbContextOptions
                    .UseMySql (connectionString))
                //建立 service provider
                .BuildServiceProvider ();
            //從 service provider 中取得上面設定建立的 Runner(YowkoRunner) 服務
            var runner = servicesProvider.GetRequiredService<ReactLabContext> ();
            Console.WriteLine (JsonConvert.SerializeObject (runner.Store.ToList (), Formatting.Indented));
        }
    }
}