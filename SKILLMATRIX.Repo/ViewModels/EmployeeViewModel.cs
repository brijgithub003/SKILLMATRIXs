using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKILLMATRIX.Repo.ViewModels
{
    public class EmployeeViewModel
    {

        [DisplayName("Employee ID")]
        public int Employee_Id { get; set; }
       
        [DisplayName("Employee Code")]
        public string Employee_Code { get; set; }
        
        [DisplayName("Employee Department")]
        public string Employee_Department { get; set; }

        [DisplayName("First Name")]
        public string Employee_Name_F { get; set; }
       
        [DisplayName("Middle Name")]
        public string Employee_Name_M { get; set; }
       
        [DisplayName("Last Name")]
        public string Employee_Name_L { get; set; }
        
        [DisplayName("Address")]
        public string Employee_Address { get; set; }
        
        [DisplayName("Mobile No")]
        public string Employee_MobileNo { get; set; }
        
        [DisplayName("Education")]
        public string Employee_Education { get; set; }
        
        [DisplayName("Employee Type")]
        public string Employee_type { get; set; }

        [DisplayName("Skill ID")]
        public int Skill_Id { get; set; }

        [DisplayName("Create Date")]
        public DateTime CreateDate { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }
    }
}
