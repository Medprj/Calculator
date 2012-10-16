using System;
using System.Collections.Generic;
using BusinessLogic;

namespace Domain
{
    public class MathExpressToRpn : IConvertToRpn
    {
        private readonly IOperation op;
        private readonly ITypeElement typeElem;

        public MathExpressToRpn(IOperation op, ITypeElement typeElem)
        {
            this.op = op;
            this.typeElem = typeElem;
        }

        // Метод конвертирует математическое выражение из инфиксной записи в постфиксную
        // string[] mathExpressAsArray - входное математическое выражение
        public string[] ToRpn(string[] mathExpressAsArray)
        {
            var mathExpress = new List<string>(); // выходная строка
            var stack = new Stack<string>(); // стек, хранящий ещё не добавленные к выходной строке операторы
            
            foreach (var elem in mathExpressAsArray) // получить очередной элемент(символ)
            {
                Types typeCurrentSymbol;
                if (!Enum.TryParse(typeElem.GetType(elem), true, out typeCurrentSymbol))
                {
                    throw new Exception("Невозможно определить тип символа");
                }

                switch (typeCurrentSymbol)
                {
                    case Types.Number: // если символ является числом, добавить его к выходной строке
                        mathExpress.Add(elem);
                        break;
                    case Types.Operation: // операция выталкивает из стека все операции с приоритетом <=
                        try // ошибка при получении приоритета
                        {
                            while (stack.Count != 0 && op.GetPriority(elem) <= op.GetPriority(stack.Peek()))
                            {
                                mathExpress.Add(stack.Pop());
                            }
                            stack.Push(elem);
                        }
                        catch
                        {
                            throw new Exception("Ошибка получения приоритета");
                        }
                        break;
                    case Types.Func: // Если символ является функцией, помещаем ее в стек
                    case Types.OpenParenthesis: // Если символ является открывающей скобкой, помещаем его в стек.    
                        stack.Push(elem);
                        break;
                    case Types.CloseParenthesis: // Если символ является закрывающей скобкой:
                        // выталкивает из стека всё, вплоть до открывающей скобки включительно,
                        // но сама скобка в стек не помещается
                        try // если неправильно расставлены скобки
                        {
                            while (stack.Peek() != "(")
                            {
                                mathExpress.Add(stack.Pop());
                            }
                            stack.Pop();
                            if(stack.Count == 0) break;
                            // если после этого шага на вершине стека оказывается символ функции, 
                            // выталкиваем его в выходную строку
                            Types symbolOnTopStack;
                            Enum.TryParse(typeElem.GetType(stack.Peek()), true, out symbolOnTopStack);
                            if (symbolOnTopStack == Types.Func)
                            {
                                mathExpress.Add(stack.Pop());
                            }
                        }
                        catch
                        {
                            throw new Exception("Непарная закрывающаяся скобка");
                        }
                        break;
                    case Types.Unknown:
                        throw new Exception("Неправильное математическое выражение"); // недопустимый символ
                }
            }
            // Когда входная строка закончилась, вытолкнуть все символы из стека в выходную строку
            while (stack.Count != 0)
            {
                if (stack.Peek() != "(")
                {
                    mathExpress.Add(stack.Pop());
                }
                else
                {
                    throw new Exception("Непарная открывающая скобка"); //  Непарная открывающая скобка
                }
            }
            return mathExpress.ToArray();
        }
    }
}