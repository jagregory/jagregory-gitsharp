using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GitSharp;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class InitTests
    {
        private const string Repos = "demo";

        [SetUp, TearDown]
        public void ClearRepos()
        {
            if (Directory.Exists(Repos))
                Directory.Delete(Repos, true);
        }

        [Test]
        public void CreatesDirectory()
        {
            Git.Init(Repos);

            Assert.That(Directory.Exists(Repos), Is.True);
        }

        [Test]
        public void CreatesGitDirectory()
        {
            Git.Init(Repos);

            var gitDir = Path.Combine(Repos, ".git");

            Assert.That(Directory.Exists(gitDir), Is.True);
        }

        [Test]
        public void CreatesHEADFile()
        {
            Git.Init(Repos);

            var gitDir = Path.Combine(Repos, ".git");
            var HEAD = Path.Combine(gitDir, "HEAD");

            Assert.That(File.Exists(HEAD), Is.True);
        }

        [Test]
        public void CreatesConfigFile()
        {
            Git.Init(Repos);

            var gitDir = Path.Combine(Repos, ".git");
            var config = Path.Combine(gitDir, "config");

            Assert.That(File.Exists(config), Is.True);
        }

        [Test]
        public void CreatesDescriptionFile()
        {
            Git.Init(Repos);

            var gitDir = Path.Combine(Repos, ".git");
            var description = Path.Combine(gitDir, "description");

            Assert.That(File.Exists(description), Is.True);
        }

        [Test]
        public void CreatesHooksDir()
        {
            Git.Init(Repos);

            var gitDir = Path.Combine(Repos, ".git");
            var hooks = Path.Combine(gitDir, "hooks");

            Assert.That(Directory.Exists(hooks), Is.True);
        }

        [Test]
        public void CreatesInfoDir()
        {
            Git.Init(Repos);

            var gitDir = Path.Combine(Repos, ".git");
            var info = Path.Combine(gitDir, "info");

            Assert.That(Directory.Exists(info), Is.True);
        }

        [Test]
        public void CreatesInfoExcludeFile()
        {
            Git.Init(Repos);

            var gitDir = Path.Combine(Repos, ".git");
            var info = Path.Combine(gitDir, "info\\exclude");

            Assert.That(File.Exists(info), Is.True);
        }

        [Test]
        public void CreatesObjectsDir()
        {
            Git.Init(Repos);

            var gitDir = Path.Combine(Repos, ".git");
            var objects = Path.Combine(gitDir, "objects");

            Assert.That(Directory.Exists(objects), Is.True);
        }

        [Test]
        public void CreatesObjectsInfoDir()
        {
            Git.Init(Repos);

            var gitDir = Path.Combine(Repos, ".git");
            var objectsInfo = Path.Combine(gitDir, "objects\\info");

            Assert.That(Directory.Exists(objectsInfo), Is.True);
        }

        [Test]
        public void CreatesObjectsPackDir()
        {
            Git.Init(Repos);

            var gitDir = Path.Combine(Repos, ".git");
            var objectsPack = Path.Combine(gitDir, "objects\\pack");

            Assert.That(Directory.Exists(objectsPack), Is.True);
        }

        [Test]
        public void CreatesRefsDir()
        {
            Git.Init(Repos);

            var gitDir = Path.Combine(Repos, ".git");
            var refs = Path.Combine(gitDir, "refs");

            Assert.That(Directory.Exists(refs), Is.True);
        }

        [Test]
        public void CreatesRefsHeadDir()
        {
            Git.Init(Repos);

            var gitDir = Path.Combine(Repos, ".git");
            var refsHead = Path.Combine(gitDir, "refs\\head");

            Assert.That(Directory.Exists(refsHead), Is.True);
        }

        [Test]
        public void CreatesRefsTagsDir()
        {
            Git.Init(Repos);

            var gitDir = Path.Combine(Repos, ".git");
            var refsTags = Path.Combine(gitDir, "refs\\tags");

            Assert.That(Directory.Exists(refsTags), Is.True);
        }
    }
}
