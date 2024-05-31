using SKILLMATRIX.Repo.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKILLMATRIX.Repo.Interfaces
{
    public interface ILoginRepo
    {
        Task<DataTable> GetAll();
        Task<DataTable> GetById(int id);
        string Save(LoginViewModel vm);
        string Update(LoginViewModel vm);
        string Delete(int id);
        Task<DataTable> GetDataTable();
    }
}
