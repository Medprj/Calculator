namespace BusinessLogic
{
    /// <summary>
    /// Определить тип элемента массива или конкретного символа 
    /// </summary>
    public interface ITypeElement
    {
        /// <summary>
        /// Получить тип элемента(символа)
        /// </summary>
        /// <param name="element">элемент(символ)</param>
        /// <returns>элемент массива или конкретный символ, тип которого нужно определить</returns>
        string GetType(string element);
    }
}