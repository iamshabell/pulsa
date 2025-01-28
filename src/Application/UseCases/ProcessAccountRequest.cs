using Core.Entities;
using Core.Interfaces;
using Core.ValueObjects;
using Application.DTOs;
using Infrastructure.Serialization;

namespace Application.UseCases
{
    public class ProcessAccountRequest
    {
        private readonly IEncryptionService _encryptionService;
        private readonly XmlSerializer _xmlSerializer;

        public ProcessAccountRequest(IEncryptionService encryptionService, XmlSerializer xmlSerializer)
        {
            _encryptionService = encryptionService;
            _xmlSerializer = xmlSerializer;
            
        }
        public string Process(Account account)
        {
            var encryptedData = _encryptionService.Encrypt(account.AccountNumber);

            return $"Processed request for account: {encryptedData.Data}";
        }
        public async Task<string> ProcessBalanceRequestAsync(string xmlRequest)
        {
            var request = _xmlSerializer.Deserialize<BalanceRequestDto>(xmlRequest);

            var accountNumber = await Task.Run(() => _encryptionService.Decrypt(new EncryptedData(request.AccountNumber)));

            Console.WriteLine($"Processing balance request for account: {accountNumber}");

            var response = new BalanceResponseDto
            {
                EncryptedAccountNumber = (await Task.Run(() => _encryptionService.Encrypt(accountNumber))).Data,
                EncryptedBalance = (await Task.Run(() => _encryptionService.Encrypt("1000"))).Data,
                EncryptedAccountProvider = (await Task.Run(() => _encryptionService.Encrypt("Bank"))).Data,
                Status = "Processed"
            };

            return _xmlSerializer.Serialize(response);
        }
    }
}