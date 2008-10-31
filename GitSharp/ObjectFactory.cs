using System;

namespace GitSharp
{
    public class ObjectFactory
    {
        public GitObject CreateFromContent(string content)
        {
            string[] headerAndRest = content.Split('\0');
            string header = headerAndRest[0];

            GitObject obj;

            if (header.StartsWith("commit"))
                obj = new Commit();
            else
                throw new NotImplementedException("Support for file type is not implemented.");

            obj.Load(content);

            return obj;
        }        
    }
}