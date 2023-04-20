using System.Diagnostics;

Process cmd = new Process();
cmd.StartInfo.FileName = "cmd.exe";
cmd.StartInfo.RedirectStandardInput = true;
cmd.StartInfo.RedirectStandardOutput = true;
cmd.StartInfo.CreateNoWindow = true;
cmd.StartInfo.UseShellExecute = false;
cmd.Start(); // Start the processs ss

var currentDayOfYear = DateTime.Now.DayOfYear;

for (int i = 0; i < 2; i++)
{
    var dateUsed = new DateTime(DateTime.Now.Year, 1, 1).AddDays(i).ToString("U");
    // Update a file with the date
    cmd.StandardInput.WriteLine($"echo {dateUsed} >> green.txt");

    // Commit the file
    cmd.StandardInput.WriteLine($"git commit --date=\"{currentDayOfYear - i} day ago\" -m \"{dateUsed}\" ");
}

cmd.StandardInput.Flush();
cmd.StandardInput.Close();
cmd.WaitForExit();
Console.WriteLine(cmd.StandardOutput.ReadToEnd());