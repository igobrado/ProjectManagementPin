using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagmentPin.Data
{
    public class EmployeeProject
    {     
        public int EmployeeId { get; set; }      
        
        public int ProjectId { get; set; }       

        public Employee Employee { get; private set; }
        public Project  Project { get; private set; }
    }
}
