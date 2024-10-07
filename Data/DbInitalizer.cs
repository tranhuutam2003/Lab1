using Lab1.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab1.Data
{
    public class DbInitalizer
    {
        public static void Initalizer(IServiceProvider serviceProvider)
        {
            using(var context = new SchoolContext(serviceProvider
                .GetRequiredService<DbContextOptions<SchoolContext>>()))
            {
                context.Database.EnsureCreated();
                if (context.Majors.Any())
                {
                    return;
                }
                var majors = new Major[]
                {
                    new Major{ MajorName = "IT" },
                    new Major{ MajorName = "Economics" },
                    new Major{ MajorName = "Mathematics" }
                };
                foreach (var major in majors)
                {
                    context.Majors.Add(major);
                }
                context.SaveChanges();

                var learners = new Learner[] {
                    new Learner
                    {
                        FirstMidName = "Minamoto",
                        LastName = "Yasuo",
                        EnrollmentDate = DateTime.Parse("2002-01-01"),
                        MajorID = 19
                    },
                    new Learner
                    {
                        FirstMidName = "Minamoto",
                        LastName = "Yone",
                        EnrollmentDate = DateTime.Parse("2001-01-01"),
                        MajorID = 20
                    }
                };
                foreach (Learner l in learners)
                {
                    context.Learners.Add(l);
                }
                context.SaveChanges();

                var courses = new Course[] {
                    new Course { CourseId = 1000, Title = "Chemistry", Credits = 3 },
                    new Course { CourseId = 2000, Title = "Microeconomics", Credits = 3 },
                    new Course { CourseId = 3000, Title = "Macroeconomics", Credits = 3 }
                };
                foreach (Course c in courses)
                {
                    context.Courses.Add(c);
                }
                context.SaveChanges();

                var enrollments = new Enrollment[] {
                    new Enrollment { LearnerID = 1, CourseID = 1000, Grade = 5.5f },
                    new Enrollment { LearnerID = 1, CourseID = 2000, Grade = 7.5f },
                    new Enrollment { LearnerID = 2, CourseID = 1000, Grade = 3.5f },
                    new Enrollment { LearnerID = 2, CourseID = 3000, Grade = 7f }
                };
                foreach (Enrollment e in enrollments)
                {
                    context.Enrollments.Add(e);
                }
                context.SaveChanges();
            }
        }
    }
}
