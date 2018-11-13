using System;
using System.IO;

namespace CND
{
   public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CND");
        }


        public static void SaveFile(string fileName, byte[] byes)
        {
            File.WriteAllBytes($@"C:\Users\Peter\Desktop\Octodiff test\TestProject\CND\Games\{fileName}", byes);
        }

        public static byte[] GetFile(string fileName)
        {
            if (File.Exists($@"C:\Users\Peter\Desktop\Octodiff test\TestProject\CND\Games\{fileName}"))
                return File.ReadAllBytes(
                    $@"C:\Users\Peter\Desktop\Octodiff test\TestProject\CND\Games\{fileName}");

            return null;
        }
    }
}
