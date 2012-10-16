namespace BusinessLogic
{
    public interface IOperation
    {
        int GetCountOperands(string operation);
        string GetName(string operation);
        int GetPriority(string operation);
        string GetFileName(string operation);
        string GetType(string operation);
    }
}