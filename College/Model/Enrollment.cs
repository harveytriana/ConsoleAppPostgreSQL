using System;
using System.Collections.Generic;

namespace College
{
    public partial class Enrollment
    {
        public long Id { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public long AcademicCourseId { get; set; }
        public long SudentId { get; set; }

        public virtual Course AcademicCourse { get; set; }
        public virtual Student Sudent { get; set; }

        public override string ToString()
        {
            return $"AcademicCourseId: {AcademicCourseId} | SudentId: {SudentId}";
        }
    }
}
