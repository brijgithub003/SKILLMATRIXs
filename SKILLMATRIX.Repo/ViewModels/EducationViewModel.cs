using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKILLMATRIX.Repo.ViewModels
{
    public class EducationViewModel
    {

        [DisplayName("Education Id")]
        public int Education_Id { get; set; }
        
        [DisplayName("Education Name")]
        public string Education_Name { get; set; }

        [DisplayName("Create Date")]
        public DateTime CreateDate { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }
    }
}
