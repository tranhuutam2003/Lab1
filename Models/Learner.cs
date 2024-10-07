namespace Lab1.Models
{
    public class Learner
    {
#pragma warning disable CS8618 
        public Learner()
#pragma warning restore CS8618  
        {
            Enrollments = new HashSet<Enrollment>();
        }
        public int LearnerId { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int MajorID {  get; set; }
        public virtual Major? Major { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
