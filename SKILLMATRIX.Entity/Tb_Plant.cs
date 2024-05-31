using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKILLMATRIX.Entity
{
    public class Tb_Plant
    {
        public int Plant_Id { get; set; }
        public string Plant_Name { get; set; }
        public string Plant_Code { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
    }
}
