using Microsoft.Toolkit.Uwp.Notifications;
using System.Diagnostics;
using System;
using System.Threading;
using System.Reflection.Metadata.Ecma335;

public class Program
{
    public const string PROC_NAME = "Spotify";
    public static string currentTitle { get; set; } = "";

    public static void Main()
    {
        var app = new Program();

        Timer timer = new Timer(Run, null, 0, 2000);

        Console.ReadLine();
    }

    private static string? GetTitle()
    {
        Process[] process = Process.GetProcessesByName(PROC_NAME);

        if (process == null) 
            return null;

        return process[0].MainWindowTitle;
    }

    private static void Run(Object o)
    {
        string? newTitle = GetTitle();
        

        if (!String.IsNullOrEmpty(newTitle))
        {
            if (currentTitle == newTitle)
            {
                return;
            }
            else
            {
                currentTitle = newTitle;
                
                new ToastContentBuilder()
                    .AddText("Spotify")
                    .AddText(currentTitle)
                    .Show();
            }
        }
        else
            Console.WriteLine("Not playing");
    }
}
