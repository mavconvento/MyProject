using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFWebService.Biz;
using System.Web.Hosting;
using WCFWebService.DAL;
using System.Web.Services.Protocols;


namespace WCFWebService
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CustomerPortalService" in code, svc and config file together.
	public class CustomerPortalService : WCFWebService.ServiceInterface.ICustomerPortalService
	{
        //return AccountTemplateDocumentID;
		public Int64 CreateAccountStatement(Int64 InstallationID, Int64 CustomerID, Int64 AccountFacilityNo, Int64 AccountNo, DateTime StartDate, DateTime EndDate)
		{
			try
			{				
				return (new GenerateStatementBiz()).GenerateStatement
														(InstallationID, AccountFacilityNo, AccountNo, CustomerID, StartDate, EndDate);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		//StatementCode is lmsAccountStatementSummary.AccountTemplateDocumentID 		
		public byte[] DownloadAccountStatamentFile(Int64 InstallationID,
			Int64 CustomerID, Int64 AccountFacilityNo, Int64 AccountNo, DateTime StartDate, DateTime EndDate, Int64 AccountTemplateDocumentID)
		{
			try
			{				
				//double check if AccountTemplateDocumentID belongs to the customer
				AccountTemplateDocumentID = (new AccountStatementDAL()).GetAccountStatement
                                                        (InstallationID, AccountFacilityNo, AccountNo, CustomerID, StartDate, EndDate, AccountTemplateDocumentID);
  
				if (AccountTemplateDocumentID == 0) { return null; }
				else
				{
					return (new GenerateStatementBiz()).DownloadStatamentFile(AccountTemplateDocumentID);
				}
			}
			catch (Exception ex)
			{
				throw ex;
				//return null;
			}
		}

	}
}
