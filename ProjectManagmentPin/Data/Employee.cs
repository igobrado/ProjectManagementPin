using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagmentPin.Data
{
    public class Employee
    {      

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public ICollection<Project> AssignedProjects { get; set; }
        //public virtual ICollection<Project> AssignedProjects { get; set; }
        //public virtual ICollection<ProjectTask> Tasks { get; set; }
    }
}
