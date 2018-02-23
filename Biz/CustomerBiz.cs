using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using LWT.Common;

namespace WCFWebService.Biz
{
    public class CustomerBiz
    {
        public string CustomerLogin { get; set; }
        public string CustomerPassword { get; set; }

        public Int64 InstallationID { get; set; }
        public Int64 CustomerID { get; set; }

        public Int64? AccountFacilityID { get; set; }
        public Int64? AccountID { get; set; }

        public string Page { get; set; }
        public string TranType { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PortalLogin { get; set; }  
        public DateTime DOB { get; set; }

        public bool RememberMe { get; set; }
        public string PersonalQuestion { get; set; }
        public string SecurityAnswer { get; set; }
        public bool PortalCompletedFirstTimeLogin { get; set; }
        public bool ExceedLoginLimit { get; set; }

        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }

        /*address*/
        public string Address1 { get; set; }
        public string Address2 { get; set; }

        public string MailAddressFloorNo { get; set; }
        public string MailAddressLotNo { get; set; }
        public string MailAddressUnitNo { get; set; }
        public string MailAddressStreetNo { get; set; }
        public string MailAddressStreetName { get; set; }
        public string MailAddressStreetType { get; set; }
        public string MailAddressSuburb { get; set; }
        public string MailAddressPostCode { get; set; }
        public string MailAddressState { get; set; }
        public bool MailAddressIsPOBox { get; set; }
        public string MailAddressPOBox { get; set; }
        public string CustomerEmploymentID { get; set; }

        private CustomerDAL oCustDAL= new CustomerDAL();
        
        public CustomerBiz(string soapusername, string soappassword)
        {
            try
            {
                if (!Security.SoapRequestAuthenticated(soapusername, soappassword))
                    throw new Exception("Invalid request");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CustomerBiz(string cInstallationID, string soapusername, string soappassword,
            string cCustomerID, string cFacilityNo, string cAccountNo )
        {
            try
            {
                Int64 iInstallationID; Int64 iCustomerID; Int64 iAccountFacilityID;
                Int64 iAccountNo;

                if (!Security.SoapRequestAuthenticated(soapusername, soappassword))
                    throw new Exception("Invalid request");

                if (cCustomerID == "" ) 
                    throw new Exception("Invalid request");

                if (Int64.TryParse(cInstallationID, out iInstallationID))
                    InstallationID = iInstallationID;
                else
                    throw new Exception("Invalid request");

                if (Int64.TryParse(cCustomerID, out iCustomerID))
                    CustomerID = iCustomerID;
                else
                    throw new Exception("Invalid request");

                if (cFacilityNo != "")
                {
                    if (Int64.TryParse(cFacilityNo, out iAccountFacilityID))
                        AccountFacilityID = iAccountFacilityID;
                    else
                        throw new Exception("Invalid request");
                }

                if (cAccountNo != "")
                {
                    if (Int64.TryParse(cAccountNo, out iAccountNo))
                        AccountID = iAccountNo;
                    else
                        throw new Exception("Invalid request");
                }                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ValidateCustomerPortalLogin(string cInstallationID, string customerLogin, string customerPassword)
        {
            try
            {
                InstallationID = Int64.Parse(cInstallationID);
                CustomerLogin = customerLogin;
                CustomerPassword = customerPassword;
                Page = "Customer Portal login";
                return oCustDAL.ValidateLogin(this);                  
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetSecurityQuestionList(string cInstallationID)
        {
            try
            {
                InstallationID = Int64.Parse(cInstallationID);

                return oCustDAL.GetSecurityQuestionList(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public string SaveCustomerDetails()
        //{
        //    try
        //    {
        //        return oCustDAL.SaveCustDetails(this);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public DataSet GetCustDetails()
        //{
        //    try
        //    {
        //        return oCustDAL.GetCustDetails(this);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public Customer GetCustomer()
        //{
        //    try
        //    {
        //        DataSet custDetails = oCustDAL.GetCustDetails(this);

        //        if (custDetails != null)
        //        {
        //            DataTable userDataRows = custDetails.Tables[0];

        //            return new Customer()
        //            {
        //                FirstName = LWT.Common.LWTSafeTypes.SafeString(userDataRows.Rows[0]["FirstName"]),
        //                LastName = LWT.Common.LWTSafeTypes.SafeString(userDataRows.Rows[0]["LastName"]),

        //                HomePhone = LWT.Common.LWTSafeTypes.SafeString(userDataRows.Rows[0]["Phone"]),
        //                WorkPhone = LWT.Common.LWTSafeTypes.SafeString(userDataRows.Rows[0]["EmpWorkPhone"]),
        //                MobilePhone = LWT.Common.LWTSafeTypes.SafeString(userDataRows.Rows[0]["Mobile"]),
        //                Email = LWT.Common.LWTSafeTypes.SafeString(userDataRows.Rows[0]["Email"]),

        //                MailAddressLotNo = LWT.Common.LWTSafeTypes.SafeString(userDataRows.Rows[0]["LotNo"]),
        //                MailAddressFloorNo = LWT.Common.LWTSafeTypes.SafeString(userDataRows.Rows[0]["FloorNo"]),
        //                MailAddressUnitNo = LWT.Common.LWTSafeTypes.SafeString(userDataRows.Rows[0]["UnitNo"]),
        //                MailAddressStreetNo = LWT.Common.LWTSafeTypes.SafeString(userDataRows.Rows[0]["StreetNo"]),
        //                MailAddressStreetName = LWT.Common.LWTSafeTypes.SafeString(userDataRows.Rows[0]["Address1"]),
        //                MailAddressStreetType = LWT.Common.LWTSafeTypes.SafeString(userDataRows.Rows[0]["StreetType"]),
        //                MailAddressSuburb = LWT.Common.LWTSafeTypes.SafeString(userDataRows.Rows[0]["Suburb"]),

        //                MailAddressPostCode = LWT.Common.LWTSafeTypes.SafeString(userDataRows.Rows[0]["PostCode"]),
        //                MailAddressState = LWT.Common.LWTSafeTypes.SafeString(userDataRows.Rows[0]["State"]),
        //                MailAddressIsPOBox = LWT.Common.LWTSafeTypes.SafeBool(userDataRows.Rows[0]["IsPOBox"]),
        //                MailAddressPOBox = LWT.Common.LWTSafeTypes.SafeString(userDataRows.Rows[0]["POBox"]),
        //                PortalCompletedFirstTimeLogin = LWT.Common.LWTSafeTypes.SafeBool(userDataRows.Rows[0]["PortalCompletedFirstTimeLogin"]),
        //                CustomerEmploymentID = LWT.Common.LWTSafeTypes.SafeString(userDataRows.Rows[0]["CustomerEmployementID"])
        //            };
        //        }
        //        else
        //            return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        //public Boolean CustomerAcceptTermAndConditions()
        //{
        //    try
        //    {
        //        oCustDAL.CustomerAcceptTermsAndConditions(this);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public DataSet AuthenticateLogin(string _username, string _password, string _page)
        //{
        //    this.UserName = _username;
        //    this.Password = _password;
        //    this.Page = _page;
        //    try
        //    {
        //        return oCustDAL.ValidateLogin(this);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public DataSet ValidateCustomer(string portalLogin, DateTime dob, string accountID)
        //{
        //    try
        //    {
        //        this.PortalLogin = Common.LWTSafeTypes.SafeString(portalLogin);
        //        this.DOB = Common.LWTSafeTypes.SafeDateTime(dob);
        //        this.AccountID = Common.LWTSafeTypes.SafeInt(accountID);
        //        return oCustDAL.ValidateCustomer(this);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}
        //public DataSet GetCustomerSecurityQuestion(string portalLogin, DateTime dob, string accountID)
        //{
        //    try
        //    {
        //        this.PortalLogin = Common.LWTSafeTypes.SafeString(portalLogin);
        //        this.DOB = Common.LWTSafeTypes.SafeDateTime(dob);
        //        this.AccountID = Common.LWTSafeTypes.SafeInt(accountID);
        //        return oCustDAL.GetSecurityQuestion(this);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}
        //public DataSet CheckSecurityAnswer(string portalLogin, DateTime dob, string accountID, string answer)
        //{
        //    try
        //    {
        //        this.PortalLogin = Common.LWTSafeTypes.SafeString(portalLogin);
        //        this.DOB = Common.LWTSafeTypes.SafeDateTime(dob);
        //        this.AccountID = Common.LWTSafeTypes.SafeInt(accountID);
        //        this.SecurityAnswer = Common.LWTSafeTypes.SafeString(answer);
        //        return oCustDAL.CheckSecurityAnswer(this);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}
        //public DataSet CheckEmailMobile(string portalLogin, DateTime dob, string accountID, string answer)
        //{
        //    try
        //    {
        //        this.PortalLogin = Common.LWTSafeTypes.SafeString(portalLogin);
        //        this.DOB = Common.LWTSafeTypes.SafeDateTime(dob);
        //        this.AccountID = Common.LWTSafeTypes.SafeInt(accountID);
        //        this.SecurityAnswer = Common.LWTSafeTypes.SafeString(answer);
        //        return oCustDAL.CheckEmailMobile(this);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}
        //public DataSet SubmitPassword(string portalLogin, DateTime dob, string accountID, string password, string tranType, string currentPassword, string originPage)
        //{
        //    try
        //    {
        //        this.Page = Common.LWTSafeTypes.SafeString(originPage);
        //        this.PortalLogin = Common.LWTSafeTypes.SafeString(portalLogin);
        //        this.DOB = Common.LWTSafeTypes.SafeDateTime(dob);
        //        this.AccountID = Common.LWTSafeTypes.SafeInt(accountID);
        //        this.Password = Common.LWTSafeTypes.SafeString(password);
        //        this.TranType = Common.LWTSafeTypes.SafeString(tranType);
        //        this.CurrentPassword = Common.LWTSafeTypes.SafeString(currentPassword);
        //        return oCustDAL.SubmitPassword(this);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}
        //public DataSet SubmitForgotPassword(string portalLogin, DateTime dob, string accountID, string answer, string email, string mobilephone, string originPage)
        //{
        //    try
        //    {
        //        this.Page = Common.LWTSafeTypes.SafeString(originPage);
        //        this.PortalLogin = Common.LWTSafeTypes.SafeString(portalLogin);
        //        this.DOB = Common.LWTSafeTypes.SafeDateTime(dob);
        //        this.AccountID = Common.LWTSafeTypes.SafeInt(accountID);
        //        this.SecurityAnswer = Common.LWTSafeTypes.SafeString(answer);
        //        this.Email = Common.LWTSafeTypes.SafeString(email);
        //        this.MobilePhone = Common.LWTSafeTypes.SafeString(mobilephone);
        //        return oCustDAL.SubmitForgotPassword(this);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}


    }
}