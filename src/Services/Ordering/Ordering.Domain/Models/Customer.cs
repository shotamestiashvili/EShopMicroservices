﻿using Ordering.Domain.Abstraction;
using Ordering.Domain.ValueObjects;

namespace Ordering.Domain.Models;

public class Customer : Entity<CustomerId>
{
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;

    public static Customer Create(CustomerId id, string name, string email)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(name), name);
        ArgumentException.ThrowIfNullOrEmpty(nameof(email), email);

        var customer = new Customer
        {
            Id = id,
            Name = name,
            Email = email
        };
        
        return customer;
    }
}