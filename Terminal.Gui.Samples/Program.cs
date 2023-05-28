// See https://aka.ms/new-console-template for more information

using Cocona;

var cli = CoconaApp.Create();

cli.AddCommand("test",
    () => Console.WriteLine("test")
).WithDescription("test command");

cli.Run();