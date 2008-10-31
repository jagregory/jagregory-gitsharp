using GitSharp;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class CommitSpecificParsingTests
    {
        private const string CommitContent = "commit 187\0tree f37a9edbaa5601df27dcc24df5fcff752314b3ec\nauthor James Gregory <james@jagregory.com> 1225463078 +0000\ncommitter James Gregory <james@jagregory.com> 1225463078 +0000\n\nAdded first file\n";
        
        [Test]
        public void ParsesTreeHashId()
        {
            var factory = new ObjectFactory();
            var commit = factory.CreateFromContent(CommitContent) as Commit;

            Assert.That(commit.TreeId, Is.EqualTo("f37a9edbaa5601df27dcc24df5fcff752314b3ec"));
        }

        [Test]
        public void ParsesAuthor()
        {
            var factory = new ObjectFactory();
            var commit = factory.CreateFromContent(CommitContent) as Commit;

            Assert.That(commit.Author, Is.EqualTo("James Gregory <james@jagregory.com>"));
        }

        [Test]
        public void ParsesCommitter()
        {
            var factory = new ObjectFactory();
            var commit = factory.CreateFromContent(CommitContent) as Commit;

            Assert.That(commit.Committer, Is.EqualTo("James Gregory <james@jagregory.com>"));
        }

        [Test]
        public void ParsesComment()
        {
            var factory = new ObjectFactory();
            var commit = factory.CreateFromContent(CommitContent) as Commit;

            Assert.That(commit.Comment, Is.EqualTo("Added first file"));
        }
    }
}