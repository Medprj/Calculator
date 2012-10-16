namespace BusinessLogic
{
    public interface IAction
    {
        string Exec(string operation, double[] param, string fileName, string type);
    }
}