using Cocona;
using Terminal.Gui.Samples;

var cli = CoconaApp.Create();

cli.AddCommand("test",
    () => Console.WriteLine("test")
).WithDescription("test command");

OfficialCommandProvider.Provide(cli);

cli.Run();