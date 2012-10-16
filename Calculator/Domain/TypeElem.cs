using System.Collections.Generic;
using System.Linq;
using BusinessLogic;

namespace Domain
{
    // класс дл€ определени€ типа элемента(символа)
    public class TypeElem : ITypeElement
    {
        private static readonly List<char> Separators = new List<char> { ',', '.' };
        private static readonly List<char> Operations = new List<char> { '+', '-', '*', '/', '^' };
        // метод возвращает тип элемента(символа)
        // string elem - входной элемент
        public string GetType(string elem)
        {
            if (!string.IsNullOrEmpty(elem))
            {
                if (IsNumber(elem)) return "number";
                if (IsSeparator(elem)) return "separator";
                if (IsFunc(elem)) return "func";
                if (IsOperation(elem)) return "operation";
                if (IsOpeningParenthesis(elem)) return "openParenthesis";
                if (IsClosingParenthesis(elem)) return "closeParenthesis";
            }
            return "Unknown";
        }

        // явл€етс€ ли элемент „ислом
        private static bool IsNumber(string elem)
        {
            double tmp;
            return double.TryParse(elem, out tmp);
        }

        // явл€етс€ ли элемент «наком пунктуации
        private static bool IsSeparator(string elem)
        {
            return Separators.Contains(elem[0]);
        }

        // явл€етс€ ли элемент ‘ункцией
        private static bool IsFunc(string elem)
        {
            return elem.All(char.IsLetter);
        }

        // явл€етс€ ли элемент ќперацией
        private static bool IsOperation(string elem)
        {
            
            return Operations.Contains(elem[0]);
        }

        // явл€етс€ ли элемент ќткрывающейс€ скобкой
        private static bool IsOpeningParenthesis(string elem)
        {
            return elem == "(";
        }

        // явл€етс€ ли элемент «акрывающейс€ скобкой
        private static bool IsClosingParenthesis(string elem)
        {
            return elem == ")";
        }
    }
}