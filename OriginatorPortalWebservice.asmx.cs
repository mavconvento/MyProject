using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using LWT.Common;
using System.IO;
using System.Web.Hosting;
using WCFWebService.Biz;
//using loanServ = LWT.LoanServ;
//using BinaryToFile;

namespace WCFWebService
{
    /// <summary>
    /// Summary description for OriginatorPortalWebservice
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class OriginatorPortalWebservice : System.Web.Services.WebService
    {

        [WebMethod(MessageName = "AccountUpdateDDRByIntroducer", Description = "Process Account DDR update By introducer id")]
        public string AccountUpdateDDRByIntroducer(string InstallationID, string soapusername, string soappassword,
            string IntroducerID, string FacilityNo, string AccountNo, 
            string DDRBSB, string DDRAccountNumber, string DDRAccountName, string DDRInstitution )
        {
            try
            {
                OriginatorBiz oBiz = new OriginatorBiz(InstallationID, soapusername, soappassword, IntroducerID, FacilityNo, AccountNo);
                
                FacilityDAL fdal = new FacilityDAL();
                DataSet myDataSet = fdal.AccountUpdateDDRByIntroducer(
                                   oBiz.InstallationID, oBiz.LWIntroducerID, oBiz.AccountFacilityID.Value,
                                   oBiz.AccountID.Value, DDRBSB, DDRAccountNumber, DDRAccountName, DDRInstitution);

                return myDataSet.GetXml();
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml(ex.Message.ToString()) + "</error>";
            }
        }

        [WebMethod(MessageName = "AccountTransferProcessTransferByIntroducer", Description = "Process Account transfer from / to account By introducer id")]
        public string AccountTransferProcessTransferByIntroducer(string InstallationID, string soapusername, string soappassword,
            string IntroducerID, string FacilityNo, string FromAccountNo, string ToAccountNo, string TransferAmount)
        {
            try
            {
                OriginatorBiz oBiz = new OriginatorBiz(InstallationID, soapusername, soappassword, IntroducerID, FacilityNo, FromAccountNo);
                Int64 toAccountNo = Convert.ToInt64(ToAccountNo);
                Decimal transferAmount = Convert.ToDecimal(TransferAmount);

                FacilityDAL fdal = new FacilityDAL();
                DataSet myDataSet = fdal.AccountTransferProcessTransferByIntroducer(
                                   oBiz.InstallationID, oBiz.LWIntroducerID, oBiz.AccountFacilityID.Value, 
                                   oBiz.AccountID.Value, toAccountNo, transferAmount);

                return myDataSet.GetXml();
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml(ex.Message.ToString()) + "</error>";
            }
        }

        [WebMethod(MessageName = "AccountTransferGetAccountDetailByIntroducer", Description = "Get Account transfer from / to account By introducer id")]
        public string AccountTransferGetAccountDetailByIntroducer(string InstallationID, string soapusername, string soappassword,
            string IntroducerID, string FacilityNo, string AccountNo)
        {
            try
            {
                OriginatorBiz oBiz = new OriginatorBiz(InstallationID, soapusername, soappassword, IntroducerID, FacilityNo, AccountNo);

                FacilityDAL fdal = new FacilityDAL();
                DataSet myDataSet = fdal.AccountTransferGetAccountDetailByIntroducer(
                                   oBiz.InstallationID, oBiz.LWIntroducerID, oBiz.AccountFacilityID.Value, oBiz.AccountID.Value);

                return myDataSet.GetXml();
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml(ex.Message.ToString()) + "</error>";
            }
        }

        [WebMethod(MessageName = "GetAccountRegularRepaymentListByIntroducer", Description = "Get Account Regular RepaymentListByIntroducer by introducer id")]
        public string GetAccountRegularRepaymentListByIntroducer(string InstallationID, string soapusername, string soappassword,
            string IntroducerID, string FacilityNo, string AccountNo)
        {
            try
            {
                OriginatorBiz oBiz = new OriginatorBiz(InstallationID, soapusername, soappassword, IntroducerID, FacilityNo, AccountNo);

                FacilityDAL fdal = new FacilityDAL();
                DataSet myDataSet = fdal.GetAccountRegularRepaymentListByIntroducer(
                                   oBiz.InstallationID, oBiz.LWIntroducerID, oBiz.AccountFacilityID.Value, oBiz.AccountID.Value);

                return myDataSet.GetXml();
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml(ex.Message.ToString()) + "</error>";
            }
        }

        [WebMethod(MessageName = "ApplyAccountNewRepaymentByIntroducer", Description = "apply account repayment by introducer id")]
        public string ApplyAccountNewRepaymentByIntroducer(string InstallationID, string soapusername, string soappassword,
            string IntroducerID, string FacilityNo, string AccountNo,
            string Newrepaymentdate, string NewRepaymentfrequency, string NewMinPaymentAmount, string NewNominateAmount, string NewAdditionalAmount)
        {
            try
            {
                OriginatorBiz oBiz = new OriginatorBiz(InstallationID, soapusername, soappassword, IntroducerID, FacilityNo, AccountNo);

                DateTime newrepaymentdate = Convert.ToDateTime(Newrepaymentdate);
                Decimal newMinPaymentAmount = Convert.ToDecimal(NewMinPaymentAmount);
                Decimal? newNominateAmount = null;
                if (NewNominateAmount != "" ) newNominateAmount = Convert.ToDecimal(NewNominateAmount); 
                Decimal newAdditionalAmount = Convert.ToDecimal(NewAdditionalAmount);

                FacilityDAL fdal = new FacilityDAL();
                DataSet myDataSet = fdal.ApplyAccountNewRepaymentByIntroducer(
                                   oBiz.InstallationID, oBiz.LWIntroducerID, oBiz.AccountFacilityID.Value, oBiz.AccountID.Value,
                                   newrepaymentdate, NewRepaymentfrequency, newMinPaymentAmount, newNominateAmount, newAdditionalAmount);

                return myDataSet.GetXml();
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml(ex.Message.ToString()) + "</error>";
            }
        }

        [WebMethod(MessageName = "CalculateAccountNewRepaymentByIntroducer", Description = "recalculate account repayment by introducer id")]
        public string CalculateAccountNewRepaymentByIntroducer(string InstallationID, string soapusername, string soappassword,
            string IntroducerID, string FacilityNo, string AccountNo, string Newrepaymentdate, string NewRepaymentfrequency)
        {
            try
            {
                OriginatorBiz oBiz = new OriginatorBiz(InstallationID, soapusername, soappassword, IntroducerID, FacilityNo, AccountNo);

                DateTime newrepaymentdate = Convert.ToDateTime(Newrepaymentdate);

                FacilityDAL fdal = new FacilityDAL();    
                DataSet myDataSet = fdal.CalculateAccountNewRepaymentByIntroducer(
                                   oBiz.InstallationID, oBiz.LWIntroducerID, oBiz.AccountFacilityID.Value, oBiz.AccountID.Value, newrepaymentdate, NewRepaymentfrequency);

                return myDataSet.GetXml();
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml(ex.Message.ToString()) + "</error>";
            }
        }

        [WebMethod(MessageName = "GetFacilityAccountStandardPaymentByIntroducer", Description = "GetFacilityAccountStandardPaymentByIntroducer")]
        public string GetFacilityAccountStandardPaymentByIntroducer(string InstallationID, string soapusername, string soappassword,
            string IntroducerID, string FacilityNo, string AccountNo)
        {
            try
            {
                OriginatorBiz oBiz = new OriginatorBiz(InstallationID, soapusername, soappassword, IntroducerID, FacilityNo, AccountNo);

                FacilityDAL fdal = new FacilityDAL();    
                DataSet myDataSet = fdal.GetFacilityAccountStandardPaymentByIntroducer(
                                   oBiz.InstallationID, oBiz.LWIntroducerID, oBiz.AccountFacilityID.Value, oBiz.AccountID.Value);

                return myDataSet.GetXml();
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml(ex.Message.ToString()) + "</error>";
            }
        }

        [WebMethod(MessageName = "CancelFacilityAccountOnceOffPaymentByIntroducer", Description = "Cancel Once Off payment by introducer id")]
        public string CancelFacilityAccountOnceOffPaymentByIntroducer(string InstallationID, string soapusername, string soappassword,
            string IntroducerID, string FacilityNo, string AccountNo, string PaymentID)
        {
            try
            {
                OriginatorBiz oBiz = new OriginatorBiz(InstallationID, soapusername, soappassword, IntroducerID, FacilityNo, AccountNo);
                                
                FacilityDAL fdal = new FacilityDAL();
                fdal.CancelFacilityAccountOnceOffPaymentByIntroducer(
                    oBiz.InstallationID, oBiz.LWIntroducerID, oBiz.AccountFacilityID.Value, oBiz.AccountID.Value,
                    Convert.ToInt64(PaymentID));

                DataSet myDataSet = fdal.GetFacilityAccountOnceOffPaymentListByIntroducer(
                                   oBiz.InstallationID, oBiz.LWIntroducerID, oBiz.AccountFacilityID.Value, oBiz.AccountID.Value);
                
                return myDataSet.GetXml();
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml( ex.Message.ToString()) + "</error>";
            }
        }

        [WebMethod(MessageName = "SaveFacilityAccountOnceOffPaymentByIntroducer", Description = "Save Once Off payment by introducer id")]
        public string SaveFacilityAccountOnceOffPaymentByIntroducer(string InstallationID, string soapusername, string soappassword,
            string IntroducerID, string FacilityNo, string AccountNo, string PaymentDate, string PaymentAmount)
        {
            try
            {
                OriginatorBiz oBiz = new OriginatorBiz(InstallationID, soapusername, soappassword, IntroducerID, FacilityNo, AccountNo);

                DateTime paymentDate = Convert.ToDateTime(PaymentDate);
                Decimal paymentamount = Convert.ToDecimal(PaymentAmount);
                FacilityDAL fdal = new FacilityDAL();
                fdal.SaveFacilityAccountOnceOffPaymentByIntroducer(
                    oBiz.InstallationID, oBiz.LWIntroducerID, oBiz.AccountFacilityID.Value, oBiz.AccountID.Value, paymentDate, paymentamount);

                DataSet myDataSet = fdal.GetFacilityAccountOnceOffPaymentListByIntroducer(
                                   oBiz.InstallationID, oBiz.LWIntroducerID, oBiz.AccountFacilityID.Value, oBiz.AccountID.Value);

                return myDataSet.GetXml();
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml( ex.Message.ToString()) + "</error>";
            }
        }

        [WebMethod(MessageName = "GetFacilityAccountOnceOffPaymentListByIntroducer", Description = "Return facility accounts searched by introducer id as XML DataSet")]
        public string GetFacilityAccountOnceOffPaymentListByIntroducer(string InstallationID, string soapusername, string soappassword,
            string IntroducerID, string FacilityNo, string AccountNo )
        {
            try
            {
                OriginatorBiz oBiz = new OriginatorBiz(InstallationID, soapusername, soappassword, IntroducerID, FacilityNo, AccountNo);

                DataSet myDataSet = (new FacilityDAL()).GetFacilityAccountOnceOffPaymentListByIntroducer(
                    oBiz.InstallationID, oBiz.LWIntroducerID, oBiz.AccountFacilityID.Value, oBiz.AccountID.Value);
                return myDataSet.GetXml();
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml( ex.Message.ToString()) + "</error>";
            }
        }

        [WebMethod(MessageName = "GetFacilityAccountListByIntroducer", Description = "Return facility accounts searched by introducer id as XML DataSet")]
        public string GetFacilityAccountListByIntroducer( string InstallationID,string soapusername, string soappassword,
            string IntroducerID, string FacilityNo, string AccountNo, string borrowerFirstName, string borrowerLastName, string companyTrustName,
            string streetNo,string streetName, string suburb, string state, string postcode )
        {
            try
            {
                OriginatorBiz oBiz = new OriginatorBiz(InstallationID, soapusername, soappassword, IntroducerID, FacilityNo, AccountNo);

                DataSet myDataSet = (new FacilityDAL()).GetFacilityAccountListByIntroducer(
                    oBiz.InstallationID, oBiz.LWIntroducerID, oBiz.AccountFacilityID, oBiz.AccountID, 
                    borrowerFirstName, borrowerLastName, companyTrustName,
                    streetNo, streetName, suburb, state, postcode);
                return myDataSet.GetXml();
               
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml( ex.Message.ToString()) + "</error>";
            }
        }
        
        [WebMethod(MessageName = "GetAccountDetailsByIntroducer", Description = "Return account details by introducer id as XML DataSet")]
        public string GetAccountDetailsByIntroducer(string InstallationID,
            string soapusername, string soappassword,
            string IntroducerID, string FacilityNo, string AccountNo)
        {
            try
            {
                OriginatorBiz oBiz = new OriginatorBiz(InstallationID, soapusername, soappassword, IntroducerID, FacilityNo, AccountNo);
                                 
                DataSet myDataSet = (new FacilityDAL()).GetAccountDetailByIntroducer(
                    oBiz.InstallationID, oBiz.LWIntroducerID, oBiz.AccountFacilityID.Value, oBiz.AccountID.Value);
                return myDataSet.GetXml();                
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml( ex.Message.ToString()) + "</error>";
            }
        }

        [WebMethod(MessageName = "GetAccountInterestRateHistoryByAccount", Description = "Return account rate history by account id as XML DataSet")]
        public string GetAccountInterestRateHistoryByAccount(string InstallationID,
            string soapusername, string soappassword,
            string IntroducerID, string FacilityNo, string AccountNo)
        {
            try
            {
                OriginatorBiz oBiz = new OriginatorBiz(InstallationID, soapusername, soappassword, IntroducerID, FacilityNo, AccountNo);
                DataSet myDataSet = (new FacilityDAL()).GetAccountInterestRateHistoryByAccount(
                    oBiz.InstallationID, oBiz.LWIntroducerID, oBiz.AccountFacilityID.Value, oBiz.AccountID.Value);
                return myDataSet.GetXml();               
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml( ex.Message.ToString()) + "</error>";
            }
        }

        [WebMethod(MessageName = "GetBorrowerDetailsByIntroducer", Description = "Return borrower/guarantor/mortgagee by account id as XML DataSet")]
        public string GetBorrowerDetailsByIntroducer(string InstallationID,
            string soapusername, string soappassword,
            string IntroducerID, string FacilityNo, string AccountNo)
        {
            try
            {
                OriginatorBiz oBiz = new OriginatorBiz(InstallationID, soapusername, soappassword, IntroducerID, FacilityNo, AccountNo);

                DataSet myDataSet = (new FacilityDAL()).GetBorrowerDetailByIntroducer(
                        oBiz.InstallationID, oBiz.LWIntroducerID, oBiz.AccountFacilityID.Value);
                return myDataSet.GetXml();
             
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml( ex.Message.ToString()) + "</error>";
            }
        }
       
        [WebMethod(MessageName = "GetSecurityDetailsByIntroducer", Description = "Return  as XML DataSet")]
        public string GetSecurityDetailsByIntroducer(string InstallationID,
            string soapusername, string soappassword,
            string IntroducerID, string FacilityNo, string AccountNo)
        {
            try
            {
                OriginatorBiz oBiz = new OriginatorBiz(InstallationID, soapusername, soappassword, IntroducerID, FacilityNo, "");
                DataSet myDataSet = (new FacilityDAL()).GetSecurityDetailByIntroducer(
                    oBiz.InstallationID, oBiz.LWIntroducerID, oBiz.AccountFacilityID.Value);
                return myDataSet.GetXml();                
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml( ex.Message.ToString()) + "</error>";
            }
        }

        [WebMethod(MessageName = "GetPaymentDetailsByIntroducer", Description = "Return account rate history by account id as XML DataSet")]
        public string GetPaymentDetailsByIntroducer(string InstallationID,
            string soapusername, string soappassword,
            string IntroducerID, string FacilityNo, string AccountNo)
        {
            try
            {
                OriginatorBiz oBiz = new OriginatorBiz(InstallationID, soapusername, soappassword, IntroducerID, FacilityNo, AccountNo);

                DataSet myDataSet = (new FacilityDAL()).GetPaymentDetailByIntroducer(
                    oBiz.InstallationID, oBiz.LWIntroducerID, oBiz.AccountFacilityID.Value, oBiz.AccountID.Value);
                return myDataSet.GetXml();
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml( ex.ToString()) + "</error>";
            }
        }

        [WebMethod(MessageName = "GetDDRBpayDetailsByIntroducer", Description = "Return account rate history by account id as XML DataSet")]
        public string GetDDRBpayDetailsByIntroducer(string InstallationID,
            string soapusername, string soappassword,
            string IntroducerID, string FacilityNo, string AccountNo)
        {
            try
            {
                OriginatorBiz oBiz = new OriginatorBiz(InstallationID, soapusername, soappassword, IntroducerID, FacilityNo, AccountNo);

                DataSet myDataSet = (new FacilityDAL()).GetDDRBpayDetailByIntroducer(
                    oBiz.InstallationID, oBiz.LWIntroducerID, oBiz.AccountFacilityID.Value, oBiz.AccountID.Value);
                return myDataSet.GetXml();
               
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml( ex.ToString()) + "</error>";
            }
        }

        [WebMethod(MessageName = "GetArrearsDetailsByIntroducer", Description = "Return account arrears history by account id as XML DataSet")]
        public string GetArrearsDetailsByIntroducer(string InstallationID,
            string soapusername, string soappassword,
            string IntroducerID, string FacilityNo, string AccountNo,string ArrearsNotes)
        {
            try
            {
                OriginatorBiz oBiz = new OriginatorBiz(InstallationID, soapusername, soappassword, IntroducerID, FacilityNo, AccountNo);

                DataSet myDataSet = (new FacilityDAL()).GetArrearsDetailsByIntroducer(
                    oBiz.InstallationID, oBiz.LWIntroducerID, oBiz.AccountFacilityID.Value, oBiz.AccountID.Value, ArrearsNotes);
                return myDataSet.GetXml();
              
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml( ex.ToString()) + "</error>";
            }
        }

        [WebMethod(MessageName = "GetRedrawDetailsByIntroducer", Description = "Return account rate history by account id as XML DataSet")]
        public string GetRedrawDetailsByIntroducer(string InstallationID,
            string soapusername, string soappassword,
            string IntroducerID, string FacilityNo, string AccountNo)
        {
            try
            {
                OriginatorBiz oBiz = new OriginatorBiz(InstallationID, soapusername, soappassword, IntroducerID, FacilityNo, AccountNo);

                DataSet myDataSet = (new FacilityDAL()).GetRedrawDetailsByIntroducer(
                    oBiz.InstallationID, oBiz.LWIntroducerID, oBiz.AccountFacilityID.Value, oBiz.AccountID.Value);
                return myDataSet.GetXml();              
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml( ex.ToString()) + "</error>";
            }


        }

        [WebMethod(MessageName = "GetAccountTransactionsByIntroducer", Description = "Return account transactions by account id as XML DataSet")]
        public string GetAccountTransactionsByIntroducer(string InstallationID,
            string soapusername, string soappassword,
            string IntroducerID, string FacilityNo, string AccountNo)
        {
            try
            {
                OriginatorBiz oBiz = new OriginatorBiz(InstallationID, soapusername, soappassword, IntroducerID, FacilityNo, AccountNo);
                DataSet myDataSet = (new FacilityDAL()).GetAccountTransactionsByIntroducer(
                    oBiz.InstallationID, oBiz.LWIntroducerID, oBiz.AccountFacilityID.Value, oBiz.AccountID.Value);
                return myDataSet.GetXml();
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml( ex.ToString()) + "</error>";
            }
        }

        // not used
        [WebMethod(MessageName = "GetAccountStatementListByIntroducer", Description = "Return account tax statement history by account id as XML DataSet")]
        public string GetAccountStatementListByIntroducer(string InstallationID,
            string soapusername, string soappassword,
            string IntroducerID, string FacilityNo, string AccountNo, string StartDate, string EndDate)
        {
            try
            {
                DateTime startDate, endDate;
                if (StartDate == "" || EndDate == "")
                    throw new Exception("Missing Date range");

                OriginatorBiz oBiz = new OriginatorBiz(InstallationID, soapusername, soappassword, IntroducerID, FacilityNo, AccountNo);

                startDate = Convert.ToDateTime(StartDate);
                endDate = Convert.ToDateTime(EndDate);

                DataSet myDataSet = (new FacilityDAL()).GetAccountStatementListByIntroducer(
                        oBiz.InstallationID, oBiz.LWIntroducerID, oBiz.AccountFacilityID.Value, oBiz.AccountID.Value, startDate, endDate);
                return myDataSet.GetXml();
                
            }
            catch (Exception ex)
            {
                return "<error>" + ex.Message.ToString() + "</error>";
            }
        }

		[WebMethod(MessageName = "CreateStatementByIntroducer", Description = "Create statements per nominiated borrower and return list as XML DataSet")]
        public string CreateStatementByIntroducer(string InstallationID,
			string soapusername, string soappassword,
            string IntroducerID, string FacilityNo, string AccountNo, string StartDate, string EndDate)
		{
			try
			{				
                DateTime startDate, endDate;

                if (StartDate == "" || EndDate == "")
                    throw new Exception("Missing Date range");

                OriginatorBiz oBiz = new OriginatorBiz(InstallationID, soapusername, soappassword, IntroducerID, FacilityNo, AccountNo);                               
                startDate = Convert.ToDateTime(StartDate);
                endDate = Convert.ToDateTime(EndDate);
              
                GenerateStatementBiz generateStatement = new GenerateStatementBiz();
                Int64 AccountTemplateDocumentID = generateStatement.GenerateStatement(
                    Convert.ToInt64(InstallationID), Convert.ToInt64(FacilityNo), Convert.ToInt64(AccountNo), 0, startDate, endDate);

                return "<accountdocumentid>" + LWTSafeTypes.SafeString( AccountTemplateDocumentID ) + "</accountdocumentid>";

                //DataSet myDataSet = (new FacilityDAL()).GetStatementByIntroducer(
                //    oBiz.InstallationID, oBiz.LWIntroducerID, oBiz.AccountFacilityID.Value, oBiz.AccountID.Value, startDate, endDate);
                //return myDataSet.GetXml();				
			}
			catch (Exception ex)
			{
				return "<error>" + ex.Message.ToString() + "</error>";
			}
		}

		//StatementCode is lmsAccountStatementSummary.AccountTemplateDocumentID 
        [WebMethod(MessageName = "DownloadStatamentFile", Description = "Return binary file of report generated on lms")]
        public byte[] DownloadStatamentFile(string InstallationID, string soapusername, string soappassword, string StatementCode) 
        {
            try
            {
				//EY: this method should require more parameter to validate if request is a valid request for the account
                if (!Security.SoapRequestAuthenticated(soapusername, soappassword))
                    return null;

				return (new GenerateStatementBiz()).DownloadStatamentFile(Convert.ToInt64(StatementCode));               
            }
            catch (Exception)
            {
                return null;
            }
        }
         
    }
}
