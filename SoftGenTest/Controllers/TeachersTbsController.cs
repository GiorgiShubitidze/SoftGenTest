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
    public class TeachersTbsController : Controller
    {
        private readonly StudentDbContext _context;
        IBrowsingAppService _browsingAppService;
        public TeachersTbsController(IBrowsingAppService browsingAppService, StudentDbContext context)
        {
            _browsingAppService = browsingAppService;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.TeachersTbs.ToListAsync());
        }



        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TeachersTb teachersTb)
        {
            if (ModelState.IsValid)
            {
                _browsingAppService.CreateTeacher(teachersTb);
                return RedirectToAction("Index");
            }
            return View(teachersTb);
        }

        public IActionResult Delete(int id)
        {
            if (_browsingAppService.DeleteTeacher(id))
                return RedirectToAction(nameof(Index));
            else return NotFound();
        }
        public IActionResult Edit(int? id)
        {

            var teachersTb = _browsingAppService.EditTeacherCheck(id);
            if (teachersTb == null)
            {
                return NotFound();
            }
            return View(teachersTb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, TeachersTb teachersTb)
        {
            if (ModelState.IsValid)
            {
                if(_browsingAppService.EditTeacher(teachersTb))
                return RedirectToAction(nameof(Index));
            }
            return View(teachersTb);
        }

    }
}
