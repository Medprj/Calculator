using System;
using Domain;

namespace Calculator
{
    /// <summary>
    /// Calculator -  консольный калькулятор, который принимает входную строку, 
    /// содержащую математическое выражение (+, -, *, /, скобки) и выводит в консоль его результат.
    /// Автор: Медведев Александр Анатольевич
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Точка входа в программу
        /// </summary>
        public static void Main()
        {
            BusinessLogic.Calculator calc;
            var context = new Context(new ImplStrategy());
            try
            {
                calc = context.ExecuteOperation();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
                Console.ReadKey();
                return;
            }


            var exit = false; // признак выхода из программы

            while (exit != true)
            {
                Console.WriteLine("Введите математическое выражение и нажмите Enter:");
                var str = Console.ReadLine();

                if (str != null)
                    switch (str.ToLower().Trim())
                    {
                        case "":
                            Console.WriteLine("Для вызова справки введите \"?\" и нажмите Enter\n");
                            break;
                        case "e":
                            exit = true;
                            break;
                        case "?":
                            Console.WriteLine("------------------------------");
                            Console.WriteLine("Команда     Назначение");
                            Console.WriteLine("------------------------------");
                            Console.WriteLine("   ?        Вызов справки");
                            Console.WriteLine("   d        Показать описание");
                            Console.WriteLine("   s        Показать пример");
                            Console.WriteLine("   c        Очистить экран");
                            Console.WriteLine("   e        Выход");
                            Console.WriteLine("------------------------------\n");
                            break;
                        case "d":
                            Console.WriteLine("**************************************************************************");
                            Console.WriteLine("* Calculator -  консольный калькулятор, который принимает входную строку *");
                            Console.WriteLine("* содержащую математическое выражение (+, -, *, /, скобки) и выводит     *");
                            Console.WriteLine("* в консоль его результат. Решение можно расширять другими операциями    *");
                            Console.WriteLine("* Автор: Медведев Александр Анатольевич                                  *");
                            Console.WriteLine("**************************************************************************\n");
                            break;
                        case "c":
                            Console.Clear();
                            break;
                        case "s":
                            Console.WriteLine("Пример: (5-2)^2/6\n");
                            break;
                        default:
                            try
                            {
                                Console.WriteLine("Ответ: " + calc.Calc(str) + "\n");
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Ошибка: " + e.Message + "\n");
                            }
                            break;
                    }
            }
        }
    }
}