using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SoftGenTest.Repository;
using SoftGenTest.Repository.Models;
using SoftgenTest1.Repository.Service;

namespace SoftGenTest.Controllers
{
    public class StudentsTbsController : Controller
    {

        IBrowsingAppService _browsingAppService;
        public StudentsTbsController(IBrowsingAppService browsingAppService)
        {
            _browsingAppService = browsingAppService;
        }

        public IActionResult Index(string name, string surname, DateTime? birthdayDate, string pin)
        {
            return View(_browsingAppService.GetFilterStudents(name, surname, birthdayDate, pin));
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudentsTb studentsTb)
        {
            if (ModelState.IsValid)
            {
                _browsingAppService.CreateStudent(studentsTb);
                return RedirectToAction(nameof(Index));
            }
            return View(studentsTb);
        }

        public IActionResult Edit(int? id)
        {
            return View(_browsingAppService.EditStudentCheck(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, StudentsTb studentsTb)
        {
            if (id != studentsTb.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (_browsingAppService.EditStudent(studentsTb))
                    return RedirectToAction(nameof(Index));
                else return NotFound();
            }
            return View(studentsTb);
        }

        public IActionResult Delete(int id)
        {
            if (_browsingAppService.DeleteStudent(id))
                return RedirectToAction(nameof(Index));
            else return NotFound();
        }


    }
}
