// See https://aka.ms/new-console-template for more information
using Serilog.Events;
using Serilog;

Console.WriteLine("Hello, World!");

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Debug(LogEventLevel.Verbose)
    .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Information) // restricted... is Optional
    .CreateLogger();

Log.Error("some error");


Log.Information("This is for a user");
Log.Debug("Some other issue for debug");

Console.ReadLine();