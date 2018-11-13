using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Octodiff.Core;
using Octodiff.Diagnostics;

namespace AdminClient
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("1 to run CreateSignature. 2 to run delta");
                var line = Console.ReadLine();
                if (line == "1")
                {
                    UploadFile("SwaggerGamev2.txt");
                }
                else
                {
                    CreateDeltaFile("SwaggerGame.txt");

                }


            } while (true);

        }


        public static void UploadFile(string fileName)
        {
            using (var basisStream = new MemoryStream(File.ReadAllBytes(
                    @"C:\Users\Peter\Desktop\Octodiff test\TestProject\AdminClient\Game\SwaggerGame.txt")))
            {
                CND.Program.SaveFile(fileName, basisStream.ToArray());

                var signaturFilebytes = CreateSignature(basisStream);
                CND.Program.SaveFile($@"{fileName}.octosig", signaturFilebytes);
            }
        }

        public static byte[] CreateSignature(Stream fileSteStream)
        {
            var signatureBuilder = new SignatureBuilder();
            using (var signatureStream = new MemoryStream())
            {
                signatureBuilder.Build(fileSteStream, new SignatureWriter(signatureStream));
                return signatureStream.ToArray();
            }
        }

        public static void CreateDeltaFile(string fileName)
        {
            var deltaBuilder = new DeltaBuilder();
            using (var signatureStream = new MemoryStream(CND.Program.GetFile(fileName + ".octosig")))
            using (var newFileStream = new MemoryStream(File.ReadAllBytes(@"C:\Users\Peter\Desktop\Octodiff test\TestProject\AdminClient\Game\SwaggerGame.txt")))
            using (var deltaStream = new MemoryStream())
            {
                deltaBuilder.BuildDelta(newFileStream, new SignatureReader(signatureStream, new ConsoleProgressReporter()), new AggregateCopyOperationsDecorator(new BinaryDeltaWriter(deltaStream)));
                var newSig = CreateSignature(newFileStream);
                //CND.Program.SaveFile($@"{fileName}.octosig", newSig);

                CND.Program.SaveFile($@"{fileName}.octodelta", deltaStream.ToArray());

               // return deltaStream.ToArray();
            }
        }


        public static string Hash(Stream stream)
        {
            using (MD5 myMd5 = MD5.Create())
            {
                byte[] hashValue;
                stream.Position = 0;
                hashValue = myMd5.ComputeHash(stream);
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < hashValue.Length; i++)
                {
                    sBuilder.Append(hashValue[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }
    }
}
