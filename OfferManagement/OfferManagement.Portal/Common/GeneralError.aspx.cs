﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace OfferManagement.Portal.Common
{
    public partial class GeneralError : System.Web.UI.Page
    {
        protected bool IsUploadError
        {
            get { return Request.QueryString["aspxerrorpath"].Contains("UploadPhoto"); }
        }
    }
}
