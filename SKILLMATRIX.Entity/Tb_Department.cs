using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKILLMATRIX.Entity
{
    public class Tb_Department
    {
        public int Department_Id { get; set; }
        public string Department_Name { get; set; }

        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
    }
}
