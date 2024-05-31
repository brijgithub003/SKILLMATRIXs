using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKILLMATRIX.Entity
{
    public class Tb_Login
    {
        public int Login_Id { get; set; }
        public string User_Name { get; set; }
        public string Passwords { get; set; }
        public string User_Type { get; set; }
        public int Employee_Id { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
    }
}
