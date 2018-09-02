using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace XyAuto.It.Web.Startup
{
    //public class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        var host = new WebHostBuilder()
    //            //.CreateDefaultBuilder(args)
    //            .UseKestrel(opt => opt.AddServerHeader = false)
    //            .UseContentRoot(Directory.GetCurrentDirectory())
    //            .UseIISIntegration()
    //            .UseStartup<Startup>()
    //            .Build();

    //        host.Run();
    //    }
    //}

    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}

