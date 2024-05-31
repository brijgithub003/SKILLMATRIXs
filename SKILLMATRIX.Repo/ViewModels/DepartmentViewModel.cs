using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKILLMATRIX.Repo.ViewModels
{
    public class DepartmentViewModel
    {
        [DisplayName("Department Id")]
        public int Department_Id { get; set; }

        [DisplayName("Department Name")]
        public string Department_Name { get; set; }

        [DisplayName("Create Date")]
        public DateTime CreateDate { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }
    }
}
