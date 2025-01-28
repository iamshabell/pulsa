# Pulsa

It is an experimental project aimed at testing secure communication between banks. The main goal is to enable systems to exchange encrypted data such as account balances, transactions, and other financial details through XML messages.

The project is focused on facilitating a secure, encrypted exchange of information in banking systems, where details like account balances can be securely transmitted using encryption.

### Features:

#### 1. Balance Inquiries:
- Banks can inquire about the balance of an account by sending an XML request to the system.
- The system responds with the account balance in an encrypted format.

**Request Example:**
```xml
<BalanceRequest xmlns="http://www.yournamespace.com">
    <AccountNumber>123456789</AccountNumber>
    <AccountType>1000</AccountType>
    <AccountProvider>bank</AccountProvider>
</BalanceRequest>
```

**Response:**
```xml
<BalanceResponse
	xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
	xmlns:xsd="http://www.w3.org/2001/XMLSchema">
	<EncryptedAccountNumber>MNgJbUjuHIaFhJpmD7fJVw==</EncryptedAccountNumber>
	<EncryptedBalance>Yzv5VgZMIX3IYqxDr296kw==</EncryptedBalance>
	<EncryptedAccountProvider>zZ/Yo6BmJC5955zO6U8+jA==</EncryptedAccountProvider>
	<Status>Processed</Status>
</BalanceResponse>
```

#### 1. Balance Inquiries(for local):
- A request for decryption can be sent to test the decryption process.
- The encrypted details in the XML request are decrypted to reveal the full information.

    
    
**Request Example:**
```xml
<BalanceResponse
	xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
	xmlns:xsd="http://www.w3.org/2001/XMLSchema">
	<EncryptedAccountNumber>MNgJbUjuHIaFhJpmD7fJVw==</EncryptedAccountNumber>
	<EncryptedBalance>Yzv5VgZMIX3IYqxDr296kw==</EncryptedBalance>
	<EncryptedAccountProvider>zZ/Yo6BmJC5955zO6U8+jA==</EncryptedAccountProvider>
</BalanceResponse>

```

*Response:**
```json
{
	"encryptedAccountNumber": "123456789",
	"encryptedBalance": "1000",
	"encryptedAccountProvider": "Bank",
	"status": "Success"
}
```

#### explore?:
- Key Management(private/public keys)
- Multi-Bank Communication
- gRPC integrations
