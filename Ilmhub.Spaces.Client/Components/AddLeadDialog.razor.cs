using Ilmhub.Spaces.Client.Models;
using Ilmhub.Spaces.Client.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;

namespace Ilmhub.Spaces.Client.Components;

public partial class AddLeadDialog : IDialogContentComponent<Lead>
{
    [Inject]
    private ICourseDataService CourseDataService { get; set; } = default!;

    [Parameter]
    public Lead Content { get; set; } = default!;

    [CascadingParameter]
    public FluentDialog Dialog { get; set; } = default!;

    [Parameter]
    public EventCallback<Lead> OnSave { get; set; }

    [Parameter]
    public EventCallback OnCancel { get; set; }

    private string selectedSource = string.Empty;

    private List<Course> courses = new();
    private Course? selectedCourse;
    private IEnumerable<Course> selectedCourses = [];
    private IEnumerable<LeadSource> selectedSources = [];

    protected override async Task OnInitializedAsync()
    {
        selectedSource = Content?.Source.ToString() ?? string.Empty;
        courses = await CourseDataService.GetAllCoursesAsync();
        selectedCourse = Content?.Interest;
    }

    private async Task SaveAsync()
    {
        Content.Source = selectedSources.FirstOrDefault();
        Content.Interest = selectedCourses.FirstOrDefault();

        await OnSave.InvokeAsync(Content);
        await Dialog.CloseAsync(Content);
    }

    private async Task CancelAsync()
    {
        await OnCancel.InvokeAsync();
        await Dialog.CancelAsync();
    }

    private async Task SearchLeadSourcesAsync(OptionsSearchEventArgs<LeadSource> args)
    {
        args.Items = Enum.GetValues(typeof(LeadSource))
            .Cast<LeadSource>()
            .Where(source => source.ToString().Contains(args.Text, StringComparison.OrdinalIgnoreCase));

        await Task.CompletedTask;
    }

    private async Task SearchCoursesAsync(OptionsSearchEventArgs<Course> args)
    {
        args.Items = courses.Where(course => course.Name!.Contains(args.Text, StringComparison.OrdinalIgnoreCase));

        await Task.CompletedTask;
    }
}

