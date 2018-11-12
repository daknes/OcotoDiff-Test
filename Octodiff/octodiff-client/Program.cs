using System;
using System.Diagnostics;
using System.IO;
using Octodiff.Core;
using Octodiff.Diagnostics;

namespace octodiff_client
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                Console.WriteLine("Enter to Delta Upload file");
                Console.ReadLine();
                DeltaUploadFile("SwaggerGameDelta.txt");
                Console.WriteLine("Enter to Upload file");
                Console.ReadLine();
                UploadFile("SwaggerGame.txt");
            }
        }

        private static void DeltaUploadFile(string fileName)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
        

            var filePath = $@"C:\Users\Peter\Desktop\Octodiff test\Octodiff\Octodiff-client\Game\{fileName}";

            var deltaBuilder = new DeltaBuilder();
            using (var newFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (var signaturStream = new MemoryStream(signatur))
            using (var deltaStream = new MemoryStream())
            {
                deltaBuilder.BuildDelta(newFileStream, new SignatureReader(signaturStream, new ConsoleProgressReporter()), new AggregateCopyOperationsDecorator(new BinaryDeltaWriter(deltaStream)));
                Octodiff_test.Program.DeltaUploadFile(fileName, deltaStream.ToArray());
            }

            Console.WriteLine($"finished in {sw.Elapsed.TotalSeconds} secounds");
            sw.Stop();
        }

        private static void UploadFile(string fileName)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            var filePath = $@"C:\Users\Peter\Desktop\Octodiff test\Octodiff\Octodiff-client\Game\{fileName}";

            using (var newFileStream = new MemoryStream(File.ReadAllBytes(filePath)))
            {
                Octodiff_test.Program.UploadFile(fileName, newFileStream.ToArray());
            }

            Console.WriteLine($"finished in {sw.Elapsed.TotalSeconds} secounds");
            sw.Stop();
        }

    }
}
