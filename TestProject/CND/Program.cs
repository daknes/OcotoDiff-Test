using System;
using System.IO;

namespace CND
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static byte[] GetFile(string fileName)
        {
            if (File.Exists($@"C:\Users\Peter\Desktop\Octodiff test\Octodiff\FakeAws\Games\{fileName}"))
                return File.ReadAllBytes(
                    $@"C:\Users\Peter\Desktop\Octodiff test\Octodiff\FakeAws\Games\{fileName}");

            return null;
        }
    }
    }
}
