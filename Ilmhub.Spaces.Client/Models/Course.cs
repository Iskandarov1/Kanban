using System;

namespace Ilmhub.Spaces.Client.Models;

public enum CourseCategory
{
    English,
    IT
}

public enum CourseLevel
{
    Kids,
    Junior,
    Foundation,
    Advanced
}

public class Course
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public CourseCategory Category { get; set; }
    public CourseLevel Level { get; set; }
    public TimeSpan Duration { get; set; }
    public int SessionsPerWeek { get; set; }
    public string? Description { get; set; }
}
