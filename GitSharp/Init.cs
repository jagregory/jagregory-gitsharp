using System.IO;

namespace GitSharp
{
    public class Init
    {
        private readonly string path;

        public Init(string path)
        {
            this.path = path;
        }

        public void Run()
        {
            EnsureRootExists();
            
            var gitDir = CreateGitDirectory();

            CreateDirectoryStructure(gitDir);
            CreateDefaultFiles(gitDir);
        }

        private void EnsureRootExists()
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        private string CreateGitDirectory()
        {
            Directory.CreateDirectory(Path.Combine(path, ".git"));

            return Path.Combine(path, ".git");
        }

        private void CreateDirectoryStructure(string gitDir)
        {
            Directory.CreateDirectory(Path.Combine(gitDir, "hooks"));
            Directory.CreateDirectory(Path.Combine(gitDir, "info"));
            Directory.CreateDirectory(Path.Combine(gitDir, @"objects\info"));
            Directory.CreateDirectory(Path.Combine(gitDir, @"objects\pack"));
            Directory.CreateDirectory(Path.Combine(gitDir, @"refs\head"));
            Directory.CreateDirectory(Path.Combine(gitDir, @"refs\tags"));
        }

        private void CreateDefaultFiles(string gitDir)
        {
            WriteFile(gitDir, "HEAD", "ref: refs/heads/master");

            WriteFile(gitDir, "config",
                "[core]",
	            "\trepositoryformatversion = 0",
	            "\tfilemode = false",
	            "\tbare = false",
	            "\tlogallrefupdates = true",
	            "\tsymlinks = false",
	            "\tignorecase = true");

            WriteFile(gitDir, "description", "Unnamed repository; edit this file to name it for gitweb.");

            WriteFile(Path.Combine(gitDir, "info"), "exclude",
                "# git-ls-files --others --exclude-from=.git/info/exclude",
                "# Lines that start with '#' are comments.",
                "# For a project mostly in C, the following would be a good set of",
                "# exclude patterns (uncomment them if you want to use them):",
                "# *.[oa]",
                "# *~");
        }

        private void WriteFile(string gitDir, string filename, params string[] content)
        {
            using (var file = File.CreateText(Path.Combine(gitDir, filename)))
            {
                foreach (var line in content)
                {
                    file.WriteLine(line);
                }
            }
        }
    }
}