using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;


namespace db_Oracle
{
	public class Tb_Plant
	{
        public int Plant_id { get; set; }
        public string Plant_Name { get; set; }
        public string Plant_Code { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }

		//variable used in operation
		string msg, conn;
		public string Operation_Message { get { return msg; } }
		public DataTable _DataTable = null;
		public DataSet _DataSetAll = null;

		public Tb_Plant(string Connstring)
		{
			msg = "";
			conn = Connstring;
		}

		#region Code
		public bool Insert()
		{
			bool flag = false;
			OracleConnection _OracleConnection = new OracleConnection(conn);
			OracleCommand _OracleCommand = new OracleCommand();
			_OracleCommand.Connection = _OracleConnection;
			_OracleCommand.Parameters.Add("@ID", SqlDbType.BigInt).Direction = ParameterDirection.Output;
			_OracleCommand.CommandText = @"Insert Into Tb_Plant Values('" + Plant_Name + "', '" + Plant_Code + "','" + CreateDate.ToString(Program.DateTime_Formate) + "', '" + IsActive +
						   "') SET @ID = SCOPE_IDENTITY()";
			try
			{
				_OracleConnection.Open();
				int st = _OracleCommand.ExecuteNonQuery();
				_OracleConnection.Close();
				if (st > 0)
				{
					//Doctor_Id = Convert.ToInt32(_OracleCommand.Parameters["@ID"].Value);
					msg = "Record Inserted";
					flag = true;
				}
				else
				{
					msg = "Error : Some problem occur";
					flag = false;
				}
			}
			catch (Exception ex)
			{
				msg = "Exception : " + ex.Message;
				flag = false;
			}
			finally
			{
				if (ConnectionState.Closed != _OracleConnection.State)
					_OracleConnection.Close();
			}
			return flag;
		}


		public bool Get_Active_List(string _Query, Int32 _Company_Id)
		{
			bool flag = false;
			DataSet _DataSet = null;
			OracleConnection _OracleConnection = new OracleConnection(conn);
			//SqlConnection _SqlConnection = new SqlConnection(conn);
			OracleCommand _OracleCommand = new OracleCommand();
			//SqlCommand _SqlCommand = new SqlCommand();
			//_SqlCommand.CommandText = @"SELECT  ROW_NUMBER() OVER(ORDER BY TBD.Name) AS SR_NO, *, dbo.fn_Doctor_Spec(TBD.Doctor_Id) AS Specialization 
			//                            FROM    Tb_Doctor AS TBD LEFT OUTER JOIN Tb_Doctor_Type AS TBDT ON(TBD.Doctor_Type_Id=TBDT.Doctor_Type_Id)
			//                            WHERE   TBD.Active = 1 AND (TBD.Can_Delete = 1 OR  TBD.Company_Id = " + _Company_Id + ")" + _Query + " ORDER BY TBD.Name";

			_OracleCommand.CommandText = "SELECT * FROM Tb_Plant WHERE IsActive = 1";
			//_SqlCommand.Connection = _SqlConnection;
			
			_OracleCommand.Connection = _OracleConnection;
			OracleDataAdapter _OracleDataAdapter = new OracleDataAdapter(_OracleCommand);
			//SqlDataAdapter _SqlDataAdapter = new SqlDataAdapter(_SqlCommand);
			_DataSet = new DataSet();
			try
			{
				_OracleDataAdapter.Fill(_DataSet);
				if (_DataSet != null)
				{
					if (_DataSet.Tables.Count > 0)
					{
						if (_DataSet.Tables[0].Rows.Count > 0)
						{
							msg = "Record found";
							_DataTable = _DataSet.Tables[0].Copy();
							flag = true;
						}
						else
						{
							msg = "Error : Record not found.";
						}
					}
					else
					{
						msg = "Error : Record not found.";
					}
				}
				else
				{
					msg = "Error : Record not found.";
				}
			}
			catch (Exception ex)
			{
				msg = "Exception : " + ex.Message;
			}
			finally
			{
				if (ConnectionState.Closed != _OracleConnection.State)
					_OracleConnection.Close();
			}
			return flag;
		}
		#endregion

	}
}
