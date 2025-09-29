namespace DataProtection.DataProtection
{
    public interface IDataProtection
    {
        string Protected(string text);
        string Unprotected(string protectedText);
    }
}
