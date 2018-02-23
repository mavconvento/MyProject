using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WCFWebService.Biz;
using System.Web.Hosting;
using WCFWebService.DAL;
using System.Web.Services.Protocols;
using WCFWebService.Biz;
using LWT.Common;
using System.Data;
//{1}{108.54} Pewee 23/6/2015  Add View Loan (Facility) Details, View Borrower and Guarantor’s  Details ,View Portion (Account) Details
            //View statements for any period, Generate statements for any period (by selecting a date range) ,Set up ongoing direct debits, change frequency of repayments and increase/decrease repayments
            //Set up additional once off payments, Set up redraws, Have access to  rate history  Just the Borrower Rate history ,View list of current transactions, Transfer Funds between accounts
//[2]{108.541} 6/8/2015 Pewee Add FacilityID
//[3]{108.541} 10/8/2015 Pewee Fixed dateformat for mdyyyy
namespace WCFWebService
{
	/// <summary>
	/// Summary description for CustomerPortalWebservice
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	// [System.Web.Script.Services.ScriptService]
	public class CustomerPortalWebservice : System.Web.Services.WebService
	{
        /*===================================FORGOT PASSWORD SECTION==================================*/
        [WebMethod(MessageName = "ValidateCustomerPortalLogin", Description = "ValidateCustomerPortalLogin")]
        public string ValidateCustomerPortalLogin(string InstallationID, string soapusername, string soappassword,
            string CustomerLogin, string CustomerPassword)
        {
            try
            {
                CustomerBiz oBiz = new CustomerBiz(soapusername, soappassword);

                DataSet myDataSet = oBiz.ValidateCustomerPortalLogin(InstallationID, CustomerLogin, CustomerPassword);

                return myDataSet.GetXml();
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml(ex.Message.ToString()) + "</error>";
            }
        }


        [WebMethod(MessageName = "GetSecurityQuestionList", Description = "ValidateCustomerPortalLogin")]
        public string GetSecurityQuestionList(string InstallationID, string soapusername, string soappassword)
        {
            try
            {
                CustomerBiz oBiz = new CustomerBiz(soapusername, soappassword);

                DataSet myDataSet = oBiz.GetSecurityQuestionList(InstallationID);

                return myDataSet.GetXml();
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml(ex.Message.ToString()) + "</error>";
            }
        }

        [WebMethod(MessageName = "ValidateCustomer", Description = "ValidateCustomer")]
        public string ValidateCustomer(string InstallationID, string soapusername, string soappassword,
                string CustomerID, string CustomerDOB, string AccountFacilityID, string AccountNo)
        {
            try
            {
                DateTime customerdob;

                CustomerBiz oBiz = new CustomerBiz(InstallationID, soapusername, soappassword, CustomerID, AccountFacilityID, AccountNo);

                customerdob = Convert.ToDateTime(GetFormatDate(CustomerDOB));

                DataSet myDataSet = (new FacilityByCustomerDAL()).ValidateCustomer(oBiz.InstallationID, oBiz.CustomerID, customerdob, oBiz.AccountFacilityID.Value, oBiz.AccountID.Value);
             
                return myDataSet.GetXml();
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml(ex.Message.ToString()) + "</error>";
            }
        }

        [WebMethod(MessageName = "GetSecurityQuestion", Description = "GetSecurityQuestion")]
        public string GetSecurityQuestion(string InstallationID, string soapusername, string soappassword, string CustomerID, string CustomerDOB,
            string AccountFacilityID, string AccountNo)
        {
            try
            {
                DateTime customerdob;
                CustomerBiz oBiz = new CustomerBiz(InstallationID, soapusername, soappassword, CustomerID, AccountFacilityID, AccountNo);

                //customerdob = Convert.ToDateTime(CustomerDOB);
                customerdob = Convert.ToDateTime(GetFormatDate(CustomerDOB));

                DataSet myDataSet = (new FacilityByCustomerDAL()).GetSecurityQuestion(oBiz.InstallationID, oBiz.CustomerID, customerdob, oBiz.AccountFacilityID.Value, oBiz.AccountID.Value);

                return myDataSet.GetXml();
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml(ex.Message.ToString()) + "</error>";
            }
        }

        [WebMethod(MessageName = "ValidateSecurityQuestion", Description = "ValidateSecurityQuestion")]
        public string ValidateSecurityQuestion(string InstallationID, string soapusername, string soappassword, string CustomerID, string CustomerDOB, string AccountFacilityID, string AccountNo, 
            string SecurityAnswer)
        {
            try
            {
                DateTime customerdob;
                CustomerBiz oBiz = new CustomerBiz(InstallationID, soapusername, soappassword, CustomerID, AccountFacilityID, AccountNo);

                customerdob = Convert.ToDateTime(GetFormatDate(CustomerDOB));

                DataSet myDataSet = (new FacilityByCustomerDAL()).ValidateSecurityQuestion(oBiz.InstallationID, oBiz.CustomerID, customerdob, oBiz.AccountFacilityID.Value, oBiz.AccountID.Value, SecurityAnswer);

                return myDataSet.GetXml();
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml(ex.Message.ToString()) + "</error>";
            }
        }


        [WebMethod(MessageName = "StoreCustomerSecurityQuestion", Description = "StoreCustomerSecurityQuestion")]
        public string StoreCustomerSecurityQuestion(
                string InstallationID, string soapusername, string soappassword, string CustomerID, string CustomerDOB, string AccountFacilityID, string AccountNo, 
                string SecurityQuestion, string SecurityAnswer)
        {
            try
            {
                DateTime customerdob;
                CustomerBiz oBiz = new CustomerBiz(InstallationID, soapusername, soappassword, CustomerID, AccountFacilityID, AccountNo);

                customerdob = Convert.ToDateTime(GetFormatDate(CustomerDOB));

                DataSet myDataSet = (new FacilityByCustomerDAL()).StoreCustomerSecurityQuestion(
                        oBiz.InstallationID, oBiz.CustomerID, customerdob, oBiz.AccountFacilityID.Value, oBiz.AccountID.Value, SecurityQuestion, SecurityAnswer);

                return myDataSet.GetXml();
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml(ex.Message.ToString()) + "</error>";
            }
        }

        [WebMethod(MessageName = "GetCustomerDetails", Description = "ValidateEmailMobile")]
        public string GetCustomerDetails(string InstallationID, string soapusername, string soappassword, string CustomerID)
        {
            try
            {
                CustomerBiz oBiz = new CustomerBiz(InstallationID, soapusername, soappassword, CustomerID, "", "");
                DataSet myDataSet = (new FacilityByCustomerDAL()).GetCustomerDetails(oBiz.CustomerID);

                return myDataSet.GetXml();
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml(ex.Message.ToString()) + "</error>";
            }
        }

        [WebMethod(MessageName = "GetEmailMobile", Description = "ValidateEmailMobile")]
        public string GetEmailMobile(string InstallationID, string soapusername, string soappassword, string CustomerID, string CustomerDOB, string AccountFacilityID, string AccountNo)
        {
            try
            {
                DateTime customerdob;
                CustomerBiz oBiz = new CustomerBiz(InstallationID, soapusername, soappassword, CustomerID, AccountFacilityID, AccountNo);

                //customerdob = Convert.ToDateTime(CustomerDOB);
                customerdob = Convert.ToDateTime(GetFormatDate(CustomerDOB));

                DataSet myDataSet = (new FacilityByCustomerDAL()).GetEmailMobile(oBiz.InstallationID, oBiz.CustomerID, customerdob, oBiz.AccountFacilityID.Value, oBiz.AccountID.Value);

                return myDataSet.GetXml();
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml(ex.Message.ToString()) + "</error>";
            }
        }

        [WebMethod(MessageName = "SubmitForgotPassword", Description = "ValidateEmailMobile")]
        public string SubmitForgotPassword(string InstallationID, string soapusername, string soappassword, string CustomerID, string OriginPage, string CustomerDOB, string AccountFacilityID, string AccountNo, 
            string SecurityAnswer, string Email)
        {
            try
            {
                DateTime customerdob;
                CustomerBiz oBiz = new CustomerBiz(InstallationID, soapusername, soappassword, CustomerID, AccountFacilityID, AccountNo);

                //customerdob = Convert.ToDateTime(CustomerDOB);
                customerdob = Convert.ToDateTime(GetFormatDate(CustomerDOB));

                DataSet myDataSet = (new FacilityByCustomerDAL()).SubmitForgotPassword(oBiz.InstallationID, oBiz.CustomerID, OriginPage,customerdob, oBiz.AccountFacilityID.Value, oBiz.AccountID.Value, SecurityAnswer, Email);

                return myDataSet.GetXml();
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml(ex.Message.ToString()) + "</error>";
            }
        }
        /*===========================CHANGE PASSWORD SECTION=======================================*/

        [WebMethod(MessageName = "SubmitChangePassword", Description = "SubmitChangePassword")]
        public string SubmitChangePassword(string InstallationID, string soapusername, string soappassword, string CustomerID, string OriginPage, string CustomerDOB, string AccountFacilityID, string AccountNo, 
            string CurrentPassword, string NewPassword, string TranType)
        {
            try
            {
                DateTime customerdob;
                CustomerBiz oBiz = new CustomerBiz(InstallationID, soapusername, soappassword, CustomerID, AccountFacilityID, AccountNo);

                //customerdob = Convert.ToDateTime(CustomerDOB);
                customerdob = Convert.ToDateTime(GetFormatDate(CustomerDOB));

                DataSet myDataSet = (new FacilityByCustomerDAL()).SubmitChangePassword(oBiz.InstallationID, oBiz.CustomerID, OriginPage, customerdob, oBiz.AccountFacilityID.Value , oBiz.AccountID.Value, CurrentPassword, NewPassword, TranType);

                return myDataSet.GetXml();
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml(ex.Message.ToString()) + "</error>";
            }
        }


        [WebMethod(MessageName = "CustomerAcceptTermsAndConditions", Description = "Return system error if any")]
        public string CustomerAcceptTermsAndConditions(string InstallationID, string soapusername, string soappassword,
            string CustomerID)
        {
            try
            {
                CustomerBiz oBiz = new CustomerBiz(InstallationID, soapusername, soappassword, CustomerID, "", "");

                FacilityByCustomerDAL DAL =  new FacilityByCustomerDAL();
                DAL.CustomerAcceptTermsAndConditions(oBiz.InstallationID, oBiz.CustomerID);
                    
                return "";
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml(ex.Message.ToString()) + "</error>";
            }
        }



        /*===========================POST SETTLEMENT SECTION=======================================*/
 


        [WebMethod(MessageName = "GetFacilityAccountListByCustomer", Description = "Return facility list by CustomerId as XML DataSet")]
        public string GetFacilityAccountListByCustomer(string InstallationID, string soapusername, string soappassword,
            string CustomerID )
        {
            try
            {
                CustomerBiz oBiz = new CustomerBiz(InstallationID, soapusername, soappassword, CustomerID, "", "");

                DataSet myDataSet = (new FacilityByCustomerDAL()).GetFacilityAccountListByCustomer(
                    oBiz.InstallationID, oBiz.CustomerID);
                return myDataSet.GetXml();
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml(ex.Message.ToString()) + "</error>";
            }
        }

        [WebMethod(MessageName = "GetAccountDetailsByCustomer", Description = "Return account details by CustomerID as XML DataSet")]
        public string GetAccountDetailsByCustomer(string InstallationID, string soapusername, string soappassword, string CustomerID, string FacilityNo, string AccountNo)
        {
            try
            {
                CustomerBiz oBiz = new CustomerBiz(InstallationID, soapusername, soappassword, CustomerID, FacilityNo, AccountNo);

                DataSet myDataSet = (new FacilityByCustomerDAL()).GetAccountDetailByCustomer(
                    oBiz.InstallationID, oBiz.CustomerID, oBiz.AccountFacilityID.Value, oBiz.AccountID.Value);
                return myDataSet.GetXml();
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml(ex.Message.ToString()) + "</error>";
            }
        }

        [WebMethod(MessageName = "GetAccountTransactionsByCustomer", Description = "Return account transactions by account id as XML DataSet")]
        public string GetAccountTransactionsByCustomer(string InstallationID, string soapusername, string soappassword,string CustomerID
            , string FacilityNo, string AccountNo)
        {
            try
            {
                CustomerBiz oBiz = new CustomerBiz(InstallationID, soapusername, soappassword, CustomerID, FacilityNo, AccountNo);
                DataSet myDataSet = (new FacilityByCustomerDAL()).GetAccountTransactionsByCustomer(
                    oBiz.InstallationID, oBiz.CustomerID, oBiz.AccountFacilityID.Value, oBiz.AccountID.Value);
                return myDataSet.GetXml();
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml(ex.ToString()) + "</error>";
            }
        }

        [WebMethod(MessageName = "GetBorrowerDetailByCustomer", Description = "Return borrower/guarantor/mortgagee by account id as XML DataSet")]
        public string GetBorrowerDetailByCustomer(string InstallationID,
            string soapusername, string soappassword,
            string CustomerID, string FacilityNo, string AccountNo)
        {
            try
            {
                CustomerBiz oBiz = new CustomerBiz(InstallationID, soapusername, soappassword, CustomerID, FacilityNo, AccountNo);

                DataSet myDataSet = (new FacilityByCustomerDAL()).GetBorrowerDetailByCustomer(
                        oBiz.InstallationID, oBiz.CustomerID, oBiz.AccountFacilityID.Value);
                return myDataSet.GetXml();

            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml(ex.Message.ToString()) + "</error>";
            }
        }

        [WebMethod(MessageName = "GetSecurityDetailByCustomer", Description = "Return  as XML DataSet")]
        public string GetSecurityDetailByCustomer(string InstallationID, string soapusername, string soappassword, string CustomerID, string FacilityNo, string AccountNo)
        {
            try
            {
                CustomerBiz oBiz = new CustomerBiz(InstallationID, soapusername, soappassword, CustomerID, FacilityNo, "");
                DataSet myDataSet = (new FacilityByCustomerDAL()).GetSecurityDetailByCustomer(
                    oBiz.InstallationID, oBiz.CustomerID, oBiz.AccountFacilityID.Value);
                return myDataSet.GetXml();
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml(ex.Message.ToString()) + "</error>";
            }
        }

        [WebMethod(MessageName = "CreateStatementByCustomer", Description = "Create statements per nominiated borrower and return list as XML DataSet")]
        public string CreateStatementByCustomer(string InstallationID,
            string soapusername, string soappassword,
            string CustomerID, string FacilityNo, string AccountNo, string StartDate, string EndDate)
        {
            try
            {
                DateTime startDate, endDate;

                if (StartDate == "" || EndDate == "")
                    throw new Exception("Missing Date range");

                CustomerBiz oBiz = new CustomerBiz(InstallationID, soapusername, soappassword, CustomerID, FacilityNo, AccountNo);
                startDate = Convert.ToDateTime(StartDate);
                endDate = Convert.ToDateTime(EndDate);

                GenerateStatementBiz generateStatement = new GenerateStatementBiz();
                Int64 AccountTemplateDocumentID = generateStatement.GenerateStatement(
                    Convert.ToInt64(InstallationID), Convert.ToInt64(FacilityNo), Convert.ToInt64(AccountNo), 0, startDate, endDate);

                return "<accountdocumentid>" + LWTSafeTypes.SafeString(AccountTemplateDocumentID) + "</accountdocumentid>";
            }
            catch (Exception ex)
            {
                return "<error>" + ex.Message.ToString() + "</error>";
            }
        }

        [WebMethod(MessageName = "GetAccountStatementListByCustomer", Description = "Return account tax statement history by account id as XML DataSet")]
        public string GetAccountStatementListByCustomer(string InstallationID,
            string soapusername, string soappassword,
            string CustomerID, string FacilityNo, string AccountNo, string StartDate, string EndDate)
        {
            try
            {
                DateTime startDate, endDate;
                if (StartDate == "" || EndDate == "")
                    throw new Exception("Missing Date range");

                CustomerBiz oBiz = new CustomerBiz(InstallationID, soapusername, soappassword, CustomerID, FacilityNo, AccountNo);

                startDate = Convert.ToDateTime(StartDate);
                endDate = Convert.ToDateTime(EndDate);

                DataSet myDataSet = (new FacilityByCustomerDAL()).GetAccountStatementListByCustomer(
                        oBiz.InstallationID, oBiz.CustomerID, oBiz.AccountFacilityID.Value, oBiz.AccountID.Value, startDate, endDate);
                return myDataSet.GetXml();

            }
            catch (Exception ex)
            {
                return "<error>" + ex.Message.ToString() + "</error>";
            }
        }

        [WebMethod(MessageName = "AccountTransferGetAccountDetailByCustomer", Description = "Get Account transfer from / to account By introducer id")]
        public string AccountTransferGetAccountDetailByCustomer(string InstallationID, string soapusername, string soappassword,
            string CustomerID, string FacilityNo, string AccountNo)
        {
            try
            {
                CustomerBiz oBiz = new CustomerBiz(InstallationID, soapusername, soappassword, CustomerID, FacilityNo, AccountNo);

                DataSet myDataSet = (new FacilityByCustomerDAL()).AccountTransferGetAccountDetailByCustomer(
                                   oBiz.InstallationID, oBiz.CustomerID, oBiz.AccountFacilityID.Value, oBiz.AccountID.Value);

                return myDataSet.GetXml();
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml(ex.Message.ToString()) + "</error>";
            }
        }

        [WebMethod(MessageName = "GetFacilityAccountOnceOffPaymentListByCustomer", Description = "Return facility accounts searched by introducer id as XML DataSet")]
        public string GetFacilityAccountOnceOffPaymentListByCustomer(string InstallationID, string soapusername, string soappassword,
            string CustomerID, string FacilityNo, string AccountNo)
        {
            try
            {
                CustomerBiz oBiz = new CustomerBiz(InstallationID, soapusername, soappassword, CustomerID, FacilityNo, AccountNo);

                DataSet myDataSet = (new FacilityByCustomerDAL()).GetFacilityAccountOnceOffPaymentListByCustomer(
                    oBiz.InstallationID, oBiz.CustomerID, oBiz.AccountFacilityID.Value, oBiz.AccountID.Value);
                return myDataSet.GetXml();
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml(ex.Message.ToString()) + "</error>";
            }
        }

        [WebMethod(MessageName = "SaveFacilityAccountOnceOffPaymentByCustomer", Description = "Save Once Off payment by introducer id")]
        public string SaveFacilityAccountOnceOffPaymentByCustomer(string InstallationID, string soapusername, string soappassword,
            string CustomerID, string FacilityNo, string AccountNo, string PaymentDate, string PaymentAmount)
        {
            try
            {
                CustomerBiz oBiz = new CustomerBiz(InstallationID, soapusername, soappassword, CustomerID, FacilityNo, AccountNo);

                DateTime paymentDate = Convert.ToDateTime(PaymentDate);
                Decimal paymentamount = Convert.ToDecimal(PaymentAmount);
                FacilityByCustomerDAL fdal = new FacilityByCustomerDAL();
                fdal.SaveFacilityAccountOnceOffPaymentByCustomer(
                    oBiz.InstallationID, oBiz.CustomerID, oBiz.AccountFacilityID.Value, oBiz.AccountID.Value, paymentDate, paymentamount);

                DataSet myDataSet = fdal.GetFacilityAccountOnceOffPaymentListByCustomer(
                                   oBiz.InstallationID, oBiz.CustomerID, oBiz.AccountFacilityID.Value, oBiz.AccountID.Value);

                return myDataSet.GetXml();
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml(ex.Message.ToString()) + "</error>";
            }
        }

        [WebMethod(MessageName = "CancelFacilityAccountOnceOffPaymentByCustomer", Description = "Cancel Once Off payment by introducer id")]
        public string CancelFacilityAccountOnceOffPaymentByCustomer(string InstallationID, string soapusername, string soappassword,
            string CustomerID, string FacilityNo, string AccountNo, string PaymentID)
        {
            try
            {
                CustomerBiz oBiz = new CustomerBiz(InstallationID, soapusername, soappassword, CustomerID, FacilityNo, AccountNo);

                FacilityByCustomerDAL fdal = new FacilityByCustomerDAL();
                fdal.CancelFacilityAccountOnceOffPaymentByCustomer(
                    oBiz.InstallationID, oBiz.CustomerID, oBiz.AccountFacilityID.Value, oBiz.AccountID.Value,
                    Convert.ToInt64(PaymentID));

                DataSet myDataSet = fdal.GetFacilityAccountOnceOffPaymentListByCustomer(
                                   oBiz.InstallationID, oBiz.CustomerID, oBiz.AccountFacilityID.Value, oBiz.AccountID.Value);

                return myDataSet.GetXml();
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml(ex.Message.ToString()) + "</error>";
            }
        }

        [WebMethod(MessageName = "GetFacilityAccountStandardPaymentByCustomer", Description = "GetFacilityAccountStandardPaymentByCustomer")]
        public string GetFacilityAccountStandardPaymentByCustomer(string InstallationID, string soapusername, string soappassword,
            string CustomerID, string FacilityNo, string AccountNo)
        {
            try
            {
                CustomerBiz oBiz = new CustomerBiz(InstallationID, soapusername, soappassword, CustomerID, FacilityNo, AccountNo);

                FacilityByCustomerDAL fdal = new FacilityByCustomerDAL();
                DataSet myDataSet = fdal.GetFacilityAccountStandardPaymentByCustomer(
                                   oBiz.InstallationID, oBiz.CustomerID, oBiz.AccountFacilityID.Value, oBiz.AccountID.Value);

                return myDataSet.GetXml();
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml(ex.Message.ToString()) + "</error>";
            }
        }

        [WebMethod(MessageName = "CalculateAccountNewRepaymentByCustomer", Description = "recalculate account repayment by introducer id")]
        public string CalculateAccountNewRepaymentByCustomer(string InstallationID, string soapusername, string soappassword,
            string CustomerID, string FacilityNo, string AccountNo, string Newrepaymentdate, string NewRepaymentfrequency)
        {
            try
            {
                CustomerBiz oBiz = new CustomerBiz(InstallationID, soapusername, soappassword, CustomerID, FacilityNo, AccountNo);

                DateTime newrepaymentdate = Convert.ToDateTime(Newrepaymentdate);

                FacilityByCustomerDAL fdal = new FacilityByCustomerDAL();
                DataSet myDataSet = fdal.CalculateAccountNewRepaymentByCustomer(
                                   oBiz.InstallationID, oBiz.CustomerID, oBiz.AccountFacilityID.Value, oBiz.AccountID.Value, newrepaymentdate, NewRepaymentfrequency);

                return myDataSet.GetXml();
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml(ex.Message.ToString()) + "</error>";
            }
        }

        [WebMethod(MessageName = "GetAccountRegularRepaymentListByCustomer", Description = "Get Account Regular RepaymentListByIntroducer by introducer id")]
        public string GetAccountRegularRepaymentListByCustomer(string InstallationID, string soapusername, string soappassword,
            string CustomerID, string FacilityNo, string AccountNo)
        {
            try
            {
                CustomerBiz oBiz = new CustomerBiz(InstallationID, soapusername, soappassword, CustomerID, FacilityNo, AccountNo);

                FacilityByCustomerDAL fdal = new FacilityByCustomerDAL();
                DataSet myDataSet = fdal.GetAccountRegularRepaymentListByCustomer(
                                   oBiz.InstallationID, oBiz.CustomerID, oBiz.AccountFacilityID.Value, oBiz.AccountID.Value);

                return myDataSet.GetXml();
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml(ex.Message.ToString()) + "</error>";
            }
        }

        [WebMethod(MessageName = "ApplyAccountNewRepaymentByCustomer", Description = "apply account repayment by introducer id")]
        public string ApplyAccountNewRepaymentByCustomer(string InstallationID, string soapusername, string soappassword,
            string CustomerID, string FacilityNo, string AccountNo,
            string Newrepaymentdate, string NewRepaymentfrequency, string NewMinPaymentAmount, string NewNominateAmount, string NewAdditionalAmount)
        {
            try
            {
                CustomerBiz oBiz = new CustomerBiz(InstallationID, soapusername, soappassword, CustomerID, FacilityNo, AccountNo);

                DateTime newrepaymentdate = Convert.ToDateTime(Newrepaymentdate);
                Decimal newMinPaymentAmount = Convert.ToDecimal(NewMinPaymentAmount);
                Decimal? newNominateAmount = null;
                if (NewNominateAmount != "") newNominateAmount = Convert.ToDecimal(NewNominateAmount);
                Decimal newAdditionalAmount = Convert.ToDecimal(NewAdditionalAmount);

                FacilityByCustomerDAL fdal = new FacilityByCustomerDAL();
                DataSet myDataSet = fdal.ApplyAccountNewRepaymentByCustomer(
                                   oBiz.InstallationID, oBiz.CustomerID, oBiz.AccountFacilityID.Value, oBiz.AccountID.Value,
                                   newrepaymentdate, NewRepaymentfrequency, newMinPaymentAmount, newNominateAmount, newAdditionalAmount);

                return myDataSet.GetXml();
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml(ex.Message.ToString()) + "</error>";
            }
        }

        [WebMethod(MessageName = "AccountTransferProcessTransferByCustomer", Description = "Process Account transfer from / to account By introducer id")]
        public string AccountTransferProcessTransferByCustomer(string InstallationID, string soapusername, string soappassword,
            string CustomerID, string FacilityNo, string FromAccountNo, string ToAccountNo, string TransferAmount)
        {
            try
            {
                CustomerBiz oBiz = new CustomerBiz(InstallationID, soapusername, soappassword, CustomerID, FacilityNo, FromAccountNo);
                Int64 toAccountNo = Convert.ToInt64(ToAccountNo);
                Decimal transferAmount = Convert.ToDecimal(TransferAmount);

                FacilityByCustomerDAL fdal = new FacilityByCustomerDAL();
                DataSet myDataSet = fdal.AccountTransferProcessTransferByCustomer(
                                   oBiz.InstallationID, oBiz.CustomerID, oBiz.AccountFacilityID.Value,
                                   oBiz.AccountID.Value, toAccountNo, transferAmount);

                return myDataSet.GetXml();
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml(ex.Message.ToString()) + "</error>";
            }
        }

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

        [WebMethod(MessageName = "GetFacilityAccountRedrawByCustomer", Description = "Return facility accounts searched by customer id as XML DataSet")]
        public string GetFacilityAccountRedrawByCustomer(string InstallationID, string soapusername, string soappassword,
            string CustomerID, string FacilityNo, string AccountNo)
        {
            try
            {
                CustomerBiz oBiz = new CustomerBiz(InstallationID, soapusername, soappassword, CustomerID, FacilityNo, AccountNo);

                DataSet myDataSet = (new FacilityByCustomerDAL()).GetFacilityAccountRedrawByCustomer(
                    oBiz.InstallationID, oBiz.CustomerID, oBiz.AccountFacilityID.Value, oBiz.AccountID.Value);
                return myDataSet.GetXml();
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml(ex.Message.ToString()) + "</error>";
            }
        }

        [WebMethod(MessageName = "SaveRedrawByCustomer", Description = "Save Once Off payment by introducer id")]
        public string SaveRedrawByCustomer(string InstallationID, string soapusername, string soappassword,
            string CustomerID, string FacilityNo, string AccountNo, string RedrawtDate, string RedrawAmount)
        {
            try
            {
                CustomerBiz oBiz = new CustomerBiz(InstallationID, soapusername, soappassword, CustomerID, FacilityNo, AccountNo);

                DateTime redrawDate = Convert.ToDateTime(RedrawtDate);
                Decimal redrawamount = Convert.ToDecimal(RedrawAmount);
                FacilityByCustomerDAL fdal = new FacilityByCustomerDAL();
                fdal.SaveFacilityRedrawByCustomer(
                    oBiz.InstallationID, oBiz.CustomerID, oBiz.AccountFacilityID.Value, oBiz.AccountID.Value, redrawDate, redrawamount);

                DataSet myDataSet = fdal.GetFacilityAccountRedrawByCustomer(
                                   oBiz.InstallationID, oBiz.CustomerID, oBiz.AccountFacilityID.Value, oBiz.AccountID.Value);

                return myDataSet.GetXml();
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml(ex.Message.ToString()) + "</error>";
            }
        }


        [WebMethod(MessageName = "CancelRedrawByCustomer", Description = "Cancel Once Off payment by introducer id")]
        public string CancelRedrawByCustomer(string InstallationID, string soapusername, string soappassword,
            string CustomerID, string FacilityNo, string AccountNo, string PaymentID)
        {
            try
            {
                CustomerBiz oBiz = new CustomerBiz(InstallationID, soapusername, soappassword, CustomerID, FacilityNo, AccountNo);

                FacilityByCustomerDAL fdal = new FacilityByCustomerDAL();
                fdal.CancelRedrawByCustomer(
                    oBiz.InstallationID, oBiz.CustomerID, oBiz.AccountFacilityID.Value, oBiz.AccountID.Value,
                    Convert.ToInt64(PaymentID));

                DataSet myDataSet = fdal.GetFacilityAccountRedrawByCustomer(
                                   oBiz.InstallationID, oBiz.CustomerID, oBiz.AccountFacilityID.Value, oBiz.AccountID.Value);

                return myDataSet.GetXml();
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml(ex.Message.ToString()) + "</error>";
            }
        }

        [WebMethod(MessageName = "GetBorrowerRateHistoryByCustomer", Description = "Return borrower rate history searched by customer id as XML DataSet")]
        public string GetBorrowerRateHistoryByCustomer(string InstallationID, string soapusername, string soappassword,
            string CustomerID, string FacilityNo, string AccountNo)
        {
            try
            {
                CustomerBiz oBiz = new CustomerBiz(InstallationID, soapusername, soappassword, CustomerID, FacilityNo, AccountNo);

                DataSet myDataSet = (new FacilityByCustomerDAL()).GetBorrowerRateHistoryByCustomer(
                    oBiz.InstallationID, oBiz.CustomerID, oBiz.AccountFacilityID.Value, oBiz.AccountID.Value);
                return myDataSet.GetXml();
            }
            catch (Exception ex)
            {
                return "<error>" + LWTSafeTypes.SafeXml(ex.Message.ToString()) + "</error>";
            }
        }


        private string GetFormatDate(string CustomerDOB)
		{

            string val1 = "/";
            string val2 = "-";

            if ((!CustomerDOB.Contains(val1)) && (!CustomerDOB.Contains(val2)))
            {
                if (CustomerDOB.Length != 6)
                {
                    CustomerDOB = CustomerDOB.Substring(0, 2) + "-" + CustomerDOB.Substring(2, 2) + "-" + CustomerDOB.Substring(4, 4);
                }
                else
                {
                    CustomerDOB = "0"+CustomerDOB.Substring(0, 1) + "-" +"0"+CustomerDOB.Substring(1, 1) + "-" + CustomerDOB.Substring(2, 4);
                }
            }

            return CustomerDOB;
		}

        private string defaultVal(string id)
        {

            if (id.Length == 0)
            {
                id = "0";
            }
            else if(id.Length == 6)
            {

            }
            return id;
        }






	}


}
