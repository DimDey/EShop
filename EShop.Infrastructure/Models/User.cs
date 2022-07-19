using EShop.Infrastructure.Entities;

namespace EShop.Infrastructure.Models;

public class User : BaseEntity
{
    public string Name { get; set; }
    public string Role { get; set; }
    private string PasswordHash { get; set; }
}