using GitSharp;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ObjectFactoryTests
    {
        private const string FakeCommitContent = "commit 1234\0Body";

        [Test]
        public void ContentWithCommitHeaderReturnsCommitObject()
        {
            var factory = new ObjectFactory();
            var obj = factory.CreateFromContent(FakeCommitContent);

            Assert.That(obj, Is.TypeOf<Commit>());
        }

        [Test]
        public void ContentLengthParsed()
        {
            var factory = new ObjectFactory();
            var obj = factory.CreateFromContent(FakeCommitContent);

            Assert.That(obj.ContentLength, Is.EqualTo(1234));
        }
    }
}