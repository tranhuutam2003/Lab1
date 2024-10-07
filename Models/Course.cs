using System.ComponentModel.DataAnnotations.Schema;

namespace Lab1.Models
{
    public class Course
    {
        public Course()

        {
            Enrollments = new HashSet<Enrollment>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseId { get; set; }  
        public string Title { get; set; }
        public int Credits {  get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
