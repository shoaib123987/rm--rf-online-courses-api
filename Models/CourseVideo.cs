using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Online_Courses.Models;

public partial class CourseVideo
{
    public int CvId { get; set; }

    public int Id { get; set; }

    public string? VideoPath { get; set; }

    public string Heading { get; set; } = null!;

    public string Title { get; set; } = null!;


    [JsonIgnore]
    public virtual Course? IdNavigation { get; set; } = null!;
}
