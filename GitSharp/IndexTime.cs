namespace GitSharp
{
    public class IndexTime
    {
        private const int SecLength = 4;
        private const int NSecLength = 4;

        public int Sec { get; private set; }

        /// <summary>
        /// Not exactly sure what nsec is
        /// </summary>
        public int NSec { get; private set; }

        public void Load(GitObjectStream content)
        {
            content.ReadBytes(SecLength);
            content.ReadBytes(NSecLength);
        }
    }
}