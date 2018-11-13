using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{

    public class FakeSchema
    {
        public FakeSchema()
        {
            Entries = new List<FakeSchemaEntry>();
        }
        public List<FakeSchemaEntry> Entries{ get; private set; }
    }


    public class FakeSchemaEntry
    {
        public string Location { get; set; }
        public long FileSize { get; set; }
        public string MD5_Checksum { get; set; }
        public Type Type { get; set; }
    }

    public class FakeSchemaFactory
    {
        public FakeSchema GetSchemaForExistingBuild()
        {
            FakeSchema schema = new FakeSchema();
            schema.Entries.Add(
            new FakeSchemaEntry()
            {
                FileSize = 1,
                Location = "/Game",
                MD5_Checksum = "75fd492b86c643c435415e72c0f97bd1",
               Type = Type.File
            });

            return schema;
        }
        public FakeSchema GetSchemaForNewBuild()
        {
            FakeSchema schema = new FakeSchema();
            schema.Entries.Add(
                new FakeSchemaEntry()
                {
                    FileSize = 1,
                    Location = "/Game",
                    MD5_Checksum = "75fd492b86c643c435415e72c0f97bd1",
                    Type = Type.DeltFile
                });

            return schema;
        }

    }
}
