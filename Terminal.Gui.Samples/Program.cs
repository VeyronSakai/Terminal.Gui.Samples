using Cocona;
using Terminal.Gui.Samples.Presentation;

var cli = CoconaApp.Create();

cli.AddCommand("test",
    () => Console.WriteLine("test")
).WithDescription("test command");

cli.AddOfficialCommand();
cli.Run();