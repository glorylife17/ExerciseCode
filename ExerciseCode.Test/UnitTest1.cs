using NUnit.Framework;

namespace ExerciseCode.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var method = new ExerciseCode.Method.TestFunction();
            var res = method.getFunction(5);

            Assert.AreEqual(1, res);
        }
    }
}