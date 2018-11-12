using System;
using System.IO;
using System.Runtime.InteropServices;
using Octodiff.Core;
using Octodiff.Diagnostics;

namespace Octodiff_test
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Waiting for new file");
                Console.ReadLine();
            }
        }

        public static byte[] GenerateSignarut()
        {
           return SignarturController.CreateSignaturFile("75fd492b86c643c435415e72c0f97bd1");
        }

        public static void DeltaUploadFile(string fileName, byte[] deltaBytes)
        {
            Console.WriteLine("new file to upload");
            Console.WriteLine($"DeltaStream Length: {deltaBytes.Length}");
            var signatureBaseFilePath = File.ReadAllBytes(
                $@"C:\Users\Peter\Desktop\Octodiff test\Octodiff\Octodiff-test\Game\{fileName}");


            var deltaApplier = new DeltaApplier { SkipHashCheck = false };
            using (var basisStream = new MemoryStream(signatureBaseFilePath))
            using (var newFileStream = new MemoryStream())
            using(var deltaStream = new MemoryStream(deltaBytes))
            using (FileStream fs = new FileStream($@"C:\Users\Peter\Desktop\Octodiff test\Octodiff\Octodiff-test\Game\{fileName}", FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                deltaApplier.Apply(basisStream, new BinaryDeltaReader(deltaStream, new ConsoleProgressReporter()), newFileStream);
                newFileStream.WriteTo(fs);
            }
            

        }

        public static void UploadFile(string fileName, byte[] bytes)
        {
            Console.WriteLine("new file to upload");
            Console.WriteLine($"DeltaStream Length: {bytes.Length}");
            using (var newFileStream = new MemoryStream(bytes))
            using (FileStream fs = new FileStream($@"C:\Users\Peter\Desktop\Octodiff test\Octodiff\Octodiff-test\Game\{fileName}", FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                newFileStream.WriteTo(fs);
            }
        }
    }
}
