using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKILLMATRIX.Repo.ViewModels
{
    public class LoginViewModel
    {

        [DisplayName("Login ID")]
        public int Login_Id { get; set; }
       
        [DisplayName("User Name")]
        public string User_Name { get; set; }

        [DisplayName("Password")]
        public string Passwords { get; set; }

        [DisplayName("User Type")]
        public string User_Type { get; set; }

        [DisplayName("Employee ID")]
        public int Employee_Id { get; set; }

        [DisplayName("Create Date")]
        public DateTime CreateDate { get; set; }
       
        [DisplayName("Active")]
        public bool IsActive { get; set; }
    }
}
