using System;
using System.IO;
using Octodiff.Core;
using Octodiff.Diagnostics;

namespace Server
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }


        public static byte[] GetDeltaFile()
        {
            var newestFile =
                File.ReadAllBytes(@"C:\Users\Peter\Desktop\Octodiff test\TestProject\CND\Games\SwaggerGamev2.txt");

            var signatureFile =
                File.ReadAllBytes(
                    @"C:\Users\Peter\Desktop\Octodiff test\TestProject\Server\Sig\SwaggerGamev3.txt.octosig");

            var deltaBuilder = new DeltaBuilder();
            using (var signatureStream = new MemoryStream(signatureFile))
            using (var newFileStream = new MemoryStream(newestFile))
            using (var deltaStream = new MemoryStream())
            {
                deltaBuilder.BuildDelta(newFileStream, new SignatureReader(signatureStream, new ConsoleProgressReporter()), new AggregateCopyOperationsDecorator(new BinaryDeltaWriter(deltaStream)));
                return deltaStream.ToArray();
            }
        }
    }
}
