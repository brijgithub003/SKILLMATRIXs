using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using SKILLMATRIX.Repo.Interfaces;
using SKILLMATRIX.Repo.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKILLMATRIX.Repo.Implementations
{
    public class LoginRepo : ILoginRepo
    {
        private readonly ApplicationDbContext _context;

        public LoginRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public string Delete(int id)
        {
            string res = "";
            try
            {
                _context.Database.OpenConnection();
                DbCommand cmd = _context.Database.GetDbConnection().CreateCommand();
                cmd.CommandText = "";   //Use Proc Name
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new OracleParameter() { ParameterName = "ID", OracleDbType = OracleDbType.Varchar2, Value = id });
                cmd.Parameters.Add(new OracleParameter() { ParameterName = "ACTION", OracleDbType = OracleDbType.Varchar2, Value = "D" });
                cmd.Parameters.Add(new OracleParameter() { ParameterName = "RES", OracleDbType = OracleDbType.Varchar2, Size = 4000, Direction = ParameterDirection.Output });
                cmd.Parameters.Add(new OracleParameter() { ParameterName = "REF_RESULT", OracleDbType = OracleDbType.RefCursor, Direction = ParameterDirection.Output });
                cmd.ExecuteNonQuery();
                res = cmd.Parameters["RES"].Value.ToString();
            }
            catch (Exception)
            {
                throw;
            }
            return res;
        }

        public async Task<DataTable> GetAll()
        {
            DataTable dt = new DataTable();
            try
            {
                _context.Database.OpenConnection();
                DbCommand cmd = _context.Database.GetDbConnection().CreateCommand();
                cmd.CommandText = "";  //Use proc noame 
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add(new OracleParameter() { ParameterName = "",OracleDbType = OracleDbType.Varchar2});
                DbDataAdapter dataAdapter = DbProviderFactories.GetFactory(_context.Database.GetDbConnection()).CreateDataAdapter();
                dataAdapter.SelectCommand = cmd;
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);
                dt = ds.Tables[0];
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return dt;
        }

        public async Task<DataTable> GetById(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                _context.Database.OpenConnection();
                DbCommand cmd = _context.Database.GetDbConnection().CreateCommand();
                cmd.CommandText = "";  //Use proc noame 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter() { ParameterName = "ID", OracleDbType = OracleDbType.Double, Value = id });
                DbDataAdapter dataAdapter = DbProviderFactories.GetFactory(_context.Database.GetDbConnection()).CreateDataAdapter();
                dataAdapter.SelectCommand = cmd;
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);
                dt = ds.Tables[0];
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return dt;
        }

        public async Task<DataTable> GetDataTable()
        {
            DataTable dt = new DataTable();
            try
            {
                _context.Database.OpenConnection();
                DbCommand cmd = _context.Database.GetDbConnection().CreateCommand();
                cmd.CommandText = "";  //Use proc noame 
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add(new SqlParameter() { ParameterName = "",SqlDbType = SqlDbType.VarChar});
                DbDataAdapter dataAdapter = DbProviderFactories.GetFactory(_context.Database.GetDbConnection()).CreateDataAdapter();
                dataAdapter.SelectCommand = cmd;
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);
                dt = ds.Tables[0];
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return dt;
        }

        public string Save(LoginViewModel vm)
        {
            string res = "";
            try
            {
                _context.Database.OpenConnection();
                DbCommand cmd = _context.Database.GetDbConnection().CreateCommand();
                cmd.CommandText = "";   //Use proc name
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.Add(new OracleParameter() { ParameterName = "Station_Name", OracleDbType = OracleDbType.Double });
                //cmd.Parameters.Add(new OracleParameter() { ParameterName = "Line_Id", OracleDbType = OracleDbType.Double, Value = vm.Line_Id });
                //cmd.Parameters.Add(new OracleParameter() { ParameterName = "CreateDate", OracleDbType = OracleDbType.Varchar2, Value = vm.CreateDate });

                cmd.Parameters.Add(new OracleParameter() { ParameterName = "ACTION", OracleDbType = OracleDbType.Varchar2, Value = "I" });
                cmd.Parameters.Add(new OracleParameter() { ParameterName = "RES", OracleDbType = OracleDbType.Varchar2, Size = 4000, Direction = ParameterDirection.Output });
                cmd.Parameters.Add(new OracleParameter() { ParameterName = "REF_RESULT", OracleDbType = OracleDbType.RefCursor, Direction = ParameterDirection.Output });
                cmd.ExecuteNonQuery();
                res = cmd.Parameters["RES"].Value.ToString();
            }
            catch (Exception)
            {
                throw;
            }
            return res;
        }

        public string Update(LoginViewModel vm)
        {
            string res = "";
            try
            {
                //_context._unit = bo.UNIT_CODE;
                _context.Database.OpenConnection();
                DbCommand cmd = _context.Database.GetDbConnection().CreateCommand();
                cmd.CommandText = ""; //use proc name 
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.Add(new OracleParameter() { ParameterName = "UNIT_CODE_P", OracleDbType = OracleDbType.Varchar2, Value = vm.UNIT_CODE });
                //cmd.Parameters.Add(new OracleParameter() { ParameterName = "LINE_P", OracleDbType = OracleDbType.Varchar2, Value = vm.LINE });
                //cmd.Parameters.Add(new OracleParameter() { ParameterName = "MODIFIED_BY_P", OracleDbType = OracleDbType.Varchar2, Value = vm.MODIFIED_BY });

                cmd.Parameters.Add(new OracleParameter() { ParameterName = "ACTION", OracleDbType = OracleDbType.Varchar2, Value = "U" });
                cmd.Parameters.Add(new OracleParameter() { ParameterName = "RES", OracleDbType = OracleDbType.Varchar2, Size = 4000, Direction = ParameterDirection.Output });
                cmd.Parameters.Add(new OracleParameter() { ParameterName = "REF_RESULT", OracleDbType = OracleDbType.RefCursor, Direction = ParameterDirection.Output });
                cmd.ExecuteNonQuery();
                res = cmd.Parameters["RES"].Value.ToString();
            }
            catch (Exception ex)
            {
                res = ex.Message;
            }
            return res;
        }
    }
}
