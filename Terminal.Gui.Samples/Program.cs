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

cli.AddCommand("top", () =>
{
    Application.Init();
    var label = new Label("Hello, World")
    {
        X = Pos.Center(),
        Y = Pos.Center(),
        Height = 1,
    };

    Application.Top.Add(label);
    Application.Run();
    Application.Shutdown();
});

cli.AddCommand("menu", () =>
{
    Application.Init();
    var menu = new MenuBar(new[]
    {
        new MenuBarItem("_File", new MenuItem[]
        {
            new("_Quit", "", () => { Application.RequestStop(); })
        }),
    });

    var win = new Window("Hello")
    {
        X = 0,
        Y = 1,
        Width = Dim.Fill(),
        Height = Dim.Fill() - 1
    };

    // Add both menu and win in a single call
    Application.Top.Add(menu, win)g;
    Application.Run();
    Application.Shutdown();
});

cli.Run();