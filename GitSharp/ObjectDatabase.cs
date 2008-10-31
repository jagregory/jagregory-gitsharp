using System;
using System.IO;

namespace GitSharp
{
    public class ObjectDatabase
    {
        private readonly Compression zip;
        private readonly ObjectFactory objectFactory;
        private readonly string objectDir;

        public ObjectDatabase(string gitDir, Compression zip, ObjectFactory objectFactory)
        {
            this.zip = zip;
            this.objectFactory = objectFactory;
            objectDir = Path.Combine(gitDir, "objects");
        }

        // DI this!
        public ObjectDatabase(string gitDir)
            : this(gitDir, new Compression(), new ObjectFactory())
        {}

        public GitObject Find(string sha1Id)
        {
            if (sha1Id.Length != 40) throw new ArgumentException("Invalid SHA1 provided.", "sha1Id");

            string dirName = sha1Id.Substring(0, 2);
            string dirPath = Path.Combine(objectDir, dirName);

            if (!Directory.Exists(dirPath))
                throw new InvalidOperationException("Could not find SHA1 directory '" + dirName + "'.");

            string filename = sha1Id.Substring(2);
            string fullPath = Path.Combine(dirPath, filename);

            if (!File.Exists(fullPath))
                // should look in packs here?
                throw new InvalidOperationException("Could not find SHA1 file with path '" + fullPath + "'.");

            var uncompressedContent = zip.Decompress(fullPath);

            return objectFactory.CreateFromContent(uncompressedContent);
        }
    }
}