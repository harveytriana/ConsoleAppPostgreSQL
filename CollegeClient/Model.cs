using Newtonsoft.Json;
using System;
using System.Collections.Generic;
// it must be a Standard library
// keep here by example
//
namespace CollegeClient
{
    public partial class Student
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("identifier")]
        public string Identifier { get; set; }
        [JsonProperty("gender")]
        public string Gender { get; set; }
        [JsonProperty("birthday")]
        public DateTime Birthdate { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} | {Identifier}";
        }
    }

    public partial class AcademicCourse
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("credits")]
        public int Credits { get; set; }
        [JsonProperty("state")]
        public bool State { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Credits})";
        }
    }

    public partial class Enrollment
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("enrollment_date")]
        public DateTime EnrollmentDate { get; set; }
        [JsonProperty("academic_course_id")]
        public int AcademicCourseId { get; set; }
        [JsonProperty("student_id")]
        public int SudentId { get; set; }

        public override string ToString()
        {
            return $"AcademicCourseId: {AcademicCourseId} | SudentId: {SudentId}";
        }
    }

    public partial class Book
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("isbn")]
        public string ISBN { get; set; }
        [JsonProperty("author")]
        public string Author { get; set; }
        [JsonProperty("image_link")]
        public string ImageLink { get; set; }
        [JsonProperty("language")]
        public string Language { get; set; }
        [JsonProperty("link")]
        public string Link { get; set; }
        [JsonProperty("pages")]
        public int Pages { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("year")]
        public int Year { get; set; }

        public override string ToString() => $"{Title}, {Author}";
    }
    
}
