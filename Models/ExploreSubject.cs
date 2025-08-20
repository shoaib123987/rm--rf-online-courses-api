using System;
using System.Collections.Generic;

namespace Online_Courses.Models;

public partial class ExploreSubject
{
    public int EsId { get; set; }

    public string? CName { get; set; }

    public string? CImg { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
