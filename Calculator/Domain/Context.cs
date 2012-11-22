using BusinessLogic;

namespace Domain
{
    /// <summary>
    /// Контекст, использующий стратегию для решения своей задачи
    /// </summary>
    public class Context
    {
        /// <summary>
        /// Ссылка на интерфейс <see cref="BusinessLogic.IStrategy">BusinessLogic.IStrategy</see>
        /// позволяет автоматически переключаться между конкретными реализациями
        /// </summary>
        private readonly IStrategy strategy;

        /// <summary>
        /// Инициализировать объект конкретным вариантом реализации(стратегией)
        /// </summary>
        /// <param name="strategy">стратегия</param>
        public Context(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        /// <summary>
        /// Использовать выбранную стратегию
        /// </summary>
        public Calculator ExecuteOperation()
        {
            return strategy.CreateCalc();
        }
    }
}