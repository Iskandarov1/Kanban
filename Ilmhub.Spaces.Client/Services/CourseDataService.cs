using Ilmhub.Spaces.Client.Models;

namespace Ilmhub.Spaces.Client.Services;

public class CourseDataService : ICourseDataService
{
    private static readonly List<Course> SampleCourses = new()
    {
        new Course { Id = 1, Name = "Introduction to Programming", Category = CourseCategory.IT, Level = CourseLevel.Foundation, Duration = TimeSpan.FromHours(40), SessionsPerWeek = 2, Description = "Learn the basics of programming" },
        new Course { Id = 2, Name = "Advanced Web Development", Category = CourseCategory.IT, Level = CourseLevel.Advanced, Duration = TimeSpan.FromHours(60), SessionsPerWeek = 3, Description = "Master modern web technologies" },
        new Course { Id = 3, Name = "Data Science Fundamentals", Category = CourseCategory.IT, Level = CourseLevel.Foundation, Duration = TimeSpan.FromHours(50), SessionsPerWeek = 2, Description = "Introduction to data analysis and visualization" },
        new Course { Id = 4, Name = "Mobile App Development", Category = CourseCategory.IT, Level = CourseLevel.Advanced, Duration = TimeSpan.FromHours(45), SessionsPerWeek = 2, Description = "Create apps for iOS and Android" },
        new Course { Id = 5, Name = "Cybersecurity Essentials", Category = CourseCategory.IT, Level = CourseLevel.Foundation, Duration = TimeSpan.FromHours(30), SessionsPerWeek = 2, Description = "Learn about online security and protection" },
        new Course { Id = 6, Name = "Cloud Computing", Category = CourseCategory.IT, Level = CourseLevel.Advanced, Duration = TimeSpan.FromHours(55), SessionsPerWeek = 3, Description = "Explore cloud platforms and services" },
        new Course { Id = 7, Name = "Artificial Intelligence", Category = CourseCategory.IT, Level = CourseLevel.Advanced, Duration = TimeSpan.FromHours(70), SessionsPerWeek = 3, Description = "Dive into AI algorithms and applications" },
        new Course { Id = 8, Name = "Database Management", Category = CourseCategory.IT, Level = CourseLevel.Foundation, Duration = TimeSpan.FromHours(35), SessionsPerWeek = 2, Description = "Learn SQL and database design" },
        new Course { Id = 9, Name = "Network Administration", Category = CourseCategory.IT, Level = CourseLevel.Advanced, Duration = TimeSpan.FromHours(40), SessionsPerWeek = 2, Description = "Manage and troubleshoot computer networks" },
        new Course { Id = 10, Name = "DevOps Practices", Category = CourseCategory.IT, Level = CourseLevel.Advanced, Duration = TimeSpan.FromHours(50), SessionsPerWeek = 2, Description = "Learn about continuous integration and deployment" },
        new Course { Id = 11, Name = "English for Beginners", Category = CourseCategory.English, Level = CourseLevel.Foundation, Duration = TimeSpan.FromHours(30), SessionsPerWeek = 2, Description = "Start your English language journey" },
        new Course { Id = 12, Name = "Business English", Category = CourseCategory.English, Level = CourseLevel.Advanced, Duration = TimeSpan.FromHours(25), SessionsPerWeek = 2, Description = "English for professional environments" },
        new Course { Id = 13, Name = "English Conversation", Category = CourseCategory.English, Level = CourseLevel.Foundation, Duration = TimeSpan.FromHours(45), SessionsPerWeek = 3, Description = "Improve your spoken English" },
        new Course { Id = 14, Name = "English for Kids", Category = CourseCategory.English, Level = CourseLevel.Kids, Duration = TimeSpan.FromHours(35), SessionsPerWeek = 2, Description = "Fun English lessons for children" },
        new Course { Id = 15, Name = "IELTS Preparation", Category = CourseCategory.English, Level = CourseLevel.Advanced, Duration = TimeSpan.FromHours(65), SessionsPerWeek = 3, Description = "Get ready for the IELTS exam" }
    };

    public Task<List<Course>> GetAllCoursesAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult(SampleCourses);
    }

    public Task<Course?> GetCourseByIdOrDefaultAsync(int id, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(SampleCourses.FirstOrDefault(c => c.Id == id));
    }

    public Task<Course> CreateCourseAsync(Course course, CancellationToken cancellationToken = default)
    {
        course.Id = SampleCourses.Max(c => c.Id) + 1;
        SampleCourses.Add(course);
        return Task.FromResult(course);
    }

    public Task<Course?> UpdateCourseOrDefaultAsync(Course course, CancellationToken cancellationToken = default)
    {
        var existingCourse = SampleCourses.FirstOrDefault(c => c.Id == course.Id);
        if (existingCourse != null)
        {
            existingCourse.Name = course.Name;
            existingCourse.Category = course.Category;
            existingCourse.Level = course.Level;
            existingCourse.Duration = course.Duration;
        }
        return Task.FromResult(existingCourse);
    }

    public Task<bool> DeleteCourseAsync(int id, CancellationToken cancellationToken = default)
    {
        var course = SampleCourses.FirstOrDefault(c => c.Id == id);
        if (course != null)
        {
            SampleCourses.Remove(course);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }
}