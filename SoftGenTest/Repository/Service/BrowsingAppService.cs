using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SoftGenTest.Repository.Models;
using SoftGenTest.Repository;
using SoftgenTest1.Repository.Service;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SoftgenTest1.Repository.Servie
{
    public class BrowsingAppService : IBrowsingAppService
    {
        StudentDbContext studentDbContext;

        public BrowsingAppService(StudentDbContext studentDbContext)
        {
            this.studentDbContext = studentDbContext;
        }

        public GroupsTb AddGroup(GroupsTb group)
        {
            studentDbContext.Add(group);
            studentDbContext.SaveChanges();

            return group;
        }

        public GroupsTb CheackGroupId(int? id)
        {
            if (id == null || studentDbContext.GroupsTbs == null)
            {
                return null;
            }

            var groupsTb = studentDbContext.GroupsTbs
                .FirstOrDefault(m => m.GroupId == id);

            return groupsTb;
        }

        public bool DeleteGroup(int id)
        {
            try
            {
                var groupsTb = studentDbContext.GroupsTbs.Find(id);
                if (groupsTb != null)
                {
                    studentDbContext.GroupsTbs.Remove(groupsTb);
                }

                studentDbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public GroupsTb EditGroup(int id, GroupsTb groupsTb)
        {
            if (id != groupsTb.GroupId)
            {
                return null;
            }
            try
            {
                studentDbContext.Update(groupsTb);
                studentDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;

            }
            return groupsTb;

        }



        public GroupsTb EditGroupCheck(int? groupId)
        {
            if (groupId == 0 || studentDbContext.GroupsTbs == null)
            {
                return null;
            }

            var groupsTb = studentDbContext.GroupsTbs.Find(groupId);
            if (groupsTb == null)
            {
                return null;
            }

            return groupsTb;
        }

        public SelectList GetGroups()
        {
            var groups = new SelectList(studentDbContext.GroupsTbs, "GroupId", "GroupName");

            return groups;
        }

        public SelectList GetStudents()
        {
            var students = new SelectList(studentDbContext.StudentsTbs, "StudentId", "Name");
            return students;
        }

        public SelectList GetTeachers()
        {
            var students = new SelectList(studentDbContext.TeachersTbs, "TeacherId", "Name");
            return students;
        }


        public List<GroupsTb> GetGroupData(int groupId)
        {
            if (groupId != 0)
            {
                var x = studentDbContext.GroupsTbs.Where(i => i.GroupNumber == groupId).ToList();
                return x;

            }
            return studentDbContext.GroupsTbs.ToList();
        }

        public IIncludableQueryable<StudentTbGroupTb, StudentsTb> GetStudentsFromGroup()
        {
            var studentDbContext1 = studentDbContext.StudentTbGroupTbs.Include(s => s.Group).Include(s => s.Student);

            return studentDbContext1;

        }

        public bool AddNewStudenInGroup(StudentTbGroupTb student)
        {
            try
            {
                studentDbContext.Add(student);
                studentDbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteStudentFromGroup(int? id)
        {
            try
            {
                var studentTbGroupTb = studentDbContext.StudentTbGroupTbs.Find(id);
                if (studentTbGroupTb != null)
                {
                    studentDbContext.StudentTbGroupTbs.Remove(studentTbGroupTb);
                }

                studentDbContext.SaveChanges();

                return true;

            }
            catch (Exception)
            {

                throw;
            }

        }
        public bool DeleteTeacherFromGroup(int? id)
        {
            try
            {
                var teacherTbGroupTbs = studentDbContext.TeacherTbGroupTbs.Find(id);
                if (teacherTbGroupTbs != null)
                {
                    studentDbContext.TeacherTbGroupTbs.Remove(teacherTbGroupTbs);
                }

                studentDbContext.SaveChanges();

                return true;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool AddNewTeacherInGroup(TeacherTbGroupTb teacher)
        {
            try
            {
                studentDbContext.Add(teacher);
                studentDbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IIncludableQueryable<TeacherTbGroupTb, TeachersTb> GetTeachersFromGroup()
        {
            var teacherInGroup = studentDbContext.TeacherTbGroupTbs.Include(t => t.Group).Include(t => t.Teacher);

            return teacherInGroup;

        }

        public void CreateStudent(StudentsTb student)
        {
            studentDbContext.Add(student);
            studentDbContext.SaveChanges();
        }

        public StudentsTb EditStudentCheck(int? id)
        {

            var studentsTb = studentDbContext.StudentsTbs.Find(id);
            if (studentsTb == null)
            {
                return null;
            }
            return studentsTb;
        }

        public bool EditStudent(StudentsTb student)
        {
            try
            {
                studentDbContext.Update(student);
                studentDbContext.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentsTbExists(student.StudentId))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }
        private bool StudentsTbExists(int id)
        {
            return studentDbContext.StudentsTbs.Any(e => e.StudentId == id);
        }

        public bool DeleteStudent(int? id)
        {
            try
            {
                var studentsTb = studentDbContext.StudentsTbs.Find(id);
                if (studentsTb != null)
                {
                    studentDbContext.StudentsTbs.Remove(studentsTb);
                }

                studentDbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void CreateTeacher(TeachersTb teachers)
        {
            studentDbContext.Add(teachers);
            studentDbContext.SaveChanges();
        }

        public bool DeleteTeacher(int? id)
        {
            try
            {
                var teachersTb = studentDbContext.TeachersTbs.Find(id);
                if (teachersTb != null)
                {
                    studentDbContext.TeachersTbs.Remove(teachersTb);
                }
                studentDbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TeachersTb EditTeacherCheck(int? id)
        {
            var teachersTb = studentDbContext.TeachersTbs.Find(id);
            return teachersTb;
        }

        public bool EditTeacher(TeachersTb teacher)
        {
            try
            {
                studentDbContext.Update(teacher);
                studentDbContext.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }
    }
}
