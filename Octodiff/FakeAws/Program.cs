using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace FakeAws
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();}

        public static void SaveSignatur(string fileName, byte[] bytes)
        {
            using (MemoryStream stream = new MemoryStream(bytes))
            {
            File.WriteAllBytes($@"C:\Users\Peter\Desktop\Octodiff test\Octodiff\FakeAws\Games\{Hash(stream)}.octosig", bytes);

            }
        }

        public static byte[] GetFile(string fileName)
        {
            if(File.Exists($@"C:\Users\Peter\Desktop\Octodiff test\Octodiff\FakeAws\Games\{fileName}"))
            return File.ReadAllBytes(
                $@"C:\Users\Peter\Desktop\Octodiff test\Octodiff\FakeAws\Games\{fileName}");

            return null;
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
