using Microsoft.Toolkit.Uwp.Notifications;
using System.Diagnostics;

public class Program
{
    public const string PROC_NAME = "Spotify";
    public static string CurrentTitle { get; set; } = "";

    public static void Main()
    {
        var app = new Program();

        Timer timer = new(Run, null, 0, 2000);

        Console.ReadLine();

        timer.Dispose();
    }

    private static string? GetTitle()
    {
        Process[] process = Process.GetProcessesByName(PROC_NAME);

        if (process == null) 
            return null;

        return process[0].MainWindowTitle;
    }

    private static void Run(Object? o)
    {
        string? newTitle = GetTitle();
        
        if (!String.IsNullOrEmpty(newTitle))
        {
            if (CurrentTitle == newTitle)
                return;
            else
            {
                CurrentTitle = newTitle;
                
                new ToastContentBuilder()
                    .AddText("Spotify")
                    .AddText(CurrentTitle)
                    .Show();
            }
        }
        else
            Console.WriteLine("Not playing");
    }
}
