using SKILLMATRIX.Repo.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKILLMATRIX.Repo.Interfaces
{
    public interface IStationRepo
    {
        Task<DataTable> GetAll();
        DataTable GetById(int id);
        string Save(StationViewModel vm);
        string Update(StationViewModel vm);
        string Delete(int id);
        DataTable GetDataTable();
    }
}
