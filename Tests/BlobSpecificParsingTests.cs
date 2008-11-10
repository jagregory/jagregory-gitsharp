using GitSharp;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class BlobSpecificParsingTests
    {
        private byte[] content;
        private GitObjectStream Stream;

        [TestFixtureSetUp]
        public void UncompressFile()
        {
            var compression = new Zlib();

            content = compression.Decompress(@"Resources\blob");
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
        public void ParsesBlob()
        {
            var factory = new ObjectFactory();
            var blob = factory.CreateFromContent(Stream) as Blob;

            Assert.That(blob, Is.Not.Null);
            Assert.That(blob.Content.StartsWith("Git# - A .Net Git implementation"), Is.True);
            Assert.That(blob.Content.Length, Is.EqualTo(147));
        }
    }
}