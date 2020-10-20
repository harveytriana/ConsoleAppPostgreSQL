using System;
using System.Collections.Generic;

namespace College
{
    public partial class Course
    {
        public Course()
        {
            CollegeEnrollment = new HashSet<Enrollment>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long Credits { get; set; }
        public bool State { get; set; }

        public virtual ICollection<Enrollment> CollegeEnrollment { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Credits})";
        }
    }
}
