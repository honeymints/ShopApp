namespace ShopApp.Application.DTOs.User;


public class UserDto {
    public Guid Id {get;set;}
    public string Name { get; set; } = null!;
    public string LastName { get; set; }
    public string Email { get; set; } = null!;
   
}