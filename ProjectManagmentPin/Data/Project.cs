using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagmentPin.Data
{
    public class Project
    {       

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string ProjectName { get; set; }
        public DateTime ProjectStartDate { get; set; }
        public DateTime ProjectEndDate { get; set; }          
        
        public ICollection<Employee> EmployeeOnProject { get; set; }
        //public virtual ICollection<ProjectTask> ProjectTasks { get; set; }        
    }
}
