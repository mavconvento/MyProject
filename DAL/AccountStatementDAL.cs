using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;

using LWT.Common.DAL;
using LWT.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace WCFWebService.DAL
{
	public class AccountStatementDAL : BaseDAL
	{

		#region Variables
		private Database database = LWTDatabase.GetInstance().GetDatabase(CommonConstants.DATABASE_NAME);
		#endregion Variables

		//return  lmsAccountStatementSummary.AccountTemplateDocumentID 
		public Int64 GetAccountStatement(Int64 InstallationID, Int64 AccountFacilityID, Int64 AccountNo, Int64 CustomerID, 
			DateTime StartDate, DateTime EndDate, Int64 AccountTemplateDocumentID )
        {
            try
            {
				DbCommand DbCommand = database.GetStoredProcCommand("lmsAccountStatementGet");
				database.AddInParameter(DbCommand, "@InstallationID", DbType.Int64, InstallationID);
				database.AddInParameter(DbCommand, "@AccountFacilityID", DbType.Int64, AccountFacilityID);
				database.AddInParameter(DbCommand, "@AccountID", DbType.Int64, AccountNo);
				database.AddInParameter(DbCommand, "@CustomerID", DbType.Int64, CustomerID);
				database.AddInParameter(DbCommand, "@InputAccountTemplateDocumentID", DbType.Int64, AccountTemplateDocumentID);
				database.AddInParameter(DbCommand, "@StatementFrom", DbType.DateTime, StartDate);
                database.AddInParameter(DbCommand, "@StatementTo", DbType.DateTime, EndDate);
				database.AddOutParameter(DbCommand, "@AccountTemplateDocumentID", DbType.Int64, 20);
				database.ExecuteNonQuery(DbCommand);

				return LWTSafeTypes.SafeInt64(database.GetParameterValue(DbCommand, "@AccountTemplateDocumentID"));

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}