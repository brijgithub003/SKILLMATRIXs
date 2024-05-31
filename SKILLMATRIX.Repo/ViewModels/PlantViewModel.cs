using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKILLMATRIX.Repo.ViewModels
{
    public class PlantViewModel
    {

        [DisplayName("Plant ID")]
        public int Plant_Id { get; set; }

        [DisplayName("Plant Name")]
        public string Plant_Name { get; set; }
        
        [DisplayName("Plant Code")]
        public string Plant_Code { get; set; }

        [DisplayName("Create Date")]
        public DateTime CreateDate { get; set; }
       
        [DisplayName("Active")]
        public bool IsActive { get; set; }
    }

   
}
