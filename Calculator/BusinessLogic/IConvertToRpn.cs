namespace BusinessLogic
{
    public interface IConvertToRpn
    {
        string[] ToRpn(string[] mathExpressAsArray);
    }
}