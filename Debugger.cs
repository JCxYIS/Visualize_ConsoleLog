using System;
using System.Diagnostics;

public class Debugger
{
    Process process = new Process();

    public Debugger(string processPath, params string[] processParams)
    { 
        process.EnableRaisingEvents = true;
        process.OutputDataReceived += new DataReceivedEventHandler(process_OutputDataReceived);
        process.ErrorDataReceived += new DataReceivedEventHandler(process_ErrorDataReceived);
        process.Exited += new EventHandler(process_Exited);

        process.StartInfo.FileName = processPath;
        process.StartInfo.Arguments = String.Join(' ', processParams);
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardError = true;
        process.StartInfo.RedirectStandardOutput = true;

        try
        {
            process.Start();
            process.BeginErrorReadLine();
            process.BeginOutputReadLine();

            process.WaitForExit();
        }
        catch (Exception e)
        {
            Console.WriteLine("UNABLE TO LAUNCH!");
            return;
        }

    }

    void process_Exited(object sender, EventArgs e)
    {
        Console.WriteLine( $"=== Process exited with code {process.ExitCode} ===");
    }

    void process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
    {
        Console.WriteLine($"{DateTime.Now} [ERR] {e.Data}");
    }

    void process_OutputDataReceived(object sender, DataReceivedEventArgs e)
    {
        Console.WriteLine($"{DateTime.Now} [LOG] {e.Data}");
    }
}
