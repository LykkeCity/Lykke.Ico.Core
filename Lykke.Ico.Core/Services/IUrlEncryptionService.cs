namespace Lykke.Ico.Core.Services
{
    public interface IUrlEncryptionService
    {
        string Encrypt(string message);
        string Decrypt(string message);
    }
}
