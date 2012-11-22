namespace BusinessLogic
{
    /// <summary>
    /// Конвертировать математическое выражение из инфиксной записи в постфиксную
    /// </summary>
    public interface IConvertToRpn
    {
        /// <summary>
        /// Конвертировать математическое выражение из инфиксной записи в постфиксную
        /// </summary>
        /// <param name="mathExpressAsArray">исходное математическое выражение</param>
        /// <returns>математическое выражение в обратной польской записи в виде массива</returns>
        string[] ToRpn(string[] mathExpressAsArray);
    }
}