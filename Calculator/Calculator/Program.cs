using System;
using Domain;

// Calculator -  консольный калькулятор, который принимает входную строку, 
// содержащую математическое выражение (+, -, *, /, скобки) и выводит в консоль его результат.
// Автор: Медведев Александр Анатольевич
namespace Calculator
{
    public static class Program
    {
        public static void Main()
        {
            // Открыть и получить данные из файла, в котором
            // хранится перечень математических операций
            // и их атрибуты. В случае неудачи - уведомить пользователя 
            // и выйти из программы
            Operation<Operations> operation;
            try
            {
                operation = new Operation<Operations>();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
                Console.ReadKey();
                return;
            }


            var typeElem = new TypeElem();

            var calc = new BusinessLogic.Calculator(new MathExpressToArray(typeElem),
                                                    new MathExpressToRpn(operation, typeElem),
                                                    new CalculateRpn(new Domain.Action(), operation, typeElem));


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