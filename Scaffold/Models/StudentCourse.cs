using System;
using System.Collections.Generic;

namespace Scaffold.Models;

public partial class StudentCourse
{
    public int StudentId { get; set; }

    public int CourseId { get; set; }

    public DateTime? CancelData { get; set; }

    public DateTime SignDate { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
