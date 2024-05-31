using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
    public class LineRepo : ILineRepo
    {
        private readonly ApplicationDbContext _context;

        public LineRepo(ApplicationDbContext context)
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
                cmd.CommandText = "LINE_GET_INSERT_UPDATE";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new OracleParameter() { ParameterName = "Line_ID", OracleDbType = OracleDbType.Double, Value = id });
                cmd.Parameters.Add(new OracleParameter() { ParameterName = "Line_NAME", OracleDbType = OracleDbType.Varchar2 });
                cmd.Parameters.Add(new OracleParameter() { ParameterName = "Line_NO", OracleDbType = OracleDbType.Double });
                cmd.Parameters.Add(new OracleParameter() { ParameterName = "ISACTIVE", OracleDbType = OracleDbType.Double });

                cmd.Parameters.Add(new OracleParameter() { ParameterName = "ACTION", OracleDbType = OracleDbType.Varchar2, Value = "D" });
                cmd.Parameters.Add(new OracleParameter() { ParameterName = "RES", OracleDbType = OracleDbType.Varchar2, Size = 4000, Direction = ParameterDirection.Output });
                cmd.Parameters.Add(new OracleParameter() { ParameterName = "REF_RESULT", OracleDbType = OracleDbType.RefCursor, Direction = ParameterDirection.Output });
                cmd.ExecuteNonQuery();
                res = cmd.Parameters["RES"].Value.ToString();
            }
            catch (Exception ex)
            {
                string abc = ex.Message;
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
                cmd.CommandText = "LINE_GET_INSERT_UPDATE";  //Use proc noame 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter() { ParameterName = "ACTION", OracleDbType = OracleDbType.Varchar2, Value = "G" });
                cmd.Parameters.Add(new OracleParameter() { ParameterName = "RES", OracleDbType = OracleDbType.Varchar2, Size = 4000, Direction = ParameterDirection.Output });
                cmd.Parameters.Add(new OracleParameter() { ParameterName = "REF_RESULT", OracleDbType = OracleDbType.RefCursor, Direction = ParameterDirection.Output });
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

        public DataTable GetById(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                _context.Database.OpenConnection();
                DbCommand cmd = _context.Database.GetDbConnection().CreateCommand();
                cmd.CommandText = "LINE_GET_INSERT_UPDATE";  //Use proc noame 
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new OracleParameter() { ParameterName = "LINE_ID", OracleDbType = OracleDbType.Double, Value = id });
                cmd.Parameters.Add(new OracleParameter() { ParameterName = "LINE_NAME", OracleDbType = OracleDbType.Varchar2 });
                cmd.Parameters.Add(new OracleParameter() { ParameterName = "Line_NO", OracleDbType = OracleDbType.Double });
                cmd.Parameters.Add(new OracleParameter() { ParameterName = "ISACTIVE", OracleDbType = OracleDbType.Double });

                cmd.Parameters.Add(new OracleParameter() { ParameterName = "ACTION", OracleDbType = OracleDbType.Varchar2, Value = "GI" });
                cmd.Parameters.Add(new OracleParameter() { ParameterName = "RES", OracleDbType = OracleDbType.Varchar2, Size = 4000, Direction = ParameterDirection.Output });
                cmd.Parameters.Add(new OracleParameter() { ParameterName = "REF_RESULT", OracleDbType = OracleDbType.RefCursor, Direction = ParameterDirection.Output });
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

        public DataTable GetDataTable()
        {
            DataTable dt = new DataTable();
            try
            {
                _context.Database.OpenConnection();
                DbCommand cmd = _context.Database.GetDbConnection().CreateCommand();
                cmd.CommandText = "LINE_GET_INSERT_UPDATE";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new OracleParameter() { ParameterName = "LINE_ID", OracleDbType = OracleDbType.Double });
                cmd.Parameters.Add(new OracleParameter() { ParameterName = "LINE_NAME", OracleDbType = OracleDbType.Varchar2 });
                cmd.Parameters.Add(new OracleParameter() { ParameterName = "Line_NO", OracleDbType = OracleDbType.Double });
                cmd.Parameters.Add(new OracleParameter() { ParameterName = "ISACTIVE", OracleDbType = OracleDbType.Double });

                cmd.Parameters.Add(new OracleParameter() { ParameterName = "ACTION", OracleDbType = OracleDbType.Varchar2, Value = "G" });
                cmd.Parameters.Add(new OracleParameter() { ParameterName = "RES", OracleDbType = OracleDbType.Varchar2, Size = 4000, Direction = ParameterDirection.Output });
                cmd.Parameters.Add(new OracleParameter() { ParameterName = "REF_RESULT", OracleDbType = OracleDbType.RefCursor, Direction = ParameterDirection.Output });
                DbDataAdapter dataAdapter = DbProviderFactories.GetFactory(_context.Database.GetDbConnection()).CreateDataAdapter();
                dataAdapter.SelectCommand = cmd;
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);
                dt = ds.Tables[0];
                //errorMsg = cmd.Parameters["RES"].Value.ToString();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return dt;
        }

        public string Save(LineViewModel vm)
        {
            string res = "";
            try
            {
                //_context._unit = hmi.UNIT_CODE;
                _context.Database.OpenConnection();
                DbCommand cmd = _context.Database.GetDbConnection().CreateCommand();
                cmd.CommandText = "LINE_GET_INSERT_UPDATE";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new OracleParameter() { ParameterName = "LINE_ID", OracleDbType = OracleDbType.Double });
                cmd.Parameters.Add(new OracleParameter() { ParameterName = "LINE_NAME", OracleDbType = OracleDbType.Varchar2, Value = vm.Line_Name });
                cmd.Parameters.Add(new OracleParameter() { ParameterName = "Line_NO", OracleDbType = OracleDbType.Double,Value = vm.Line_NO });
                cmd.Parameters.Add(new OracleParameter() { ParameterName = "ISACTIVE", OracleDbType = OracleDbType.Double });

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

        public string Update(LineViewModel vm)
        {
            string res = "";
            try
            {
                _context.Database.OpenConnection();
                DbCommand cmd = _context.Database.GetDbConnection().CreateCommand();
                cmd.CommandText = "LINE_GET_INSERT_UPDATE";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new OracleParameter() { ParameterName = "LINE_ID", OracleDbType = OracleDbType.Double, Value = vm.Line_Id });
                cmd.Parameters.Add(new OracleParameter() { ParameterName = "LINE_NAME", OracleDbType = OracleDbType.Varchar2, Value = vm.Line_Name});
                cmd.Parameters.Add(new OracleParameter() { ParameterName = "Line_NO", OracleDbType = OracleDbType.Double, Value = vm.Line_NO });
                cmd.Parameters.Add(new OracleParameter() { ParameterName = "ISACTIVE", OracleDbType = OracleDbType.Double });

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
