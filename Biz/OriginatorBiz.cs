using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFWebService.Biz
{
    public class OriginatorBiz
    {
        public Int32 InstallationID { get; set; }
        public int LWIntroducerID { get; set; }

        public Int64? AccountFacilityID { get; set; }
        public Int64? AccountID { get; set; }

        public OriginatorBiz (string cInstallationID, string soapusername, string soappassword,
            string cIntroducerID, string cFacilityNo, string cAccountNo )
        {
            try
            {
                int iInstallationID; int iIntroducerId; Int64 iAccountFacilityID;
                Int64 iAccountNo;

                if (!Security.SoapRequestAuthenticated(soapusername, soappassword))
                    throw new Exception("Invalid soap username or password");

                if (cIntroducerID == "" ) 
                    throw new Exception("Invalid request");
                
                if (int.TryParse(cInstallationID, out iInstallationID))
                    InstallationID = iInstallationID;
                else
                    throw new Exception("InstallationID must be numeric");

                if (int.TryParse(cIntroducerID, out iIntroducerId))
                    LWIntroducerID = iIntroducerId;
                else
                    throw new Exception("IntroducerID must be numeric");

                if (cFacilityNo != "")
                {
                    if (Int64.TryParse(cFacilityNo, out iAccountFacilityID))
                        AccountFacilityID = iAccountFacilityID;
                    else
                        throw new Exception("Facility Number must be numeric");
                }

                if (cAccountNo != "")
                {
                    if (Int64.TryParse(cAccountNo, out iAccountNo))
                        AccountID = iAccountNo;
                    else
                        throw new Exception("Account Number must be numeric");
                }                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}