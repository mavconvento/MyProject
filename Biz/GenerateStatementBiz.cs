using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ps = LWT.LoanServ.Biz;
using loanServ = LWT.LoanServ;
using System.IO;
using System.Web.Hosting;
using WCFWebService.DAL;
using System.Data;
using LWT.Common;
using LWT.LoanServ.Biz;

namespace WCFWebService.Biz
{
	public class GenerateStatementBiz
	{
        public ps.AccountStatement accountStatement;

		public Int64 GenerateStatement(Int64 InstallationID, Int64 AccountFacilityNo, Int64 AccountID, Int64 CustomerID, DateTime StartDate, DateTime EndDate)
        {
            try
            {
				Int64 AccountTemplateDocumentID;
		
				accountStatement = new ps.AccountStatement(InstallationID, -2);
				accountStatement.InstallationFundID = 0;
				accountStatement.AccountID = AccountID;
				accountStatement.StatementFromDate = StartDate;
				accountStatement.StatementToDate = EndDate;
				accountStatement.CustomerID = CustomerID;

				accountStatement.GenerateStatement();

				//get newly generated statement via AccountTemplateDocumentID
				AccountTemplateDocumentID = (new AccountStatementDAL()).GetAccountStatement
									(InstallationID, AccountFacilityNo, AccountID, CustomerID, StartDate, EndDate, 0);
				//}

				return AccountTemplateDocumentID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
			

		public byte[] DownloadStatamentFile(Int64 AccountDocumentTemplateID)
		{
			System.IO.FileStream fs1 = null;
			string fileName = @"AttachmentFile\AccountStatement";
			string LocalDocPath = Path.Combine (HostingEnvironment.ApplicationHost.GetPhysicalPath(), fileName);
			string destinationFile = "";
			try
			{
				loanServ.DAL.AccountDocumentTemplate DAL = new loanServ.DAL.AccountDocumentTemplate();
				DAL.AccountTemplateDocumentID = AccountDocumentTemplateID;

				DataSet dataSet = DAL.GetAccountTemplateDocumentByKey();

				DataTable dataTable = (DataTable)dataSet.Tables[0];
				 
				DataRow dataRow = dataTable.Rows[0];
				string OriginalFilename = LWTSafeTypes.SafeString(dataRow["OriginalFilename"].ToString());
				string SystemFilename = LWTSafeTypes.SafeString(dataRow["SystemFilename"].ToString());
				string FullSystemFilenamePath = LWTSafeTypes.SafeString(dataRow["FullSystemFilenamePath"].ToString());
				string FullPDFSystemFilenamePath = LWTSafeTypes.SafeString(dataRow["FullPDFSystemFilenamePath"].ToString());
				string ServerFileRootPath = CommonMethod.GetGlobalSetting("BOTH", "PATH_FILE_ROOT");
	 
				string sourceFile = FullPDFSystemFilenamePath;

				LWT.Common.Files.CreateDirectory(LocalDocPath);

				if (sourceFile == "") sourceFile = FullSystemFilenamePath;

				sourceFile = Path.Combine(ServerFileRootPath, sourceFile);

				string destinationFileName = Path.GetFileName(sourceFile);
				destinationFile = Path.Combine(LocalDocPath, destinationFileName);
							
                //if (File.Exists(sourceFile))
                //    File.Copy(sourceFile, destinationFile, true);
                //fs1 = System.IO.File.Open(destinationFile, FileMode.Open, FileAccess.Read);
                fs1 = System.IO.File.Open(sourceFile, FileMode.Open, FileAccess.Read);
				byte[] b1 = new byte[fs1.Length];
				fs1.Read(b1, 0, (int)fs1.Length);
				fs1.Close();
				return b1;						 
			}
			catch (Exception ex)
			{
				throw ex;
			}			
		}
	}
}