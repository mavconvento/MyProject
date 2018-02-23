using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;


namespace WCFWebService
{
	public static class Security
	{

		public static string GetAppSetting(string Token)
		{
			return (ConfigurationManager.AppSettings[Token].ToString());
		}  

		public static Boolean SoapRequestAuthenticated ( string soapusername, string soappassword ){
			try
			{
				if (GetAppSetting("incomingsoapusername") == soapusername && 
					GetAppSetting("incomingsoappassword") == soappassword ){
						return true;
					} 

				return false;

			}
			catch (Exception)
			{				
				return false;
			}

		}

	} 
}