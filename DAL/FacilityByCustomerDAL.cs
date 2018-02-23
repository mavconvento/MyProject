using System;
using System.Collections.Generic;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;

using System.Data.Common;
using System.Data;
using System.Data.SqlClient;

using LWT.Common.DAL;
using LWT.Common;
//{1}{108.54} Pewee 23/6/2015  Add View Loan (Facility) Details, View Borrower and Guarantor’s  Details ,View Portion (Account) Details
                //View statements for any period, Generate statements for any period (by selecting a date range) ,Set up ongoing direct debits, change frequency of repayments and increase/decrease repayments
                //Set up additional once off payments, Set up redraws, Have access to  rate history  Just the Borrower Rate history ,View list of current transactions, Transfer Funds between accounts
//{2}{108.541} 6/8/2015 Pewee Add FacilityID
namespace WCFWebService
{
    public class FacilityByCustomerDAL : BaseDAL
    {

        #region Variables
        private Database database = LWTDatabase.GetInstance().GetDatabase(CommonConstants.DATABASE_NAME);
        #endregion Variables
        /*===================================FORGOT PASSWORD SECTION==================================*/
        public DataSet ValidateCustomer(Int64 InstallationID, Int64 CustomerID, DateTime CustomerDOB,  Int64 AccountFacilityID, Int64 AccountNo)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsCustomerPortalValidateCustomer");

                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@PortalLogin", DbType.Int32, CustomerID);
                database.AddInParameter(DbCommand, "@DateofBirth", DbType.DateTime, CustomerDOB);
                database.AddInParameter(DbCommand, "@AccountID", DbType.Int32, AccountNo);
                database.AddInParameter(DbCommand, "@FacilityID", DbType.Int32, AccountFacilityID);

                return InternalExecuteDataSet(database, DbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet StoreCustomerSecurityQuestion(Int64 InstallationID, Int64 CustomerID, DateTime CustomerDOB, Int64 AccountFacilityID, Int64 AccountNo,
                 string SecurityQuestion, string SecurityAnswer)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsCustomerPortal_CustomerSecurityQuestionSave");

                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@PortalLogin", DbType.Int32, CustomerID);
                database.AddInParameter(DbCommand, "@DateofBirth", DbType.DateTime, CustomerDOB);
                database.AddInParameter(DbCommand, "@AccountID", DbType.Int32, AccountNo);
                database.AddInParameter(DbCommand, "@AccountFacilityID", DbType.Int32, AccountFacilityID);
                database.AddInParameter(DbCommand, "@SecurityQuestion", DbType.String, SecurityQuestion);
                database.AddInParameter(DbCommand, "@SecurityAnswer", DbType.String, SecurityAnswer);

                return InternalExecuteDataSet(database, DbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetSecurityQuestion(Int64 InstallationID, Int64 CustomerID, DateTime CustomerDOB, Int64 AccountFacilityID, Int64 AccountNo)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsCustomerPortalGetSecQuestion");

                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@PortalLogin", DbType.Int32, CustomerID);
                database.AddInParameter(DbCommand, "@CustomerDOB", DbType.DateTime, CustomerDOB);
                database.AddInParameter(DbCommand, "@AccountID", DbType.Int32, AccountNo);
                database.AddInParameter(DbCommand, "@FacilityID", DbType.Int32, AccountFacilityID);

                return InternalExecuteDataSet(database, DbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ValidateSecurityQuestion(Int64 InstallationID, Int64 CustomerID, DateTime CustomerDOB, Int64 AccountFacilityID, Int64 AccountNo, String SecurityAnswer)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsCustomerPortalCheckSecurityAnswer");

                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@PortalLogin", DbType.Int32, CustomerID);
                database.AddInParameter(DbCommand, "@CustomerDOB", DbType.DateTime, CustomerDOB);
                database.AddInParameter(DbCommand, "@AccountID", DbType.Int32, AccountNo);
                database.AddInParameter(DbCommand, "@FacilityID", DbType.Int32, AccountFacilityID);
                database.AddInParameter(DbCommand, "@SecurityAnswer", DbType.String, SecurityAnswer);

                return InternalExecuteDataSet(database, DbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*--------------Get Email/Phone if exist------------------*/
        public DataSet GetCustomerDetails(Int64 CustomerID)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsCustomerPortalGetDetails");
                database.AddInParameter(DbCommand, "@CustID", DbType.Int32, CustomerID);
                return InternalExecuteDataSet(database, DbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetEmailMobile(Int64 InstallationID, Int64 CustomerID, DateTime CustomerDOB, Int64 AccountFacilityID, Int64 AccountNo)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsCustomerPortalCheckEmailMobile");
                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@PortalLogin", DbType.Int32, CustomerID);
                database.AddInParameter(DbCommand, "@CustomerDOB", DbType.DateTime, CustomerDOB);
                database.AddInParameter(DbCommand, "@AccountID", DbType.Int32, AccountNo);
                database.AddInParameter(DbCommand, "@FacilityID", DbType.Int32, AccountFacilityID);
               // database.AddInParameter(DbCommand, "@SecurityAnswer", DbType.String, SecurityAnswer);
                return InternalExecuteDataSet(database, DbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SubmitForgotPassword(Int64 InstallationID, Int64 CustomerID, String OriginPage, DateTime CustomerDOB, Int64 AccountFacilityID,
            Int64 AccountNo, String SecurityAnswer, String Email)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsCustomerPortalForgotLoginSubmit");
                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@OriginPage", DbType.String, OriginPage);
                database.AddInParameter(DbCommand, "@SecurityAnswer", DbType.String, SecurityAnswer);
                database.AddInParameter(DbCommand, "@PortalLogin", DbType.String, CustomerID);
                database.AddInParameter(DbCommand, "@CustomerDOB", DbType.DateTime, CustomerDOB);
                database.AddInParameter(DbCommand, "@AccountID", DbType.Int64, AccountNo);
                database.AddInParameter(DbCommand, "@FacilityID", DbType.Int32, AccountFacilityID);
                database.AddInParameter(DbCommand, "@Email", DbType.String, Email);
                database.AddInParameter(DbCommand, "@Mobile", DbType.String, "" );
                return InternalExecuteDataSet(database, DbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*===========================CHANGE PASSWORD SECTION=======================================*/


        public DataSet SubmitChangePassword(Int64 InstallationID, Int64 CustomerID, String OriginPage, DateTime CustomerDOB, Int64 AccountFacilityID, Int64 AccountNo,
            String CurrentPassword, String NewPassword, String TranType)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsCustomerPortalSetCustomerPassword");
                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@OriginPage", DbType.String, OriginPage);
                database.AddInParameter(DbCommand, "@PortalLogin", DbType.String, CustomerID);
                database.AddInParameter(DbCommand, "@CustomerDOB", DbType.DateTime, CustomerDOB);
                database.AddInParameter(DbCommand, "@AccountID", DbType.Int64, AccountNo);
                database.AddInParameter(DbCommand, "@FacilityID", DbType.Int32, AccountFacilityID);
                database.AddInParameter(DbCommand, "@CurrentPassword", DbType.String, CurrentPassword);
                database.AddInParameter(DbCommand, "@Password", DbType.String, NewPassword);
                database.AddInParameter(DbCommand, "@TranType", DbType.String, TranType);
                return InternalExecuteDataSet(database, DbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void CustomerAcceptTermsAndConditions(Int64 InstallationID, Int64 CustomerID)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsCustomerPortalCustomerAcceptTermCondition");
                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@Custid", DbType.String, CustomerID);

                InternalExecuteNonQuery(database, DbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*===========================POST SETTLEMENT SECTION=======================================*/

        public DataSet GetFacilityAccountListByCustomer(Int64 InstallationID, Int64 CustomerID)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsCustomerPortal_GetAccountsByCustomer");

                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@CustomerID", DbType.Int32, CustomerID);

                return InternalExecuteDataSet(database, DbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAccountDetailByCustomer(Int64 InstallationID, Int64 CustomerID, Int64 FacilityNo, Int64 AccountNo)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsCustomerPortal_GetAccountDetailsByCustomerID");

                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@CustomerID", DbType.Int32, CustomerID);
                database.AddInParameter(DbCommand, "@AccountFacilityID", DbType.Int64, FacilityNo);
                database.AddInParameter(DbCommand, "@AccountID", DbType.Int64, AccountNo);

                return InternalExecuteDataSet(database, DbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAccountTransactionsByCustomer(Int64 InstallationID, Int64 CustomerID, Int64 FacilityNo, Int64 AccountID)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsCustomerPortal_GetAccountTransactionsByCustomer");

                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@CustomerID", DbType.Int32, CustomerID);
                database.AddInParameter(DbCommand, "@AccountFacilityID", DbType.Int64, FacilityNo);
                database.AddInParameter(DbCommand, "@AccountID", DbType.Int64, AccountID);

                return InternalExecuteDataSet(database, DbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetBorrowerDetailByCustomer(Int64 InstallationID, Int64 CustomerID, Int64 FacilityNo)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsCustomerPortal_GetBorrowerDetailsByCustomer");

                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@CustomerID", DbType.Int32, CustomerID);
                database.AddInParameter(DbCommand, "@AccountFacilityID", DbType.Int64, FacilityNo);

                return InternalExecuteDataSet(database, DbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetSecurityDetailByCustomer(Int64 InstallationID, Int64 CustomerID, Int64 FacilityNo)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsCustomerPortal_GetSecurityDetailsByCustomerID");

                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@CustomerID", DbType.Int32, CustomerID);
                database.AddInParameter(DbCommand, "@AccountFacilityID", DbType.Int64, FacilityNo);

                return InternalExecuteDataSet(database, DbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAccountStatementListByCustomer(Int64 InstallationID, Int64 CustomerID, Int64 FacilityNo, Int64 AccountNo, DateTime StartDate, DateTime EndDate)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsCustomerPortal_GetStatementByCustomerID");

                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@CustomerID", DbType.Int32, CustomerID);
                database.AddInParameter(DbCommand, "@AccountFacilityID", DbType.Int64, FacilityNo);
                database.AddInParameter(DbCommand, "@AccountID", DbType.Int64, AccountNo);
                database.AddInParameter(DbCommand, "@StartDate", DbType.DateTime, StartDate);
                database.AddInParameter(DbCommand, "@EndDate", DbType.DateTime, EndDate);

                return InternalExecuteDataSet(database, DbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet AccountTransferGetAccountDetailByCustomer(Int64 InstallationID, Int64 CustomerID, Int64 FacilityNo, Int64 AccountID)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsCustomerPortal_AccountTransfer_GetAccountDetailsByCustomerID");

                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@CustomerID", DbType.Int32, CustomerID);
                database.AddInParameter(DbCommand, "@AccountFacilityID", DbType.Int64, FacilityNo);
                database.AddInParameter(DbCommand, "@AccountID", DbType.Int64, AccountID);

                return InternalExecuteDataSet(database, DbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet GetFacilityAccountOnceOffPaymentListByCustomer(Int64 InstallationID, Int64 CustomerID, Int64 FacilityNo, Int64 AccountNo)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsCustomerPortal_Account_OnceOffPaymentListGetByCustomerID");

                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@CustomerID", DbType.Int32, CustomerID);
                database.AddInParameter(DbCommand, "@AccountFacilityID", DbType.Int64, FacilityNo);
                database.AddInParameter(DbCommand, "@AccountID", DbType.Int64, AccountNo);

                return InternalExecuteDataSet(database, DbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveFacilityAccountOnceOffPaymentByCustomer(Int64 InstallationID, Int64 CustomerID, Int64 FacilityNo, Int64 AccountNo, DateTime PaymentDate, decimal PaymentAmount)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsCustomerPortal_Account_OnceOffPaymentSaveByCustomerID");

                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@CustomerID", DbType.Int32, CustomerID);
                database.AddInParameter(DbCommand, "@AccountFacilityID", DbType.Int64, FacilityNo);
                database.AddInParameter(DbCommand, "@AccountID", DbType.Int64, AccountNo);
                database.AddInParameter(DbCommand, "@PaymentDate", DbType.DateTime, PaymentDate);
                database.AddInParameter(DbCommand, "@PaymentAmount", DbType.Decimal, PaymentAmount);

                InternalExecuteNonQuery(database, DbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CancelFacilityAccountOnceOffPaymentByCustomer(Int64 InstallationID, Int64 CustomerID, Int64 FacilityNo, Int64 AccountID, Int64 RepaymentID)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsCustomerPortal_Account_OnceOffPaymentCancelByCustomerID");

                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@CustomerID", DbType.Int32, CustomerID);
                database.AddInParameter(DbCommand, "@AccountFacilityID", DbType.Int64, FacilityNo);
                database.AddInParameter(DbCommand, "@AccountID", DbType.Int64, AccountID);
                database.AddInParameter(DbCommand, "@RepaymentID", DbType.Int64, RepaymentID);

                InternalExecuteNonQuery(database, DbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetFacilityAccountStandardPaymentByCustomer(Int64 InstallationID, Int64 CustomerID, Int64 FacilityNo, Int64 AccountID)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsCustomerPortal_Account_standardpayment_GetByCustomerID");

                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@CustomerID", DbType.Int32, CustomerID);
                database.AddInParameter(DbCommand, "@AccountFacilityID", DbType.Int64, FacilityNo);
                database.AddInParameter(DbCommand, "@AccountID", DbType.Int64, AccountID);

                return InternalExecuteDataSet(database, DbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet CalculateAccountNewRepaymentByCustomer(Int64 InstallationID, Int64 CustomerID, Int64 FacilityNo, Int64 AccountID, DateTime newrepaymentdate, string newrepaymentfrequency)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsCustomerPortal_Account_calculatestandardpaymentByCustomerID");

                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@CustomerID", DbType.Int32, CustomerID);
                database.AddInParameter(DbCommand, "@AccountFacilityID", DbType.Int64, FacilityNo);
                database.AddInParameter(DbCommand, "@AccountID", DbType.Int64, AccountID);

                database.AddInParameter(DbCommand, "@newrepaymentdate", DbType.DateTime, newrepaymentdate);
                database.AddInParameter(DbCommand, "@newrepaymentfrequency", DbType.String, newrepaymentfrequency);

                return InternalExecuteDataSet(database, DbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAccountRegularRepaymentListByCustomer(Int64 InstallationID, Int64 CustomerID, Int64 FacilityNo, Int64 AccountID)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsCustomerPortal_Account_getstandardpaymentlist_GetByCustomerID");

                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@CustomerID", DbType.Int32, CustomerID);
                database.AddInParameter(DbCommand, "@AccountFacilityID", DbType.Int64, FacilityNo);
                database.AddInParameter(DbCommand, "@AccountID", DbType.Int64, AccountID);

                return InternalExecuteDataSet(database, DbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ApplyAccountNewRepaymentByCustomer(Int64 InstallationID, Int64 CustomerID, Int64 FacilityNo, Int64 AccountID, DateTime newrepaymentdate, string newrepaymentfrequency,
           decimal newMinPaymentAmount, decimal? newNominateAmount, decimal newAdditionalAmount)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsCustomerPortal_Account_applystandardpaymentByCustomerID");

                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@CustomerID", DbType.Int32, CustomerID);
                database.AddInParameter(DbCommand, "@AccountFacilityID", DbType.Int64, FacilityNo);
                database.AddInParameter(DbCommand, "@AccountID", DbType.Int64, AccountID);

                database.AddInParameter(DbCommand, "@newrepaymentdate", DbType.DateTime, newrepaymentdate);
                database.AddInParameter(DbCommand, "@newrepaymentfrequency", DbType.String, newrepaymentfrequency);
                database.AddInParameter(DbCommand, "@NewMinPaymentAmount", DbType.Decimal, newMinPaymentAmount);
                if (newNominateAmount.HasValue)
                    database.AddInParameter(DbCommand, "@newNominateAmount", DbType.Decimal, newNominateAmount.Value);
                else
                    database.AddInParameter(DbCommand, "@newNominateAmount", DbType.Decimal, DBNull.Value);


                database.AddInParameter(DbCommand, "@newAdditionalAmount", DbType.Decimal, newAdditionalAmount);

                return InternalExecuteDataSet(database, DbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet AccountTransferProcessTransferByCustomer(Int64 InstallationID, Int64 CustomerID,
           Int64 FacilityNo, Int64 FromAccountID, Int64 ToAccountID, decimal TransferAmount)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsCustomerPortal_AccountTransfer_Process_ByCustomerID");

                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@CustomerID", DbType.Int32, CustomerID);
                database.AddInParameter(DbCommand, "@AccountFacilityID", DbType.Int64, FacilityNo);
                database.AddInParameter(DbCommand, "@FromAccountID", DbType.Int64, FromAccountID);
                database.AddInParameter(DbCommand, "@ToAccountID", DbType.Int64, ToAccountID);
                database.AddInParameter(DbCommand, "@TransferAmount", DbType.Decimal, TransferAmount);

                return InternalExecuteDataSet(database, DbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet GetFacilityAccountRedrawByCustomer(Int64 InstallationID, Int64 CustomerID, Int64 FacilityNo, Int64 AccountNo)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsCustomerPortal_Account_RedrawListGetByCustomerID");

                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@CustomerID", DbType.Int32, CustomerID);
                database.AddInParameter(DbCommand, "@AccountFacilityID", DbType.Int64, FacilityNo);
                database.AddInParameter(DbCommand, "@AccountID", DbType.Int64, AccountNo);

                return InternalExecuteDataSet(database, DbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveFacilityRedrawByCustomer(Int64 InstallationID, Int64 CustomerID, Int64 FacilityNo, Int64 AccountNo, DateTime RedrawDate, decimal RedrawAmount)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsCustomerPortal_Account_RedrawSaveByCustomerID");

                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@CustomerID", DbType.Int32, CustomerID);
                database.AddInParameter(DbCommand, "@AccountFacilityID", DbType.Int64, FacilityNo);
                database.AddInParameter(DbCommand, "@AccountID", DbType.Int64, AccountNo);
                database.AddInParameter(DbCommand, "@RedrawDate", DbType.DateTime, RedrawDate);
                database.AddInParameter(DbCommand, "@RedrawAmount", DbType.Decimal, RedrawAmount);

                InternalExecuteNonQuery(database, DbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CancelRedrawByCustomer(Int64 InstallationID, Int64 CustomerID, Int64 FacilityNo, Int64 AccountID, Int64 RepaymentID)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsCustomerPortal_Account_RedrawDeleteByCustomerID");

                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@CustomerID", DbType.Int32, CustomerID);
                database.AddInParameter(DbCommand, "@AccountFacilityID", DbType.Int64, FacilityNo);
                database.AddInParameter(DbCommand, "@AccountID", DbType.Int64, AccountID);
                database.AddInParameter(DbCommand, "@RedrawID", DbType.Int64, RepaymentID);

                InternalExecuteNonQuery(database, DbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetBorrowerRateHistoryByCustomer(Int64 InstallationID, Int64 CustomerID, Int64 FacilityNo, Int64 AccountNo)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsCustomerPortal_Account_GetBorrowerRateByCustomerID");

                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@CustomerID", DbType.Int32, CustomerID);
                database.AddInParameter(DbCommand, "@AccountFacilityID", DbType.Int64, FacilityNo);
                database.AddInParameter(DbCommand, "@AccountID", DbType.Int64, AccountNo);

                return InternalExecuteDataSet(database, DbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}