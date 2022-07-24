namespace EShop.Domain.Core;

public class User : BaseEntity
{
    public string UserName { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
}