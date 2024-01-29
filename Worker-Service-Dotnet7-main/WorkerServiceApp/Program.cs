using WorkerServiceApp;
using Serilog;
using Microsoft.Extensions.Configuration;
using System.Runtime;

IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService()
    .ConfigureServices(services =>
    {
        services.AddSingleton<IUserService,UserService>();
        services.AddHostedService<Worker>();
    }).UseSerilog()
    .Build();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("microsoft", Serilog.Events.LogEventLevel.Warning)
    .Enrich.FromLogContext()
    //.WriteTo.File(configsetting["Logging:LogPath"])
    .WriteTo.File(configuration["Logging:LogPath"])
    //.WriteTo.Console()
    .CreateLogger();

host.Run();











//IHost host = Host.CreateDefaultBuilder(args)
//    .ConfigureServices(services =>
//    {
//        // services.AddHostedService<Worker>();
//        services.AddHostedService<UserService>();
//    }).UseSerilog()
//    .Build();

//host.Run();



















////var configsetting = new ConfigurationManager()
////    .AddJsonFile("appsettings.json").Build();

//IConfiguration configuration = new ConfigurationBuilder()
//            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//            .Build();

//CreateHostBuilder(args).Build().Run();

//IHostBuilder CreateHostBuilder(string[] args) =>
//    Host.CreateDefaultBuilder(args)
//        .ConfigureServices((hostContext, services) =>
//        {
//            services.AddHostedService<UserService>();

//        }).UseSerilog();



//IHost host = Host.CreateDefaultBuilder(args)
//    .ConfigureServices(services =>
//    {
//        // services.AddHostedService<Worker>();
//        services.AddHostedService<UserService>();
//    }).UseSerilog()
//    .Build();



//Log.Logger = new LoggerConfiguration()
//    .MinimumLevel.Debug()
//    .MinimumLevel.Override("microsoft", Serilog.Events.LogEventLevel.Warning)
//    .Enrich.FromLogContext()
//    //.WriteTo.File(configsetting["Logging:LogPath"])
//    .WriteTo.File(configuration["Logging:LogPath"])
//    .CreateLogger();