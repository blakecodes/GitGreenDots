using System.Diagnostics;

var currentDayOfYear = DateTime.Now.DayOfYear;

for (int i = 0; i < 365; i++)
{
    Process cmd = new Process();
    cmd.StartInfo.FileName = "cmd.exe";
    cmd.StartInfo.RedirectStandardInput = true;
    cmd.StartInfo.RedirectStandardOutput = true;
    cmd.StartInfo.CreateNoWindow = false;
    cmd.StartInfo.UseShellExecute = false;
    cmd.Start(); // Start the processs ss
    
    Console.WriteLine("-----------------------------");
    Console.WriteLine($"Processing Day {i}");
    Console.WriteLine("-----------------------------");

    var dateUsed = new DateTime(DateTime.Now.AddYears(-1).Year, 1, 1).AddDays(i).ToString("U");
    
    var random = new Random().Next(0, 5);

    for (int j = 0; j < random; j++)
    {
        cmd.StandardInput.WriteLine($"echo {dateUsed}-{j} >> green.txt");
        // Add all
        cmd.StandardInput.WriteLine($"git add .");

        // Commit the file
        cmd.StandardInput.WriteLine($"git commit --date=\"{365 - i} day ago\" -m \"{i}\" ");
    }
    
    cmd.StandardInput.Flush();
    cmd.StandardInput.Close();
    cmd.WaitForExit();
}



