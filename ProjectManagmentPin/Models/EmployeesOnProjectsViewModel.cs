using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManagmentPin.Data;

namespace ProjectManagmentPin.Models
{

    public static class ViewModelHelpers
    {
        public static EmployeeViewModel MapToVm(this Employee e)
        {
            return new EmployeeViewModel
            {
                EmployeeId = e.Id,
                FirstAndLastName = e.FirstName + " " + e.LastName
            };
        }

        public static ProjectViewModel MapToVm(this Project p)
        {
            return new ProjectViewModel
            {
                ProjectId = p.Id,
                ProjectName = p.ProjectName
            };
        }
    }


    public class EmployeesOnProjectsViewModel
    {
        public List<EmployeeViewModel> Employees { get; set; }
        public List<ProjectViewModel> Projects { get; set; }
        public List<EmployeeProject>  EmployeesOnProject {get; set; }
    }

    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
        public string FirstAndLastName { get; set; }
    }

    public class ProjectViewModel
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
    }



}
