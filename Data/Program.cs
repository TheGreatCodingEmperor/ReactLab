using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Pomelo.EntityFrameworkCore.MySql;
using System.Linq;
using Newtonsoft.Json;

namespace Data {
    class Program {
        static void Main (string[] args) {
            var connectionString = "server=127.0.0.1;port=3307;user id=root;password=70400845;database=ReactLab;charset=utf8;";
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
                Console.WriteLine(JsonConvert.SerializeObject(runner.Store.ToList(),Formatting.Indented));
        }
    }
}