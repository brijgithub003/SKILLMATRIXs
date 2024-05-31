using SKILLMATRIX.Repo.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKILLMATRIX.Repo.Interfaces
{
    public interface IPlantRepo
    {
        Task<DataTable> GetAll();
        DataTable GetById(int id);
        string Save(PlantViewModel vm);
        string Update(PlantViewModel vm);
        string Delete(int id);
        DataTable GetDataTable();
    }
}
