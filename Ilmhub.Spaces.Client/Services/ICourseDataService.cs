using Ilmhub.Spaces.Client.Models;

namespace Ilmhub.Spaces.Client.Services;

public interface ICourseDataService
{
    Task<List<Course>> GetAllCoursesAsync(CancellationToken cancellationToken = default);
    Task<Course?> GetCourseByIdOrDefaultAsync(int id, CancellationToken cancellationToken = default);
    Task<Course> CreateCourseAsync(Course course, CancellationToken cancellationToken = default);
    Task<Course?> UpdateCourseOrDefaultAsync(Course course, CancellationToken cancellationToken = default);
    Task<bool> DeleteCourseAsync(int id, CancellationToken cancellationToken = default);
}
