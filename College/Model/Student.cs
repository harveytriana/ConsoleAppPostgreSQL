using System;
using System.Collections.Generic;

namespace College
{
    public partial class Student
    {
        public Student()
        {
            CollegeEnrollment = new HashSet<Enrollment>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Identifier { get; set; }
        public string Gender { get; set; }
        // Fix issue, 
        // public byte[] Birthdate { get; set; }
        public DateTime Birthdate { get; set; }

        public virtual ICollection<Enrollment> CollegeEnrollment { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} | {Identifier}";
        }
    }
}
