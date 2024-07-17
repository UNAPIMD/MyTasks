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

        [Test]
        public void TestRomanToInt()
        {
            Assert.That(RomanToInt("I"), Is.EqualTo(1));
            Assert.That(RomanToInt("II"), Is.EqualTo(2));
            Assert.That(RomanToInt("III"), Is.EqualTo(3));
            Assert.That(RomanToInt("IV"), Is.EqualTo(4));
            Assert.That(RomanToInt("V"), Is.EqualTo(5));
            Assert.That(RomanToInt("VI"), Is.EqualTo(6));
            Assert.That(RomanToInt("VII"), Is.EqualTo(7));
            Assert.That(RomanToInt("VIII"), Is.EqualTo(8));
            Assert.That(RomanToInt("IX"), Is.EqualTo(9));
            Assert.That(RomanToInt("X"), Is.EqualTo(10));
            Assert.That(RomanToInt("XI"), Is.EqualTo(11));
            Assert.That(RomanToInt("XII"), Is.EqualTo(12));


            Assert.That(RomanToInt("XXXV"), Is.EqualTo(35));
            Assert.That(RomanToInt("XLIX"), Is.EqualTo(49));
            Assert.That(RomanToInt("LVIII"), Is.EqualTo(58));
            Assert.That(RomanToInt("LXXXI"), Is.EqualTo(81));
            Assert.That(RomanToInt("XCIX"), Is.EqualTo(99));
            Assert.That(RomanToInt("CXXIII"), Is.EqualTo(123));
            Assert.That(RomanToInt("CCC"), Is.EqualTo(300));
            Assert.That(RomanToInt("DLL"), Is.EqualTo(600)); //DLL
            Assert.That(RomanToInt("MCD"), Is.EqualTo(1400));
            Assert.That(RomanToInt("MCDVII"), Is.EqualTo(1407));
            Assert.That(RomanToInt("MDV"), Is.EqualTo(1505));
            Assert.That(RomanToInt("MDCCCXII"), Is.EqualTo(1812));
            Assert.That(RomanToInt("MCMV"), Is.EqualTo(1905));
            Assert.That(RomanToInt("MCMLXII"), Is.EqualTo(1962));
            Assert.That(RomanToInt("MCMXCIV"), Is.EqualTo(1994));
            Assert.That(RomanToInt("MMVII"), Is.EqualTo(2007));
            Assert.That(RomanToInt("MMXVII"), Is.EqualTo(2017));
            Assert.That(RomanToInt("MMXVII"), Is.EqualTo(2017));
            Assert.That(RomanToInt("MMMI"), Is.EqualTo(3001));
            Assert.That(RomanToInt("MMMLXXXII"), Is.EqualTo(3082));
            Assert.That(RomanToInt("MMMCDIX"), Is.EqualTo(3409));

            Assert.That(() => RomanToInt(""), Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => RomanToInt(null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void TestTwoSum()
        {
            int[] arr = new int[]{ 1, 2, 3, 4 };
            Assert.That(TwoSum(arr, 3), Is.EqualTo((0, 1)));
            Assert.That(TwoSum(arr, 4), Is.EqualTo((0, 2)));
            Assert.That(TwoSum(arr, 6), Is.EqualTo((1, 3)));
            Assert.That(TwoSum(arr, 7), Is.EqualTo((2, 3)));

            Assert.That(TwoSum(arr, 0), Is.EqualTo((-1, -1)));
            Assert.That(TwoSum(arr, 8), Is.EqualTo((-1, -1)));

            arr = new int[]{ 3, 2, 4};
            Assert.That(TwoSum(arr, 6), Is.EqualTo((1, 2)));
            Assert.That(TwoSum(arr, 7), Is.EqualTo((0, 2)));

            Assert.That(TwoSum(arr, -1), Is.EqualTo((-1, -1)));
            Assert.That(TwoSum(arr, 10), Is.EqualTo((-1, -1)));

            arr = new int[] { 2, 7, 11, 15 };
            Assert.That(TwoSum(arr, 9), Is.EqualTo((0, 1)));
            Assert.That(TwoSum(arr, 18), Is.EqualTo((1, 2)));
            Assert.That(TwoSum(arr, 6), Is.EqualTo((1, 2)));
            Assert.That(TwoSum(arr, 26), Is.EqualTo((3, 4)));

            Assert.That(TwoSum(arr, -3), Is.EqualTo((-1, -1)));
            Assert.That(TwoSum(arr, 3), Is.EqualTo((-1, -1)));

            arr = new int[] { 1 };
            Assert.That(() => TwoSum(arr, 1), Throws.TypeOf<ArgumentOutOfRangeException>());

            arr = new int[] { };
            Assert.That(() => TwoSum(arr, 0), Throws.TypeOf<ArgumentOutOfRangeException>());

            arr = null;
            Assert.That(() => TwoSum(arr, 4), Throws.TypeOf<ArgumentNullException>());

        }
    }
}