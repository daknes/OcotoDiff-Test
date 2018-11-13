using System;
using System.IO;
using Octodiff.Core;
using Octodiff.Diagnostics;

namespace UserClient
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Enter to run");
                Console.ReadLine();
                DoDeltaUpdate(); 
            } while (true);
        }

        public static void DoDeltaUpdate()
        {
            var test = File.ReadAllBytes(
                $@"C:\Users\Peter\Desktop\Octodiff test\TestProject\UserClient\Game\SwaggerGame.txt");
            var deltaApplier = new DeltaApplier { SkipHashCheck = false };
            using (var basisStream = new MemoryStream(test))
            using (var newFileStream = new MemoryStream())
            using (var deltaStream = new MemoryStream(Server.Program.GetDeltaFile()))
            using (FileStream fs = new FileStream($@"C:\Users\Peter\Desktop\Octodiff test\TestProject\UserClient\Game\SwaggerGame.txt", FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))
            {
                deltaApplier.Apply(basisStream, new BinaryDeltaReader(deltaStream, new ConsoleProgressReporter()), newFileStream);
                newFileStream.WriteTo(fs);
            }
        }
    }
}
