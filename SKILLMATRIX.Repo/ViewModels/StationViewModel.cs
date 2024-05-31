using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKILLMATRIX.Repo.ViewModels
{
    public class StationViewModel
    {

        [DisplayName("Station ID")]
        public int Station_Id { get; set; }

        [DisplayName("Station Name")]
        public string Station_Name { get; set; }
       
        [DisplayName("Line Name")]
        public int Line_Id { get; set; }

        [DisplayName("Create Date")]
        public DateTime CreateDate { get; set; }
        
        [DisplayName("Active")]
        public bool IsActive { get; set; }
    }
}
