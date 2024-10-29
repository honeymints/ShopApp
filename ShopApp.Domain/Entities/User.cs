﻿using ShopApp.Domain.Common;

namespace ShopApp.Domain;

public class User : BaseEntity
{
    public string Name { get; set; } = null!;
    public string LastName { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}