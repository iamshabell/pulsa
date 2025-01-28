using Core.Entities;
using Core.Interfaces;
using Core.ValueObjects;

namespace Application.UseCases
{
    public class ProcessAccountRequest
    {
        private readonly IEncryptionService _encryptionService;

        public ProcessAccountRequest(IEncryptionService encryptionService)
        {
            _encryptionService = encryptionService;
        }

        public Account Process(string name, string email, string password)
        {
            var encryptedPassword = _encryptionService.Encrypt(password);
            
            return $"Processed request for account: {encryptedData.Data}";
        }
    }
}