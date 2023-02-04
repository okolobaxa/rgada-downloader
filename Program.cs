using System.Reflection;
using ElarDownloader;
using RgadaDownloader;
using Spectre.Console;

var version = Assembly.GetEntryAssembly()?.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
    .InformationalVersion;
AnsiConsole.Write(new FigletText($"RGADA Downloader v.{version}").Centered().Color(Color.Green));
ConsoleHelper.GetAnyKey();

var current = Directory.GetCurrentDirectory();

var files = Directory.GetFiles(current, "*.txt");
if (!files.Any())
{
    AnsiConsole.MarkupLine($"[red]Не найдено ссылок для скачивания. Прочтите инструкцию ещё раз.[/]");
    ConsoleHelper.GetAnyKey();
    
    return;
}

var firstFile = files.First();
var allLines = File.ReadAllLines(firstFile);

foreach (var line in allLines)
{
    if (!Uri.TryCreate(line, UriKind.Absolute, out var uri))
    {
        AnsiConsole.MarkupLine($"[red]Корявая ссылка для скачивания. Проверьте её.[/]");
        break;
    }

    var downloadInfo = await PageParser.ParserPage(uri);
    if (downloadInfo.Links.Any())
    {
        await DownloadManager.Download(downloadInfo);
    }
    
    ConsoleHelper.GetAnyKey();
}

internal static class ConsoleHelper
{
    public static void GetAnyKey()
    {
        AnsiConsole.MarkupLine("Нажмите любую клавишу чтобы продолжить...\n");
        Console.Read();
    }
}