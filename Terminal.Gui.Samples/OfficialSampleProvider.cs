using Cocona;

namespace Terminal.Gui.Samples;

internal static class OfficialSampleProvider
{
    internal static void Provide(CoconaApp app)
    {
        app.AddSubCommand("official", x =>
        {
            x.AddCommand("msg-box", () =>
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
            }).WithDescription("show message box");

            x.AddCommand("top", () =>
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
            }).WithDescription("show top window");

            x.AddCommand("menu", () =>
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
                Application.Top.Add(menu, win);
                Application.Run();
                Application.Shutdown();
            }).WithDescription("show menu bar");

            x.AddCommand("layout", () =>
            {
                Application.Init();
                // Dynamically computed
                var label = new Label("Hello")
                {
                    X = 1,
                    Y = Pos.Center(),
                    Width = 1,
                    Height = 1
                };

                // // Absolute position using the provided rectangle
                var label2 = new Label(new Rect(1, 2, 20, 1), "World");

                Application.Top.Add(label, label2);
                Application.Run();
                Application.Shutdown();
            }).WithDescription("show layout");

            x.AddCommand("cat", ([Argument] string filePath) =>
            {
                Application.Init();
                var top = new Toplevel()
                {
                    X = 0,
                    Y = 0,
                    Width = Dim.Fill(),
                    Height = Dim.Fill()
                };
                var menu = new MenuBar(new MenuBarItem[]
                {
                    new("_File", new[]
                    {
                        new MenuItem("_Close", "", () => { Application.RequestStop(); })
                    }),
                });

                // nest a window for the editor
                var win = new Window(filePath)
                {
                    X = 0,
                    Y = 1,
                    Width = Dim.Fill(),
                    Height = Dim.Fill() - 1
                };

                var editor = new TextView()
                {
                    X = 0,
                    Y = 0,
                    Width = Dim.Fill(),
                    Height = Dim.Fill()
                };
                editor.Text = File.ReadAllText(filePath);
                win.Add(editor);

                // Add both menu and win in a single call
                top.Add(win, menu);
                Application.Run(top);
                Application.Shutdown();
            }).WithDescription("show the content of the specified file");
        }).WithDescription("official command samples");
    }
}