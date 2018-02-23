using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFWebService.ServiceInterface
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICustomerPortalService" in both code and config file together.
	[ServiceContract]
	public interface ICustomerPortalService
	{
		[OperationContract] //defines the method going to be expose by the service.
		Int64 CreateAccountStatement(Int64 InstallationID, Int64 CustomerID, Int64 AccountFacilityNo, Int64 AccountNo, DateTime StartDate, DateTime EndDate);

		[OperationContract]
		byte[] DownloadAccountStatamentFile(Int64 InstallationID, 
			Int64 CustomerID, Int64 AccountFacilityNo, Int64 AccountNo, DateTime StartDate, DateTime EndDate, Int64 AccountTemplateDocumentID);
		
	}

	

}
