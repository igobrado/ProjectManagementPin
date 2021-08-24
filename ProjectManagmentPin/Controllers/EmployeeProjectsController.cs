using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectManagmentPin.Data;
using ProjectManagmentPin.Models;

namespace ProjectManagmentPin.Controllers
{
    public class EmployeeProjectsController : Controller
    {
        private readonly ProjectManagmentContext _context;

        public EmployeeProjectsController(ProjectManagmentContext context)
        {
            _context = context;
        }

        public IActionResult AssignEmployeesToProject()
        {
            var model = new EmployeesOnProjectsViewModel
            {
                Employees = _context.Employees.Select(e => e.MapToVm()).ToList(),
                Projects = _context.Projects.Select(p => p.MapToVm()).ToList(),
                EmployeesOnProject = new List<EmployeeProject>()
            };
            return View(model);
        }

        [HttpPost]
        public JsonResult Insert(int[] emp, int proj)
        {
            try
            {
                var employeesOnProject = new List<EmployeeProject>();
                foreach (var e in emp)
                {
                    employeesOnProject.Add(new EmployeeProject
                    {
                        EmployeeId = e,
                        ProjectId = proj

                    });
                }

                _context.EmployeeProjects.AddRange(employeesOnProject);
                _context.SaveChanges();
                return new JsonResult("ok");
            }
            catch (Exception e)
            {
                return new JsonResult("failed");
            }
        }

        // GET: EmployeeProjects
        public async Task<IActionResult> Index()
        {
            var projectManagmentContext = _context.EmployeeProjects.Include(e => e.Employee).Include(e => e.Project);
            return View(await projectManagmentContext.ToListAsync());
        }


        private bool EmployeeProjectExists(int id)
        {
            return _context.EmployeeProjects.Any(e => e.ProjectId == id);
        }
    }
}
