namespace BusinessLogic
{
    /// <summary>
    /// Подключить *.dll и вызывать метод соответствующий математической операции
    /// </summary>
    public interface IAction
    {
        /// <summary>
        /// Подключить *.dll и вызывать метод соответствующий математической операции
        /// </summary>
        /// <param name="operation">математическая операция (имя метода)</param>
        /// <param name="param">операнды</param>
        /// <param name="fileName">имя файла-сборки</param>
        /// <param name="type">тип (базовый класс)</param>
        /// <returns>результат вычисления</returns>
        string Exec(string operation, double[] param, string fileName, string type);
    }
}