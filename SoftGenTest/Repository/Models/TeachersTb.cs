using System;
using System.Collections.Generic;

namespace SoftGenTest.Repository.Models;

public partial class TeachersTb
{
    public int TeacherId { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public long? Pin { get; set; }

    public string? Mail { get; set; }

    public DateTime? BirthdayDate { get; set; }

    public virtual ICollection<TeacherTbGroupTb> TeacherTbGroupTbs { get; } = new List<TeacherTbGroupTb>();
}
