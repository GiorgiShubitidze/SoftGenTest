using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SoftGenTest.Repository;
using SoftGenTest.Repository.Models;
using SoftgenTest1.Repository.Service;

namespace SoftGenTest.Controllers
{
    public class GroupsTbsController : Controller
    {

        IBrowsingAppService _browsingAppService;
        public GroupsTbsController(IBrowsingAppService browsingAppService)
        {
            _browsingAppService = browsingAppService;
        }

        [HttpGet]
        public IActionResult Index(int groupId)
        {
            return View(_browsingAppService.GetGroupData(groupId));
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GroupsTb groupsTb)
        {
            var add = _browsingAppService.AddGroup(groupsTb);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            var groupsTb = _browsingAppService.EditGroupCheck(id);

            if (groupsTb == null)
            {
                return NotFound();
            }
            return View(groupsTb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, GroupsTb groupsTb)
        {
            if (id != groupsTb.GroupId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var edit = _browsingAppService.EditGroup(id, groupsTb);

                return RedirectToAction(nameof(Index));
            }
            return View(groupsTb);
        }

        public IActionResult Delete(int? id)
        {
            var groupsId = _browsingAppService.CheackGroupId(id);

            if (groupsId == null)
            {
                return NotFound();
            }

            return View(groupsId);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var delete = _browsingAppService.DeleteGroup(id);

            if (delete == true)
            {
                return RedirectToAction(nameof(Index));
            }
            else return NotFound();

        }

        public IActionResult GroupMembers()
        {
            var studentDbContext = _browsingAppService.GetStudentsFromGroup();

            return View(studentDbContext.ToList());

        }

        public IActionResult AddNewStudent()
        {
            ViewData["GroupId"] = _browsingAppService.GetGroups();
            ViewData["StudentId"] = _browsingAppService.GetStudents();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewStudent(StudentTbGroupTb studentTbGroupTb)
        {
            if (ModelState.IsValid)
            {
                if(_browsingAppService.AddNewStudenInGroup(studentTbGroupTb))
                return RedirectToAction(nameof(GroupMembers));
            }
            ViewData["GroupId"] = _browsingAppService.GetGroups();
            ViewData["StudentId"] = _browsingAppService.GetStudents();
            return View(studentTbGroupTb);
        }

        public IActionResult DeleteStudentFromGroup(int? id)
        {
            _browsingAppService.DeleteStudentFromGroup(id);
            return RedirectToAction(nameof(GroupMembers));
        }


        public IActionResult GroupsMemberTeacher()
        {
            var studentDbContext = _browsingAppService.GetTeachersFromGroup();
            return View(studentDbContext.ToList());
        }

        public IActionResult AddNewTeacherInGroup()
        {
            ViewData["GroupId"] = _browsingAppService.GetGroups();
            ViewData["TeacherId"] = _browsingAppService.GetTeachers();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewTeacherInGroup(TeacherTbGroupTb teacherTbGroupTb)
        {
            if (ModelState.IsValid)
            {
                if(_browsingAppService.AddNewTeacherInGroup(teacherTbGroupTb))
                return RedirectToAction(nameof(GroupsMemberTeacher));
            }
            ViewData["GroupId"] = _browsingAppService.GetGroups();
            ViewData["TeacherId"] = _browsingAppService.GetTeachers();
            return View(teacherTbGroupTb);
        }

        public IActionResult DeleteTeacherFromGroup(int? id)
        {
            _browsingAppService.DeleteTeacherFromGroup(id);
            return RedirectToAction(nameof(GroupsMemberTeacher));
        }


    }
}
