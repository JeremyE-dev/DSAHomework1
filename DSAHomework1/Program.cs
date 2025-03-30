using OfficeOpenXml;
using System.Diagnostics;
namespace DSAHomework1
{
    internal class Program
    {
        //Implement a main method that profiles the performance of Insert and Outputs a table
        //showing the average time perinsert as the length of the array increases
        static void Main(string[] args)
        {
        
            // Set the EPPlus license before using it
            ExcelPackage.License.SetNonCommercialPersonal("Jeremy");

            // setting to allow fine tuning of the granularirty of the reading
            int NUM_READINGS = 60;
            int INSERTS_PER_READING = 1000;

            // start with an array containing one element haviong the value of 0
            int[] array = new int[] { 0 };

            //initialize random number generators
            System.Random randomIndex = new System.Random();
            System.Random randomValue = new System.Random();

            //set output directory
            string outputDirectory = @"C:\DSA - UC San Diego\DSAHomework\DSAHomework1";

            // output to text file for raw data
            string textFilePath = Path.Combine(outputDirectory, "performance_results.txt");

            //output to excel to generate scatter plot
            string excelFilePath = Path.Combine(outputDirectory, "performance_results.xlsx");



            //take NUM_READINGS readings
            //Loop NUM_READINGS times
            // Each reading will be taken after INSERTS_PER_READING inserts

            //wrap logic in using so streamwriter and excel package are disposed of properly
            using (StreamWriter writer = new StreamWriter(textFilePath))
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Homework 1 Performance Results");
                
                // Write headers to console, text file
                string header = $"{"Array Length",-15} {"Seconds per Insert",-20}";
                Console.WriteLine(header);
                writer.WriteLine(header);

                string separator = new string('-', 35);
                Console.WriteLine(separator);
                writer.WriteLine(separator);

                // Write headers in Excel
                worksheet.Cells[1, 1].Value = "Array Length";
                worksheet.Cells[1, 2].Value = "Seconds per Insert";

                //starting row for excel
                int excelRow = 2;

                for (int i = 0; i < NUM_READINGS; i++)
                {
                    
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    
                    // insert INSERTS_PER_READING values into the array
                    for (int j = 0; j < INSERTS_PER_READING; j++)
                    {
                        int index = randomIndex.Next(0, array.Length);
                        int value = randomValue.Next();

                        array = Homework1.Insert(array, index, value);
                    }
            
                    sw.Stop();

                    double secondsPerInsert = (sw.ElapsedMilliseconds / 1000.0) / INSERTS_PER_READING;

                    string output = $"{array.Length,-15} {secondsPerInsert,-20:F6}";
                    
                    // Write to console and file
                    Console.WriteLine(output);
                    writer.WriteLine(output);

                    // Write data to Excel
                    worksheet.Cells[excelRow, 1].Value = array.Length;
                    worksheet.Cells[excelRow, 2].Value = secondsPerInsert;
                    excelRow++;
                }
                
                Console.WriteLine("Writing to Excel file...");
                File.WriteAllBytes(excelFilePath, excelPackage.GetAsByteArray());
                Console.WriteLine("Excel file written successfully.");
            }

            Console.WriteLine($"\nResults saved to {Path.GetFullPath(textFilePath)} and {Path.GetFullPath(excelFilePath)}");

        }
    }
}
