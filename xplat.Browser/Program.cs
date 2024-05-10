using System;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Browser;
using Avalonia.ReactiveUI;
using xplat;

[assembly: SupportedOSPlatform("browser")]

internal sealed partial class Program
{
    private static Task Main(string[] args)
    {
        Console.WriteLine("Main started");
        var t = BuildAvaloniaApp()
            .WithInterFont()
            .UseReactiveUI()
            .StartBrowserAppAsync("out", new BrowserPlatformOptions
            {
                RenderingMode = new[] { BrowserRenderingMode.Software2D }
            });
        Console.WriteLine("task started");
        t.ContinueWith(t =>
        {
            Console.WriteLine("task completed");

            if (t.Exception != null)
            {
                Console.WriteLine(t.Exception);
            }
        });
        Console.WriteLine("main returning task");

        return Task.CompletedTask;
    }

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>();
}