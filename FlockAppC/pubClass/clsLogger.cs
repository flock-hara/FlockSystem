using System;
using System.IO;
using System.Runtime.CompilerServices;

public class ClsLogger
{
    private static readonly string logFilePath = @"C:\FLOCK\フロックAPP\app.log";

    /// <summary>
    /// アプリケーションログ出力
    /// </summary>
    /// <param name="message"></param>
    public static void Log(string message, [CallerMemberName] string callerName = "")
    {
        string logMessage = $"[{DateTime.Now}] {callerName}: {message}";
        Console.WriteLine(logMessage); // コンソール出力
        File.AppendAllText(logFilePath, logMessage + Environment.NewLine); // ファイル出力
    }
}
