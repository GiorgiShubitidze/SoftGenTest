using System;
using System.Collections.Generic;

namespace SoftGenTest.Repository.Models;

public partial class StudentTbGroupTb
{
    public int? StudentId { get; set; }

    public int? GroupId { get; set; }

    public int Id { get; set; }

    public virtual GroupsTb? Group { get; set; }

    public virtual StudentsTb? Student { get; set; }
}
