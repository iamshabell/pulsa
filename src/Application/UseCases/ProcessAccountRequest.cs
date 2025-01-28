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

        public string Process(Account account)
        {
            var encryptedData = _encryptionService.Encrypt(account.AccountNumber);

            return $"Processed request for account: {account.AccountNumber}";
        }
    }
}