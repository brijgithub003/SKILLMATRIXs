using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_Oracle
{
	public class Tb_Line
	{
        public int Line_Id { get; set; }
        public string Line_Name { get; set; }
        public string Line_Number { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
