using System.Collections.Generic;
using System.Linq;
using BusinessLogic;

namespace Domain
{
    /// <summary>
    /// Определить тип элемента массива или конкретного символа 
    /// </summary>
    public class TypeElem : ITypeElement
    {
        private static readonly List<char> Separators = new List<char> { ',', '.' };
        private static readonly List<char> Operations = new List<char> { '+', '-', '*', '/', '^' };

        /// <summary>
        /// Получить тип элемента(символа)
        /// </summary>
        /// <param name="elem">элемент(символ)</param>
        /// <returns>элемент массива или конкретный символ, тип которого нужно определить</returns>
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

        /// <summary>
        /// Определить, является ли элемент(символ) числом
        /// </summary>
        /// <param name="elem">элемент(символ)</param>
        /// <returns>true - если число, false - элемент не является числом</returns>
        private static bool IsNumber(string elem)
        {
            double tmp;
            return double.TryParse(elem, out tmp);
        }

        /// <summary>
        /// Определить, является ли элемент Знаком пунктуации
        /// </summary>
        /// <param name="elem">элемент(символ)</param>
        /// <returns>true - если знак пунктуации, false - не является знаком пунктуации</returns>
        private static bool IsSeparator(string elem)
        {
            return Separators.Contains(elem[0]);
        }

        /// <summary>
        /// Определить, является ли элемент Функцией
        /// </summary>
        /// <param name="elem">элемент(символ)</param>
        /// <returns>true - если функция(или буква), false - не является функцией</returns>
        private static bool IsFunc(string elem)
        {
            return elem.All(char.IsLetter);
        }

        /// <summary>
        /// Определить, является ли элемент Операцией
        /// </summary>
        /// <param name="elem">элемент(символ)</param>
        /// <returns>true - если элемент(символ) знак операции, false - не относится к знаком операций</returns>
        private static bool IsOperation(string elem)
        {
            return Operations.Contains(elem[0]);
        }

        /// <summary>
        /// Определить, является ли элемент Открывающейся скобкой
        /// </summary>
        /// <param name="elem">элемент(символ)</param>
        /// <returns>true - если элемент(символ) открывающаяся скобка, false - другой символ</returns>
        private static bool IsOpeningParenthesis(string elem)
        {
            return elem == "(";
        }

        // 
        /// <summary>
        /// Определить, является ли элемент Закрывающейся скобкой
        ///  </summary>
        /// <param name="elem">элемент(символ)</param>
        /// <returns>true - если элемент(символ) закрывающаяся скобка, false - другой символ</returns>
        private static bool IsClosingParenthesis(string elem)
        {
            return elem == ")";
        }
    }
}