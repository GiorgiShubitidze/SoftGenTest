using System;
using System.Collections.Generic;

namespace SoftGenTest.Repository.Models;

public partial class StudentsTb
{
    public int StudentId { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Pin { get; set; }

    public DateTime? BirthdayDate { get; set; }

    public string? Mail { get; set; }

    public virtual ICollection<StudentTbGroupTb> StudentTbGroupTbs { get; } = new List<StudentTbGroupTb>();
}
