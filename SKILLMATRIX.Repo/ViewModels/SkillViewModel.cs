using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKILLMATRIX.Repo.ViewModels
{
    public class SkillViewModel
    {

        [DisplayName("Skill ID")]
        public int Skill_Id { get; set; }

        [DisplayName("Skill Name")]
        public string Skill_Name { get; set; }

        [DisplayName("Create Date")]
        public DateTime CreateDate { get; set; }
       
        [DisplayName("Active")]
        public bool IsActive { get; set; }
    }
}
