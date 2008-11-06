using GitSharp;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ObjectFactoryTests
    {
        private GitObjectStream FakeCommitContent;

        [SetUp]
        public void CreateStream()
        {
            FakeCommitContent = "commit 1234\0Body"
                .ToGitObjectStream();
        }

        [TearDown]
        public void DestroyStream()
        {
            FakeCommitContent.Dispose();
        }

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