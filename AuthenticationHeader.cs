﻿using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Web.Services.Protocols;

public class AuthenticationHeader : SoapHeader
{
	public string UserName;
	public string Password;
}
