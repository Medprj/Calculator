using System;
using BusinessLogic;
using System.Collections.Generic;

namespace Domain
{
    public class MathExpressToArray : IConvertToArray
    {
        private readonly ITypeElement typeElem;
        public MathExpressToArray(ITypeElement typeElement)
        {
            typeElem = typeElement;
        }

        // Метод конвертирует входное математическое выражение из строки в массив
        // string mathExpression - исходное математическое выражение
        public string[] ToArray(string baseMathExpress)
        {
            baseMathExpress = baseMathExpress.Replace(".", ",");

            var mathExpress = new List<string>(); // результат преобразований
            var typePreviousSymbol = Types.Unknown;

            foreach (var symbol in baseMathExpress)
            {
                Types typeCurrentSymbol;
                if (!Enum.TryParse(typeElem.GetType(symbol.ToString()), true, out typeCurrentSymbol))
                {
                    throw new Exception("Невозможно определить тип символа");
                }
                switch (typeCurrentSymbol)
                {
                    case Types.Number:
                        // если тип текущего символа такой же как у предыдущего или это знак препинания, 
                        // то добавить символ к текущему элементу массива
                        if (typeCurrentSymbol == typePreviousSymbol || typePreviousSymbol == Types.Separator)
                        {
                            mathExpress[mathExpress.Count - 1] += symbol;
                        }
                        else
                        {
                            mathExpress.Add(symbol.ToString());
                        }
                        break;
                    case Types.Separator:
                        if (typePreviousSymbol == Types.Number)
                        {
                            mathExpress[mathExpress.Count - 1] += symbol;
                        }
                        break;
                    case Types.Func:
                        if (typeCurrentSymbol == typePreviousSymbol)
                        {
                            mathExpress[mathExpress.Count - 1] += symbol;
                        }
                        else
                        {
                            // если после числа сразу идет имя функции, то пропущен знак "*"
                            if (typePreviousSymbol == Types.Number) mathExpress.Add("*");
                            mathExpress.Add(symbol.ToString());
                        }
                        break;
                    case Types.Operation:
                        // если перед знаком "-" идет открывающаяся скобка или нет цифры, 
                        // то это унарный оператор, поставить перед ним 0
                        if (symbol.ToString() == "-" &&
                            (typePreviousSymbol != Types.Number || typePreviousSymbol == Types.OpenParenthesis))
                        {
                            mathExpress.Add("0");
                        }
                        mathExpress.Add(symbol.ToString());
                        break;
                    case Types.CloseParenthesis:
                        mathExpress.Add(symbol.ToString());
                        break;
                    case Types.OpenParenthesis:
                        // если после числа сразу идет открывающаяся скобка, то пропущен знак "*"
                        if (typePreviousSymbol == Types.Number) mathExpress.Add("*");
                        mathExpress.Add(symbol.ToString());
                        break;
                    case Types.Unknown:
                        throw new Exception("Недопустимый символ: \"" + symbol + "\""); // недопустимый символ
                }
                // Запомним тип текущего символа
                typePreviousSymbol = typeCurrentSymbol;
            }
            return mathExpress.ToArray();
        }
    }
}