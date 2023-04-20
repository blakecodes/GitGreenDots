using System.Diagnostics;



var currentDayOfYear = DateTime.Now.DayOfYear;

for (int i = 0; i < currentDayOfYear; i++)
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

    if (i == 35)
    {
        Thread.Sleep(1);
    }
    
    var dateUsed = new DateTime(DateTime.Now.Year, 1, 1).AddDays(i).ToString("U");
    // Update a file with the date
    cmd.StandardInput.WriteLine($"echo {dateUsed} >> green.txt");
    
    // Add all
    cmd.StandardInput.WriteLine($"git add .");

    // Commit the file
    try
    {
        cmd.StandardInput.WriteLine($"git commit --date=\"{currentDayOfYear - i} day ago\" -m \"{i}\" ");
    }
    catch (Exception e)
    {
        throw e;
    }

    // wait for one second to make sure the commit is done
    cmd.StandardInput.Flush();
    cmd.StandardInput.Close();
    cmd.WaitForExit();
    
    System.Threading.Thread.Sleep(100);
    
}



