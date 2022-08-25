using FindSubstring;

namespace FinderTests
{
    public class Tests
    {
        [SetUp]
        public void Setup() { }

        #region Простые примеры
        [TestCase("a", 
            ExpectedResult = "a", 
            TestName = "Одиночный символ", 
            Description = "")]
        [TestCase("ab", 
            ExpectedResult = "ab", 
            TestName = "Простая строка (2 символа)", 
            Description = "")]
        [TestCase("abc", 
            ExpectedResult = "abc", 
            TestName = "Простая строка (3 символа)", 
            Description = "")]
        [TestCase("aab", 
            ExpectedResult = "ab", 
            TestName = "Простая строка (вначале двойной символ)", 
            Description = "")]
        [TestCase("abb", 
            ExpectedResult = "ab", 
            TestName = "Простая строка (вконце двойной символ)", 
            Description = "")]
        [TestCase("abbc", 
            ExpectedResult = "bc", // Или "bc" в зависимости от реализации 
            TestName = "Простая строка (посередине двойной символ)", 
            Description = "")]
        #endregion
        #region Строки с пробелами
        [TestCase("ab cd", 
            ExpectedResult = "ab cd",
            TestName = "Строка с пробелами", 
            Description = "")]
        [TestCase("aab cd", 
            ExpectedResult = "ab cd", 
            TestName = "Строка с пробелами (вначале двойной символ)", 
            Description = "")]
        [TestCase("ab cdd", 
            ExpectedResult = "ab cd", 
            TestName = "Строка с пробелами (вконце двойной символ)", 
            Description = "")]
        [TestCase("ab  cd", 
            ExpectedResult = " cd", // Или " cd" в зависимости от реализации 
            TestName = "Строка с пробелами (посередине двойной символ)", 
            Description = "")]
        #endregion
        #region Различные строки
        [TestCase("abdcdabc", 
            ExpectedResult = "dabc", // Или "dabc" в зависимости от реализации 
            TestName = "Строка", 
            Description = "3 варианты ответа по 4 буквы в каждом")]
        [TestCase("abcahtretrebt", 
            ExpectedResult = "bcahtre", 
            TestName = "Левая подстрока с отступом в один символ", 
            Description = "")]
        [TestCase("abcatretrebtach", 
            ExpectedResult = "rebtach", 
            TestName = "Крайняя правая подстрока", 
            Description = "")]
        [TestCase("bcdefab", 
            ExpectedResult = "cdefab", 
            TestName = "Крайняя правая подстрока", 
            Description = "2 варианта")]
        [TestCase("abcdefgdcehgbdg", 
            ExpectedResult = "abcdefg", 
            TestName = "Крайняя левая подстрока", 
            Description = "")]
        [TestCase("abcdecddabcefg", 
            ExpectedResult = "dabcefg", 
            TestName = "Правая подстрока от двойного символа (сложная строка)", 
            Description = "")]
        [TestCase("abcddcb", 
            ExpectedResult = "abcd", 
            TestName = "Левая подстрока от двойного символа", 
            Description = "")]
        [TestCase("abccbad", 
            ExpectedResult = "cbad", 
            TestName = "Правая подстрока от двойного символа", 
            Description = "")]
        [TestCase("abc abcd abc", 
            ExpectedResult = "d abc", 
            TestName = "Крайняя правая подстрока (с пробелами)", 
            Description = "")]
        [TestCase("Mama mila ramu", 
            ExpectedResult = "mila r", 
            TestName = "Предложение (с пробелами)", 
            Description = "")]
        [TestCase("8 800 555 3 555", 
            ExpectedResult = "3 5", 
            TestName = "Цифры и пробелы", 
            Description = "")]
        [TestCase("555 3 555 008 8", 
            ExpectedResult = "08 ", 
            TestName = "Цифры и пробелы", 
            Description = "")]
        [TestCase("abbbderbder", 
            ExpectedResult = "bder", 
            TestName = "Строка с тройным символом", 
            Description = "")]
        [TestCase("Вышел заяц на крыльцо", 
            ExpectedResult = "на крыльцо", 
            TestName = "Строка с тройным символом", 
            Description = "")]
        #endregion
        public string Test(string str)
        {
            var finder = new Finder(str);
            return finder.Do();
        }
    }
}