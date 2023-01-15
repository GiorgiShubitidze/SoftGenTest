using System;
using System.Collections.Generic;

namespace SoftGenTest.Repository.Models;

public partial class TeacherTbGroupTb
{
    public int? TeacherId { get; set; }

    public int? GroupId { get; set; }

    public int Id { get; set; }

    public virtual GroupsTb? Group { get; set; }

    public virtual TeachersTb? Teacher { get; set; }
}
