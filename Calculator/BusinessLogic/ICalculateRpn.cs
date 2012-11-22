namespace BusinessLogic
{
    /// <summary>
    /// Вычислить математическое выражение, записанное в обратной польской записи
    /// </summary>
    public interface ICalculateRpn
    {
        /// <summary>
        /// Вычислить выражения в обратной польской записи
        /// </summary>
        /// <param name="mathExpressAsRpn">исходное выражение</param>
        /// <returns>результат вычислений</returns>
        string Calculate(string[] mathExpressAsRpn);
    }
}