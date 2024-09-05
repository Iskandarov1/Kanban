using Ilmhub.Spaces.Client.Models;
using Ilmhub.Spaces.Client.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;

namespace Ilmhub.Spaces.Client.Pages;

public partial class Programs
{
    [Inject] protected ICourseDataService CourseDataService { get; set; } = default!;

    protected List<Course> courses = [];
    protected PaginationState pagination = new() { ItemsPerPage = 10 };
    protected string nameFilter = string.Empty;

    protected IQueryable<Course>? FilteredItems => courses
        .Where(x => x.Name!.Contains(nameFilter, StringComparison.CurrentCultureIgnoreCase))
        .AsQueryable();

    protected override async Task OnInitializedAsync()
    {
        courses = await CourseDataService.GetAllCoursesAsync();
        await pagination.SetTotalItemCountAsync(courses.Count);
    }

    protected void HandleCourseFilter(ChangeEventArgs args) =>
        nameFilter = args.Value as string ?? string.Empty;

    protected void HandleClear()
    {
        if (string.IsNullOrWhiteSpace(nameFilter))
            nameFilter = string.Empty;
    }

    protected void HandleRowFocus(FluentDataGridRow<Course> row) =>
        Console.WriteLine($"Row focused: {row.Item?.Name}");
}