using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKILLMATRIX.Entity
{
    public class Tb_Employee
    {
        public int Employee_Id { get; set; }
        public string Employee_Code { get; set; }
        public int Employee_Department { get; set; }
        public string Employee_Name_F { get; set; }
        public string Employee_Name_M { get; set; }
        public string Employee_Name_L { get; set; }
        public string Employee_Address { get; set; }
        public string Employee_MobileNo { get; set; }
        public int Employee_Education { get; set; }
        public string Employee_type { get; set; }
        public int Skill_Id { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
    }
}
