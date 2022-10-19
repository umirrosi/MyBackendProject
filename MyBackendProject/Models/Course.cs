﻿using System.ComponentModel.DataAnnotations.Schema;

namespace MyBackendProject.Models
{
    public class Course
    {
        internal object students;

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }

    }
}
