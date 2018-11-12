using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Octodiff.Core;

namespace Octodiff_test
{
    public class SignarturController
    {
        public static byte[] CreateSignaturFile(string fileName)
        {
            
            var signatureBaseFilePath = FakeAws.Program.GetFile(fileName);

            var signatureBuilder = new SignatureBuilder();
            using (var basisStream = new MemoryStream(signatureBaseFilePath))
            using (var signatureStream = new MemoryStream())
            {
                signatureBuilder.Build(basisStream, new SignatureWriter(signatureStream));
                FakeAws.Program.SaveSignatur(fileName,signatureStream.ToArray());
                return signatureStream.ToArray();
            }
        }
    }
}
