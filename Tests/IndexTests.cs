using System.IO;
using GitSharp;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class IndexTests
    {
        private GitObjectStream stream;

        [SetUp]
        public void ReadIndex()
        {
            stream = new GitObjectStream(File.ReadAllBytes(@"Resources\index"));
        }

        [TearDown]
        public void DestroyStream()
        {
            stream.Dispose();
        }

        [Test]
        public void CanReadHeader()
        {
            var index = new Index();
            
            index.Load(stream);

            Assert.That(index.Header, Is.Not.Null);
            Assert.That(index.Header.Signature, Is.EqualTo("DIRC"));
            Assert.That(index.Header.Version, Is.EqualTo(2));
            Assert.That(index.Header.Entries, Is.EqualTo(2));
        }

        [Test]
        public void CanReadSignature()
        {
            var index = new Index();

            index.Load(stream);

            Assert.That(index.Sha1Signature, Is.EqualTo("4EB7F326D9A260C05AAA01C48F8A4DA8E3DF7801"));
        }
    }
}