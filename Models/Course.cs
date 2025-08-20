using System;
using System.Collections.Generic;

namespace Online_Courses.Models;

public partial class Course
{
    public int Id { get; set; }

    public int? EsId { get; set; }

    public string? CourseImg { get; set; }

    public string? Duration { get; set; }

    public string? Price { get; set; }

    public string? Popular { get; set; }

    public string? Subjects { get; set; }

    public virtual ExploreSubject? Es { get; set; }
}
