using Microsoft.AspNetCore.DataProtection;

namespace DataProtection.DataProtection
{
    public class DataManager : IDataProtection
    {
        private readonly IDataProtector _dataProtector;
        public DataManager(IDataProtectionProvider provider)
        {
            _dataProtector = provider.CreateProtector("MyPurposeString");
        }
        public string Protected(string text)
        {
            return _dataProtector.Protect(text);
        }

        public string Unprotected(string protectedText)
        {
            return _dataProtector.Unprotect(protectedText);
        }
    }
}
