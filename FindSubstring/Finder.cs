using System;
using System.Collections;

namespace FindSubstring
{
    public class Finder
    {
        private readonly string _str;

        public Finder(string str) => _str = str ?? throw new ArgumentNullException(str);
        
        public string Do()
                {
                    int maxLenght = 0; // Максимальная длинна последовательности уникальных символов (далее просто "последовательность")
                    int startIndex = 0; // Индекс начала максимальной последовательности
                    int startIndexLocalSubstring = 0; // Тут будет храниться индекс начала актуальной подстроки
                    int currentLenght = 0; // Длинна актуальной подстроки
                    Hashtable dict = new Hashtable(); // Хеш-таблица с символами из строки. Структура: (ключ: символ, значение: индекс последней встречи)
                    for (var i = 0; i < _str.Length; i++)
                    {
                        if (dict.ContainsKey(_str[i])) // Символ уже встречался?
                        {
                            var previousIndex = (int)dict[_str[i]]; // Получаем индекс последней позиции этого символа
                            if (previousIndex >= startIndexLocalSubstring) // Индекс последней встречи больше ИЛИ РАВЕН индекса начала подстроки?
                            {
                                currentLenght = i - startIndexLocalSubstring;
                                if (currentLenght >= maxLenght)
                                {
                                    maxLenght = currentLenght;
                                    startIndex = startIndexLocalSubstring;
                                }
                                startIndexLocalSubstring = previousIndex + 1; // Начало новой подстроки
                            }
                            
                            dict[_str[i]] = i; // Обновляем индекс символа в хеш-таблице
                        }
                        else
                        {
                            dict.Add(_str[i], i); // Добавляем символ в хеш-таблицу
                        }
                    }
                    
                    // Проверяем правую подстроку (либо строку состояющую полностью из уникальных символов)
                    currentLenght = _str.Length - startIndexLocalSubstring; 
                    if (currentLenght >= maxLenght)
                    {
                        maxLenght = currentLenght;
                        startIndex = startIndexLocalSubstring;
                    }
                    
                    return _str.Substring(startIndex, maxLenght);
                }
    }
}