using System;
using System.Collections.Generic;
using System.Web;

using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;

using LWT.Common.DAL;
using LWT.Common;
using WCFWebService.Biz;

namespace WCFWebService
{
    public class CustomerDAL : BaseDAL
    {

        #region Variables
        private Database database = LWTDatabase.GetInstance().GetDatabase(CommonConstants.DATABASE_NAME);
        #endregion Variables
        
        public DataSet ValidateLogin(CustomerBiz oCust)
        {
            try
            {
                DbCommand DbCommand = database.GetStoredProcCommand("lmsCustomerPortalLogin");
                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, oCust.InstallationID);
                database.AddInParameter(DbCommand, "@OriginPage", DbType.String, oCust.Page);
                database.AddInParameter(DbCommand, "@LoginID", DbType.String, oCust.CustomerLogin);
                database.AddInParameter(DbCommand, "@Password", DbType.String, oCust.CustomerPassword);

                return InternalExecuteDataSet(database, DbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetSecurityQuestionList(CustomerBiz oCust)
        {
            try
            {
				DbCommand DbCommand = database.GetStoredProcCommand("lmsCustomerPortal_GetSecurityQuestionList");
                database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, oCust.InstallationID);
				
                return InternalExecuteDataSet(database, DbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public DataSet CustomerAcceptTermsAndConditions(CustomerBiz oCust)
        //{
        //    try
        //    {
        //        DbCommand DbCommand = database.GetStoredProcCommand("lmsCustomerPortalCustomerAcceptTermCondition");
        //        database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, System.Web.HttpContext.Current.Application["installationid"]);
        //        database.AddInParameter(DbCommand, "@Custid", DbType.String, oCust.CustomerID);

        //        return InternalExecuteDataSet(database, DbCommand, null);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
       
        //public DataSet ValidateCustomer(Customer oCust)
        //{
        //    try
        //    {
        //        DbCommand DbCommand = database.GetStoredProcCommand("lmsCustomerPortalValidateCustomer");
        //        database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, System.Web.HttpContext.Current.Application["installationid"]);
        //        database.AddInParameter(DbCommand, "@PortalLogin", DbType.String, oCust.PortalLogin);
        //        database.AddInParameter(DbCommand, "@DateofBirth", DbType.DateTime, oCust.DOB.Date);
        //        database.AddInParameter(DbCommand, "@AccountID", DbType.String, oCust.AccountID);

        //        return InternalExecuteDataSet(database, DbCommand, null);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public DataSet GetSecurityQuestion(Customer oCust)
        //{
        //    try
        //    {
        //        DbCommand DbCommand = database.GetStoredProcCommand("lmsCustomerPortalGetSecQuestion");
        //        database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, System.Web.HttpContext.Current.Application["installationid"]);
        //        database.AddInParameter(DbCommand, "@PortalLogin", DbType.String, oCust.PortalLogin);
        //        database.AddInParameter(DbCommand, "@CustomerDOB", DbType.DateTime, oCust.DOB);
        //        database.AddInParameter(DbCommand, "@AccountID", DbType.String, oCust.AccountID);

        //        return InternalExecuteDataSet(database, DbCommand, null);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public DataSet GetCustDetails(Customer oCust)
        //{
        //    try
        //    {
        //        DbCommand DbCommand = database.GetStoredProcCommand("lmsCustomerPortalGetDetails");
        //        database.AddInParameter(DbCommand, "@Custid", DbType.String, oCust.Custid);

        //        return InternalExecuteDataSet(database, DbCommand, null);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public DataSet SubmitPassword(Customer oCust)
        //{
        //    try
        //    {
        //        DbCommand DbCommand = database.GetStoredProcCommand("lmsCustomerPortalSetCustomerPassword");
        //        database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, System.Web.HttpContext.Current.Application["installationid"]);
        //        database.AddInParameter(DbCommand, "@OriginPage", DbType.String, oCust.Page);
        //        database.AddInParameter(DbCommand, "@PortalLogin", DbType.String, oCust.PortalLogin);
        //        database.AddInParameter(DbCommand, "@CustomerDOB", DbType.DateTime, oCust.DOB.Date);
        //        database.AddInParameter(DbCommand, "@AccountID", DbType.Int64, oCust.AccountID);
        //        database.AddInParameter(DbCommand, "@Password", DbType.String, oCust.Password);
        //        database.AddInParameter(DbCommand, "@CurrentPassword", DbType.String, oCust.CurrentPassword);
        //        database.AddInParameter(DbCommand, "@TranType", DbType.String, oCust.TranType);
        //        return InternalExecuteDataSet(database, DbCommand, null);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public DataSet SubmitForgotPassword(Customer oCust)
        //{
        //    try
        //    {
        //        DbCommand DbCommand = database.GetStoredProcCommand("lmsCustomerPortalForgotLoginSubmit");
        //        database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, System.Web.HttpContext.Current.Application["installationid"]);
        //        database.AddInParameter(DbCommand, "@OriginPage", DbType.String, oCust.Page);
        //        database.AddInParameter(DbCommand, "@PortalLogin", DbType.String, oCust.PortalLogin);
        //        database.AddInParameter(DbCommand, "@CustomerDOB", DbType.DateTime, oCust.DOB.Date);
        //        database.AddInParameter(DbCommand, "@AccountID", DbType.Int64, oCust.AccountID);
        //        database.AddInParameter(DbCommand, "@SecurityAnswer", DbType.String, oCust.SecurityAnswer);
        //        database.AddInParameter(DbCommand, "@Email", DbType.String, oCust.Email);
        //        database.AddInParameter(DbCommand, "@Mobile", DbType.String, oCust.MobilePhone);
        //        return InternalExecuteDataSet(database, DbCommand, null);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public DataSet CheckSecurityAnswer(Customer oCust)
        //{
        //    try
        //    {
        //        DbCommand DbCommand = database.GetStoredProcCommand("lmsCustomerPortalCheckSecurityAnswer");
        //        database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, System.Web.HttpContext.Current.Application["installationid"]);
        //        database.AddInParameter(DbCommand, "@PortalLogin", DbType.String, oCust.PortalLogin);
        //        database.AddInParameter(DbCommand, "@CustomerDOB", DbType.DateTime, oCust.DOB.Date);
        //        database.AddInParameter(DbCommand, "@AccountID", DbType.String, oCust.AccountID);
        //        database.AddInParameter(DbCommand, "@SecurityAnswer", DbType.String, oCust.SecurityAnswer);
        //        return InternalExecuteDataSet(database, DbCommand, null);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public DataSet CheckEmailMobile(Customer oCust)
        //{
        //    try
        //    {
        //        DbCommand DbCommand = database.GetStoredProcCommand("lmsCustomerPortalCheckEmailMobile");
        //        database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, System.Web.HttpContext.Current.Application["installationid"]);
        //        database.AddInParameter(DbCommand, "@PortalLogin", DbType.String, oCust.PortalLogin);
        //        database.AddInParameter(DbCommand, "@CustomerDOB", DbType.DateTime, oCust.DOB.Date);
        //        database.AddInParameter(DbCommand, "@AccountID", DbType.String, oCust.AccountID);
        //        database.AddInParameter(DbCommand, "@SecurityAnswer", DbType.String, oCust.SecurityAnswer);
        //        return InternalExecuteDataSet(database, DbCommand, null);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public DataSet GetCustFacilityAccountsDetails(int CustID, int FacilityID, int FacilityAccountID)
        //{
        //    try
        //    {
        //        DbCommand DbCommand = database.GetStoredProcCommand("lmsCustomerPortalGetFacilityAccountsDetails");
        //        database.AddInParameter(DbCommand, "@Custid", DbType.Int64, CustID);
        //        database.AddInParameter(DbCommand, "@FacilityID", DbType.Int64, FacilityID);
        //        database.AddInParameter(DbCommand, "@FacilityAccountID", DbType.Int64, FacilityAccountID);

        //        return InternalExecuteDataSet(database, DbCommand, null);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public string SaveCustDetails( Customer oCust )
        //{
        //    try
        //    {
        //        DbCommand DbCommand = database.GetStoredProcCommand("lmsCustomerPortalDetailsSave");
        //        database.AddInParameter(DbCommand, "@InstallationID", DbType.Int32, System.Web.HttpContext.Current.Application["installationid"]);
        //        database.AddInParameter(DbCommand, "@CustID", DbType.Int32, oCust.Custid);
        //        database.AddInParameter(DbCommand, "@HomePhone", DbType.String, oCust.HomePhone);
        //        database.AddInParameter(DbCommand, "@WorkPhone", DbType.String, oCust.WorkPhone);
        //        database.AddInParameter(DbCommand, "@Mobile", DbType.String, oCust.MobilePhone);
        //        database.AddInParameter(DbCommand, "@Email", DbType.String, oCust.Email);

        //        database.AddInParameter(DbCommand, "@LotNo", DbType.String, oCust.MailAddressLotNo);
        //        database.AddInParameter(DbCommand, "@FloorNo", DbType.String, oCust.MailAddressFloorNo);
        //        database.AddInParameter(DbCommand, "@UnitNo", DbType.String, oCust.MailAddressUnitNo);

        //        database.AddInParameter(DbCommand, "@StreetNo", DbType.String, oCust.MailAddressStreetNo);
        //        database.AddInParameter(DbCommand, "@StreetName", DbType.String, oCust.MailAddressStreetName);
        //        database.AddInParameter(DbCommand, "@StreetType", DbType.String, oCust.MailAddressStreetType);
				
        //        database.AddInParameter(DbCommand, "@Suburb", DbType.String, oCust.MailAddressSuburb);
        //        database.AddInParameter(DbCommand, "@PostCode", DbType.String, oCust.MailAddressPostCode);
        //        database.AddInParameter(DbCommand, "@State", DbType.String, oCust.MailAddressState);
        //        database.AddInParameter(DbCommand, "@POBox", DbType.String, oCust.MailAddressPOBox);
        //        database.AddInParameter(DbCommand, "@CustomerEmpID", DbType.String, oCust.CustomerEmploymentID);
        //        database.AddOutParameter(DbCommand, "@Errors", DbType.String, 1000);

        //        database.ExecuteNonQuery(DbCommand);

        //        return LWTSafeTypes.SafeString(database.GetParameterValue(DbCommand, "@Errors"));
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}