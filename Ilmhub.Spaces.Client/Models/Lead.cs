namespace Ilmhub.Spaces.Client.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public enum LeadStatus
{
    Created,
    Contacted,
    NoContact,
    Acquired,
    Lost,
    Closed
}

public enum LeadSource
{
    Website,
    Referral,
    SocialMedia,
    Advertisement,
    Other
}

public class Lead
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public string? Name { get; set; }

    public string? Email { get; set; }

    [Required(ErrorMessage = "Phone number is required")]
    [Phone(ErrorMessage = "Invalid phone number")]
    public string? Phone { get; set; }

    public LeadStatus Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }

    public LeadSource? Source { get; set; }

    public string? Notes { get; set; }

    public Course? Interest { get; set; }

    public List<Label>? Labels { get; set; }
}

public class Label
{
    public int Id { get; set; }
    public string? Name { get; set; }
}
