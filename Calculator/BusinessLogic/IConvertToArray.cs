namespace BusinessLogic
{
    /// <summary>
    /// Конвертирует входное математическое выражение из строки в массив
    /// </summary>
    public interface IConvertToArray
    {
        /// <summary>
        /// Конвертирует входное математическое выражение из строки в массив
        /// </summary>
        /// <param name="mathExpression">исходное математическое выражение в виде строки</param>
        /// <returns>математическое выражение в виде массива</returns>
        string[] ToArray(string mathExpression);
    }
}