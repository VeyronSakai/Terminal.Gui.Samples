# Terminal.Gui.Samples

My samples of [gui-cs/Terminal.Gui](https://github.com/gui-cs/Terminal.Gui).

## Requirements

.NET 6.0 or higher

## How to run

### 1. Clone this repository
```bash
$ git clone git@github.com:VeyronSakai/Terminal.Gui.Samples.git
```

### 2. Run samples

#### 2.1 Run with `dotnet run`

```bash
$ dotnet run -- --help
Usage: gsmpl [command]

gsmpl

Commands:
  test        test command
  official    official command samples

Options:
  -h, --help    Show help message
  --version     Show version
```

#### 2.2 Run as a local tool

```bash
$ dotnet tool restore
$ dotnet gsmpl --help
Usage: dotnet [command]

gsmpl

Commands:
  test        test command
  official    official command samples

Options:
  -h, --help    Show help message
  --version     Show version
```

#### 2.3 Run as a global tool

```bash
$ dotnet pack
$ dotnet tool install --global --add-source ./Terminal.Gui.Samples/nupkg gsmpl
$ gsmpl --help
Usage: gsmpl [command]

gsmpl

Commands:
  test        test command
  official    official command samples

Options:
  -h, --help    Show help message
  --version     Show version
```