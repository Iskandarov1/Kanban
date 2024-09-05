namespace Ilmhub.Spaces.Client.Models;

using System;
using System.Collections.Generic;

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
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public LeadStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
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
