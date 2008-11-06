using GitSharp;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class TreeSpecificParsingTests
    {
        private byte[] content;
        private GitObjectStream Stream;

        [TestFixtureSetUp]
        public void UncompressFile()
        {
            var compression = new Zlib();

            content = compression.Decompress(@"Resources\tree");
        }

        [SetUp]
        public void CreateStream()
        {
            Stream = new GitObjectStream(content);
        }

        [TearDown]
        public void DestroyStream()
        {
            Stream.Dispose();
        }

        [Test]
        public void ParsesTree()
        {
            var factory = new ObjectFactory();
            var tree = factory.CreateFromContent(Stream) as Tree;

            Assert.That(tree, Is.Not.Null);
            Assert.That(tree.Contents.Count, Is.AtLeast(1));
        }

        [Test]
        public void ParsesMultipleEntries()
        {
            var factory = new ObjectFactory();
            var tree = factory.CreateFromContent(Stream) as Tree;

            Assert.That(tree.Contents.Count, Is.EqualTo(8));
        }

        [Test]
        public void ParsesEntryMode()
        {
            var factory = new ObjectFactory();
            var tree = factory.CreateFromContent(Stream) as Tree;

            Assert.That(tree.Contents[0].Mode, Is.EqualTo("100644"));
        }

        [Test]
        public void ParsesEntryPath()
        {
            var factory = new ObjectFactory();
            var tree = factory.CreateFromContent(Stream) as Tree;

            Assert.That(tree.Contents.Count, Is.AtLeast(1));
            Assert.That(tree.Contents[0].Path, Is.EqualTo("CommitSpecificParsingTests.cs"));
        }

        [Test]
        public void ParsesEntrySha1()
        {
            var factory = new ObjectFactory();
            var tree = factory.CreateFromContent(Stream) as Tree;

            Assert.That(tree.Contents.Count, Is.AtLeast(1));
            Assert.That(tree.Contents[0].Sha1, Is.EqualTo("d6915d7880ce5b8c8d5d9e1c01a13d0b45c9f4b6"));
        }
    }
}