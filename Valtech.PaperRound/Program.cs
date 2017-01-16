using Ninject;
using Valtech.PaperRound.Ninject;
using Valtech.PaperRound.Core.Report;
using System;
using System.IO;

namespace PaperRound
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var fileName = args.Length > 0 ? args[0].ToString() : "street1.txt";
                IKernel kernel = new StandardKernel(new Installer());

                var reportBuilder = kernel.Get<ReportBuilder>();
                reportBuilder.GenerateReport(fileName);
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Incorrect specification format");
            }
        }
    }
}
