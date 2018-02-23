using System;
using System.Collections.Generic;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;

using System.Data.Common;
using System.Data;
using System.Data.SqlClient;

using LWT.Common.DAL;
using LWT.Common;

namespace WCFWebService
{
    public class FacilityDAL : BaseDAL
    {

        #region Variables
		private Database database = LWTDatabase.GetInstance().GetDatabase( CommonConstants.DATABASE_NAME);
        #endregion Variables



        public DataSet AccountUpdateDDRByIntroducer(int InstallationID, int IntroducerID,
            Int64 FacilityNo, Int64 AccountID,
            string DDRBSB, string DDRAccountNumber, string DDRAccountName, string DDRInstitution)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsOriginatorPortal_Account_DDR_Update_ByIntroducer");

                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@IntroducerID", DbType.Int32, IntroducerID);
                database.AddInParameter(DbCommand, "@AccountFacilityID", DbType.Int64, FacilityNo);
                database.AddInParameter(DbCommand, "@AccountID", DbType.Int64, AccountID);
                database.AddInParameter(DbCommand, "@DDRBSB", DbType.String, DDRBSB );
                database.AddInParameter(DbCommand, "@DDRAccountNumber", DbType.String, DDRAccountNumber );
                database.AddInParameter(DbCommand, "@DDRAccountName", DbType.String, DDRAccountName );
                database.AddInParameter(DbCommand, "@DDRInstitution", DbType.String, DDRInstitution);

                return InternalExecuteDataSet(database, DbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet AccountTransferProcessTransferByIntroducer(int InstallationID, int IntroducerID,
            Int64 FacilityNo, Int64 FromAccountID, Int64 ToAccountID, decimal TransferAmount)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsOriginatorPortal_AccountTransfer_Process_ByIntroducer");

                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@IntroducerID", DbType.Int32, IntroducerID);
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

        public DataSet AccountTransferGetAccountDetailByIntroducer(int InstallationID, int IntroducerID,
            Int64 FacilityNo, Int64 AccountID )
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsOriginatorPortal_AccountTransfer_GetAccountDetailsByIntroducer");

                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@IntroducerID", DbType.Int32, IntroducerID);
                database.AddInParameter(DbCommand, "@AccountFacilityID", DbType.Int64, FacilityNo);
                database.AddInParameter(DbCommand, "@AccountID", DbType.Int64, AccountID);

                return InternalExecuteDataSet(database, DbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ApplyAccountNewRepaymentByIntroducer(int InstallationID, int IntroducerID,
            Int64 FacilityNo, Int64 AccountID, DateTime newrepaymentdate, string newrepaymentfrequency,
            decimal newMinPaymentAmount, decimal? newNominateAmount, decimal newAdditionalAmount)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsOriginatorPortal_Account_applystandardpaymentByIntroducer");

                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@IntroducerID", DbType.Int32, IntroducerID);
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

        public DataSet CalculateAccountNewRepaymentByIntroducer(int InstallationID, int IntroducerID,
            Int64 FacilityNo, Int64 AccountID, DateTime newrepaymentdate, string newrepaymentfrequency)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsOriginatorPortal_Account_calculatestandardpaymentByIntroducer");

                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@IntroducerID", DbType.Int32, IntroducerID);
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

        public DataSet GetAccountRegularRepaymentListByIntroducer(int InstallationID, int IntroducerID,
            Int64 FacilityNo, Int64 AccountID)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsOriginatorPortal_Account_getstandardpaymentlist_GetByIntroducer");

                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@IntroducerID", DbType.Int32, IntroducerID);
                database.AddInParameter(DbCommand, "@AccountFacilityID", DbType.Int64, FacilityNo);
                database.AddInParameter(DbCommand, "@AccountID", DbType.Int64, AccountID);

                return InternalExecuteDataSet(database, DbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetFacilityAccountStandardPaymentByIntroducer(int InstallationID, int IntroducerID,
            Int64 FacilityNo, Int64 AccountID)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsOriginatorPortal_Account_standardpayment_GetByIntroducer");

                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@IntroducerID", DbType.Int32, IntroducerID);
                database.AddInParameter(DbCommand, "@AccountFacilityID", DbType.Int64, FacilityNo);
                database.AddInParameter(DbCommand, "@AccountID", DbType.Int64, AccountID);

                return InternalExecuteDataSet(database, DbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CancelFacilityAccountOnceOffPaymentByIntroducer(int InstallationID, int IntroducerID,
            Int64 FacilityNo, Int64 AccountID, Int64 RepaymentID)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsOriginatorPortal_Account_OnceOffPaymentCancelByIntroducer");

                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@IntroducerID", DbType.Int32, IntroducerID);
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

        public void SaveFacilityAccountOnceOffPaymentByIntroducer(int InstallationID, int IntroducerID,
            Int64 FacilityNo, Int64 AccountNo, DateTime PaymentDate, decimal PaymentAmount)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsOriginatorPortal_Account_OnceOffPaymentSaveByIntroducer");

                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@IntroducerID", DbType.Int32, IntroducerID);
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
        
        public DataSet GetFacilityAccountOnceOffPaymentListByIntroducer(int InstallationID, int IntroducerID,
            Int64 FacilityNo, Int64 AccountNo )
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsOriginatorPortal_Account_OnceOffPaymentListGetByIntroducer");

                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@IntroducerID", DbType.Int32, IntroducerID);
                database.AddInParameter(DbCommand, "@AccountFacilityID", DbType.Int64, FacilityNo);
                database.AddInParameter(DbCommand, "@AccountID", DbType.Int64, AccountNo);

                return InternalExecuteDataSet(database, DbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetFacilityAccountListByIntroducer(int InstallationID, int IntroducerID,
            Int64? FacilityNo, Int64? AccountNo, 
			string borrowerFirstName,  string borrowerLastName,string companyTrustName,
            string streetNo, string streetName, string suburb, string state, string postcode)
		{
			try
			{
				DbCommand DbCommand = database.GetStoredProcCommand("lmsOriginatorPortal_GetAccountsByIntroducer");

				database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID );
				database.AddInParameter(DbCommand, "@IntroducerID", DbType.Int32,  IntroducerID);

				if (FacilityNo.HasValue)
                    database.AddInParameter(DbCommand, "@FacilityID", DbType.Int64, FacilityNo);
				else
                    database.AddInParameter(DbCommand, "@FacilityID", DbType.Int64, DBNull.Value);

				if (AccountNo.HasValue)
                    database.AddInParameter(DbCommand, "@AccountID", DbType.Int64, AccountNo);
				else
                    database.AddInParameter(DbCommand, "@AccountID", DbType.Int64, DBNull.Value);

				database.AddInParameter(DbCommand, "@borrowerFirstName", DbType.String, borrowerFirstName);
				database.AddInParameter(DbCommand, "@borrowerLastName", DbType.String, borrowerLastName);
                database.AddInParameter(DbCommand, "@companyTradeName", DbType.String, companyTrustName);

                database.AddInParameter(DbCommand, "@securitystreetNo", DbType.String, streetNo);
                database.AddInParameter(DbCommand, "@securitystreetName", DbType.String, streetName);
                database.AddInParameter(DbCommand, "@securitysuburb", DbType.String, suburb);
                database.AddInParameter(DbCommand, "@securitystate", DbType.String, state);
                database.AddInParameter(DbCommand, "@securitypostcode", DbType.String, postcode);                
				
				return InternalExecuteDataSet(database, DbCommand, null);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        public DataSet GetAccountDetailByIntroducer(int InstallationID, int IntroducerID, Int64 FacilityNo, Int64 AccountNo)
		{
			try
			{
				DbCommand DbCommand = database.GetStoredProcCommand("lmsOriginatorPortal_GetAccountDetailsByIntroducer");

				database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
				database.AddInParameter(DbCommand, "@IntroducerID", DbType.Int32, IntroducerID);
                database.AddInParameter(DbCommand, "@AccountFacilityID", DbType.Int64, FacilityNo);
                database.AddInParameter(DbCommand, "@AccountID", DbType.Int64, AccountNo);

				return InternalExecuteDataSet(database, DbCommand, null);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        public DataSet GetAccountInterestRateHistoryByAccount(int InstallationID, int IntroducerID, Int64 FacilityNo, Int64 AccountNo)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsOriginatorPortal_GetRaceHistoryByID");

                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@IntroducerID", DbType.Int32, IntroducerID);
                database.AddInParameter(DbCommand, "@AccountFacilityID", DbType.Int64, FacilityNo);
                database.AddInParameter(DbCommand, "@AccountID", DbType.Int64, AccountNo);

                return InternalExecuteDataSet(database, DbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetBorrowerDetailByIntroducer(int InstallationID, int IntroducerID, Int64 FacilityNo)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsOriginatorPortal_GetBorrowerDetailsByIntroducer");

                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@IntroducerID", DbType.Int32, IntroducerID);
                database.AddInParameter(DbCommand, "@AccountFacilityID", DbType.Int64, FacilityNo);

                return InternalExecuteDataSet(database, DbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAccountTransactionsByIntroducer(int InstallationID, int IntroducerID, Int64 FacilityNo, Int64 AccountID)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsOriginatorPortal_GetAccountTransactionsByIntroducer");

                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32,InstallationID);
                database.AddInParameter(DbCommand, "@IntroducerID", DbType.Int32, IntroducerID);
                database.AddInParameter(DbCommand, "@AccountFacilityID", DbType.Int64, FacilityNo);
                database.AddInParameter(DbCommand, "@AccountID", DbType.Int64, AccountID);

                return InternalExecuteDataSet(database, DbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetSecurityDetailByIntroducer(int InstallationID, int IntroducerID, Int64 FacilityNo)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsOriginatorPortal_GetSecurityDetailsByIntroducer");

                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32,InstallationID);
                database.AddInParameter(DbCommand, "@IntroducerID", DbType.Int32, IntroducerID);
                database.AddInParameter(DbCommand, "@AccountFacilityID", DbType.Int64, FacilityNo);

                return InternalExecuteDataSet(database, DbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetPaymentDetailByIntroducer(int InstallationID, int IntroducerID, Int64 FacilityNo, Int64 AccountNo)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsOriginatorPortal_GetPaymentDetailsByIntroducer");

                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@IntroducerID", DbType.Int32, IntroducerID);
                database.AddInParameter(DbCommand, "@AccountFacilityID", DbType.Int64, FacilityNo);
                database.AddInParameter(DbCommand, "@AccountID", DbType.Int64, AccountNo);

                return InternalExecuteDataSet(database, DbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetDDRBpayDetailByIntroducer(int InstallationID, int IntroducerID, Int64 FacilityNo, Int64 AccountNo)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsOriginatorPortal_GetDDRBPAYDetailsByIntroducer");

                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@IntroducerID", DbType.Int32, IntroducerID);
                database.AddInParameter(DbCommand, "@AccountFacilityID", DbType.Int64, FacilityNo);
                database.AddInParameter(DbCommand, "@AccountID", DbType.Int64, AccountNo);

                return InternalExecuteDataSet(database, DbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetArrearsDetailsByIntroducer(int InstallationID, int IntroducerID, Int64 FacilityNo, Int64 AccountNo, string arrearsNotes)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsOriginatorPortal_GetArrearsDetailsByIntroducer");

                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@IntroducerID", DbType.Int32, IntroducerID);
                database.AddInParameter(DbCommand, "@AccountFacilityID", DbType.Int64, FacilityNo);
                database.AddInParameter(DbCommand, "@AccountID", DbType.Int64, AccountNo);
                database.AddInParameter(DbCommand, "@ArrearsNotes", DbType.String, arrearsNotes);

                return InternalExecuteDataSet(database, DbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetRedrawDetailsByIntroducer(int InstallationID, int IntroducerID, Int64 FacilityNo, Int64 AccountNo)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsOriginatorPortal_GetRedrawDetailsByIntroducer");

                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@IntroducerID", DbType.Int32, IntroducerID);
                database.AddInParameter(DbCommand, "@AccountFacilityID", DbType.Int64, FacilityNo);
                database.AddInParameter(DbCommand, "@AccountID", DbType.Int64, AccountNo);

                return InternalExecuteDataSet(database, DbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAccountStatementListByIntroducer(int InstallationID, int IntroducerID, Int64 FacilityNo, Int64 AccountNo, DateTime StartDate, DateTime EndDate)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsOriginatorPortal_GetStatementByIntroducer");

                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@IntroducerID", DbType.Int32, IntroducerID);
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

        public DataSet GetStatementByStatementCode(int InstallationID, string StatementCode)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsOriginatorPortal_GetStatementByStatementCode");

                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, InstallationID);
                database.AddInParameter(DbCommand, "@StatementCode", DbType.String, StatementCode);
                return InternalExecuteDataSet(database, DbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}