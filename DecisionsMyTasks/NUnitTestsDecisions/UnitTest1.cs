using static DecisionsMyTasks.Decisions;

namespace NUnitTestsDecisions
{
    /// <summary>
    /// Класс тестов решений задач
    /// </summary>
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(0, ExpectedResult = 0)]
        [TestCase(1, ExpectedResult = 1)]
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(123, ExpectedResult = 321)]
        [TestCase(1234, ExpectedResult = 4321)]
        [TestCase(-1, ExpectedResult = -1)]
        [TestCase(-12, ExpectedResult = -21)]
        [TestCase(-123, ExpectedResult = -321)]
        [TestCase(-1234, ExpectedResult = -4321)]
        [TestCase(10, ExpectedResult = 1)]
        [TestCase(120, ExpectedResult = 21)]
        [TestCase(1230, ExpectedResult = 321)]
        [TestCase(-10, ExpectedResult = -1)]
        [TestCase(-120, ExpectedResult = -21)]
        [TestCase(-1230, ExpectedResult = -321)]
        [TestCase(102, ExpectedResult = 201)]
        [TestCase(-102, ExpectedResult = -201)]
        [TestCase(1020, ExpectedResult = 201)]
        [TestCase(-1020, ExpectedResult = -201)]
        [TestCase(10203, ExpectedResult = 30201)]
        [TestCase(-10203, ExpectedResult = -30201)]
        [TestCase(Int32.MaxValue, ExpectedResult = 0)]
        [TestCase(Int32.MinValue, ExpectedResult = 0)]
        public int TestReverse(int num)
        {
            return Reverse(num);
        }
        [TestCase(0, ExpectedResult = true)]
        [TestCase(12, ExpectedResult = false)]
        [TestCase(123, ExpectedResult = false)]
        [TestCase(121, ExpectedResult = true)]
        [TestCase(323, ExpectedResult = true)]
        [TestCase(320, ExpectedResult = false)]
        [TestCase(102, ExpectedResult = false)]
        [TestCase(101, ExpectedResult = true)]
        [TestCase(100, ExpectedResult = false)]
        [TestCase(-2, ExpectedResult = false)]
        [TestCase(-28, ExpectedResult = false)]
        [TestCase(-9, ExpectedResult = false)]
        [TestCase(-95, ExpectedResult = false)]
        [TestCase(-808, ExpectedResult = false)]
        [TestCase(-801, ExpectedResult = false)]
        [TestCase(-900, ExpectedResult = false)]
        [TestCase(-330, ExpectedResult = false)]
        [TestCase(int.MaxValue, ExpectedResult = false)]
        [TestCase(int.MinValue, ExpectedResult = false)]
        public bool TestIsPalindrome(int num)
        {
            return IsPalindrome(num);
        }
    }
}