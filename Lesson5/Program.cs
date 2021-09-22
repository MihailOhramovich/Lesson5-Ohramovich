using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Lesson5
{
    class Program
    {
            class Message
            {

                private static string[] separators = { ",", ".", "?", ";", ":", " " };

                public static void PrintWords(string message)
                {
                    string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < words.Length; i++)
                    {
                        if (words[i].Length >= 3 && words[i][0] == words[i][words[i].Length - 1])
                        {
                            Console.WriteLine(words[i]);
                        }
                    }
                }
                /// <summary>
                /// Вывод слова длина которого не превышает n символов
                /// </summary>
                /// <param name="message"> строка </param>
                /// <param name="n">кол-во символов</param>
                public static void PrintWords(string message, int n)
                {
                    string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < words.Length; i++)
                    {
                        if (words[i].Length >= n)
                        {
                            Console.WriteLine($"{words[i]}");
                        }
                    }
                }
                /// <summary>
                /// Удаление слова Оканчивающегося на n символ
                /// </summary>
                /// <param name="message"></param>
                /// <param name="c"></param>
                public static void RemoveWords(string message, char c)
                {
                    string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < words.Length; i++)
                    {
                        if (words[i][words.Length - 1] == c)
                        {
                            words[i].Remove(0);
                        }
                    }
                }
                /// <summary>
                /// Поиск самого длинного слова.
                /// </summary>
                /// <param name="message"></param>
                public static void LengthWords(string message)
                {
                    string count1 = "";
                    string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < words.Length; i++)
                    {
                        if (words[i].Length > count1.Length)
                        {
                            count1 = words[i];
                        }
                    }
                    Console.WriteLine($"{count1} - самое длинное слово!");
                }
                /// <summary>
                /// Создание строки StringBuilder с самыми длинными словами
                /// </summary>
                /// <param name="message"></param>
                public static void LengthWordSB(string message)
                {
                    StringBuilder n = new StringBuilder();
                    string count1 = "";
                    string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < words.Length; i++)
                    {
                        if (words[i].Length > count1.Length)
                        {
                            count1 = words[i];
                        }
                    }
                    for (int i = 0; i < words.Length; i++)
                    {
                        if (words[i].Length == count1.Length)
                        {
                            n.Append(words[i]);
                        }
                    }
                }
            }

            static void Main(string[] args)
            {


                Console.WriteLine("Задача - 1\nСоздать программу, которая будет проверять корректность ввода логина. Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:");
                Console.WriteLine("\nВведите - 1 для задачи 1\nВведите - 2 для задачи 1 *");
                int taskNumber = int.Parse(Console.ReadLine());



                switch (taskNumber)
                {
                    #region Задача 1( без регулярных выражений)
                    case 1:
                        Console.WriteLine("Введите логин - \nКорректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:");
                        string d = Console.ReadLine();
                        d.ToCharArray();
                        int count = 0;
                        if (!char.IsDigit(d[0]) && d.Length > 2 && d.Length < 10)
                        {


                            for (int i = 0; i < d.Length; i++)
                            {
                                UnicodeCategory category = char.GetUnicodeCategory(d[i]);
                                switch (category)
                                {
                                    case UnicodeCategory.UppercaseLetter:
                                        //Console.WriteLine($"{d[i]} - буква в верхнем регистре.");

                                        break;
                                    case UnicodeCategory.LowercaseLetter:
                                        //Console.WriteLine($"{d[i]} - буква в нижнем регистре.");

                                        break;
                                    case UnicodeCategory.DecimalDigitNumber:
                                        //Console.WriteLine($"{d[i]} - число.");

                                        break;
                                    case UnicodeCategory.MathSymbol:
                                        //Console.WriteLine($"{d[i]} - математический символ.");
                                        count++;
                                        return;
                                    default:
                                        //Console.WriteLine($"{d[i]} - Другое");
                                        count++;
                                        return;
                                }
                                if (count > 0)
                                {
                                    Console.WriteLine("Логин не соответсувет условиям");
                                }
                            }
                            Console.WriteLine("Логин успешно создан");

                        }
                        else
                        {
                            Console.WriteLine("Логин не соответсувет условиям");
                        }
                        break;
                    #endregion
                    case 11:
                        string loggin = Console.ReadLine();
                        Regex reglog = new Regex("[a-zA-Z][0-9]{2,10}");
                        if (reglog.IsMatch(loggin) == true)
                        {
                            Console.WriteLine("Логин создан!");

                        }
                        else
                            Console.WriteLine("Логин не подходит");
                        break;
                }


            }
        }
    }

