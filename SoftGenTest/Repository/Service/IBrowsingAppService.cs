using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Query;
using SoftGenTest.Repository.Models;

namespace SoftgenTest1.Repository.Service
{
    public interface IBrowsingAppService
    {
        public List<GroupsTb> GetGroupData(int groupId = 0);
        public GroupsTb AddGroup(GroupsTb group);
        public GroupsTb EditGroupCheck(int? groupId);
        public GroupsTb EditGroup(int id, GroupsTb groupsTb);
        public GroupsTb CheackGroupId(int? id);
        public bool DeleteGroup(int id);
        public IIncludableQueryable<StudentTbGroupTb, StudentsTb> GetStudentsFromGroup();
        public SelectList GetGroups();
        public SelectList GetStudents();
        public SelectList GetTeachers();
        public bool AddNewStudenInGroup(StudentTbGroupTb student);
        public bool DeleteStudentFromGroup(int? id);
        public bool DeleteTeacherFromGroup(int? id);
        public bool AddNewTeacherInGroup(TeacherTbGroupTb teacher);
        public IIncludableQueryable<TeacherTbGroupTb, TeachersTb> GetTeachersFromGroup();

        #region Stundet
        public void CreateStudent(StudentsTb student);
        public StudentsTb EditStudentCheck(int? id);
        public bool EditStudent(StudentsTb student);
        public bool DeleteStudent(int? id);
        public List<StudentsTb> GetFilterStudents(string name, string surname, DateTime? birthdayDate, string pin);
        #endregion

        #region Teacher
        public void CreateTeacher(TeachersTb teachers);
        public bool DeleteTeacher(int? id);
        public TeachersTb EditTeacherCheck(int? id);
        public bool EditTeacher(TeachersTb teacher);
        public List<TeachersTb> GetFilterTeachers(string name, string surname, DateTime? birthdayDate, string pin);
        #endregion

        




    }
}
