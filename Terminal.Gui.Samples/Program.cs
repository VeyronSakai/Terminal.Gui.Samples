using Cocona;
using Terminal.Gui;

var cli = CoconaApp.Create();

cli.AddCommand("test",
    () => Console.WriteLine("test")
).WithDescription("test command");

cli.AddCommand("msg-box", () =>
{
    Application.Init();
    var n = MessageBox.Query(50, 7,
        "Question", "Do you like console apps?", "Yes", "No");
    Application.Shutdown();

    switch (n)
    {
        case 0:
            Console.WriteLine("It's good. Same with me.");
            break;
        case 1:
            Console.WriteLine("That's too bad.");
            break;
        default:
            throw new CommandExitedException(1);
    }
});

cli.Run();