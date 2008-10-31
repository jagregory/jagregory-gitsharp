using System;
using GitSharp;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class CompressionTests
    {
        [Test]
        public void CanDecompressFile()
        {
            var compression = new Compression();
            string value = compression.Decompress(@"Resources\commit");

            // should do better than this!
            Assert.That(value, Is.Not.Null);
        }
    }
}