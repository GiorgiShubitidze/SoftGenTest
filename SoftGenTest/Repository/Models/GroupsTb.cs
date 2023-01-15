using System;
using System.Collections.Generic;

namespace SoftGenTest.Repository.Models;

public partial class GroupsTb
{
    public int GroupId { get; set; }

    public string? GroupName { get; set; }

    public int? GroupNumber { get; set; }

    public virtual ICollection<StudentTbGroupTb> StudentTbGroupTbs { get; } = new List<StudentTbGroupTb>();

    public virtual ICollection<TeacherTbGroupTb> TeacherTbGroupTbs { get; } = new List<TeacherTbGroupTb>();
}
