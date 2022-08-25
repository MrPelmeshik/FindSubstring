using System;
using System.Linq;

namespace FindSubstring
{
    public static class Program
    {
        public static void Main(string[] argv)
        {
            var str = "abcdefgdcehgbdg";
            
            var finder = new Finder(str);
            
            Console.Write($"TestCase (lenght:{str.Length}): {str}");
        
            var subString = finder.Do();
                
            Console.Write($"\n\tRes: (lenght:{subString.Length}): {subString}");
        }
    }
}