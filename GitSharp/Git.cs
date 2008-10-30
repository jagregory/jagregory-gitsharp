namespace GitSharp
{
    public class Git
    {
        /// <summary>
        /// Initialises an empty git repository.
        /// </summary>
        /// <param name="path">Repository path</param>
        public static void Init(string path)
        {
            new Init(path).Run();
        }
    }
}
