using GitSharp;

namespace Tests
{
    public static class TestExtensions
    {
        public static GitObjectStream ToGitObjectStream(this string content)
        {
            return new GitObjectStream(content.ToByteArray());
        }
    }
}