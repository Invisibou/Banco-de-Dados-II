using System;
using System.Collections.Generic;

namespace Scaffold.Models;

public partial class Course
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
}
