using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKILLMATRIX.Repo.ViewModels
{
    public class LineViewModel
    {

        [DisplayName("Line ID")]
        public int Line_Id { get; set; }

        [DisplayName("Line Name")]
        public string Line_Name { get; set; }

        [DisplayName("Line No")]
        public int Line_NO { get; set; }

        [DisplayName("Create Date")]
        public DateTime CreateDate { get; set; }
        
        [DisplayName("Active")]

        public bool IsActive { get; set; }
    }
}
