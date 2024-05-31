using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKILLMATRIX.Entity
{
    public class Tb_Station
    {
        public int Station_Id { get; set; }
        public string Station_Name { get; set; }
        public int Line_Id { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
    }
}
