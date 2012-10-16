namespace BusinessLogic
{
    public interface IOperations
    {
        string Name { get; set; } // имя операции (имя метода)
        string Value { get; set; } // операция
        int Operands { get; set; }  // количество операндов
        int Priority { get; set; }  // приоритет
        string Placement { get; set; } // имя сборки, где находится соответствующий метод
        string Type { get; set; }  // полное имя типа 
    }
}