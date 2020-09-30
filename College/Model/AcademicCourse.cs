using System;
using System.Collections.Generic;

namespace College
{
    public partial class AcademicCourse
    {
        public AcademicCourse()
        {
            CollegeEnrollment = new HashSet<Enrollment>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long Credits { get; set; }
        public byte[] State { get; set; }

        public virtual ICollection<Enrollment> CollegeEnrollment { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Credits})";
        }
    }
}
