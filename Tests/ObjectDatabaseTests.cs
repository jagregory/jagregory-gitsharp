using System.IO;
using GitSharp;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ObjectDatabaseTests
    {
        [TestFixtureSetUp]
        public void CreateRepository()
        {
            DestroyRepository();

            Git.Init("testRepository");

            // copy our commit file to our repos objects dir
            Directory.CreateDirectory(@"testRepository\.git\objects\2a");
            File.Copy(@"Resources\commit", @"testRepository\.git\objects\2a\38b629260b2ff9c32123be4c0da6302b7cdc11");
        }

        [TestFixtureTearDown]
        public void DestroyRepository()
        {
            if (Directory.Exists("testRepository"))
                Directory.Delete("testRepository", true);
        }

        [Test]
        public void CanFindCommit()
        {
            var objectDb = new ObjectDatabase(@"testRepository\.git");
            var obj = objectDb.Find("2a38b629260b2ff9c32123be4c0da6302b7cdc11");

            Assert.That(obj, Is.TypeOf<Commit>());
        }
    }
}