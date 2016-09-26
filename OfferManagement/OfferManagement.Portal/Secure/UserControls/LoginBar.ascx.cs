﻿using OfferManagement.BusinessModel;
using System;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace OfferManagement.Portal.Secure.UserControls
{
    public partial class LoginBar : System.Web.UI.UserControl
    {
        #region [ Properties ]

        public PlaceHolder UserDetails
        {
            get { return (PlaceHolder)loginView.FindControl("phUserDetails"); }
        }

        public LinkButton LogoutButton
        {
            get { return (LinkButton)loginView.FindControl("btnLogout"); }
        }

        public HtmlAnchor ChangePasswordButton
        {
            get { return (HtmlAnchor)loginView.FindControl("btnChangePassword"); }
        }

        #endregion

        #region [ Page Inits ]

        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlAnchor userDetailsHyperLink = loginView.FindControlRecursive("btnUserDetails") as HtmlAnchor;

            if (Page.User.Identity.IsAuthenticated)
            {
                var roles = Roles.GetRolesForUser(Page.User.Identity.Name);

                if (Roles.IsUserInRole(RoleNames.Store))
                {
                    userDetailsHyperLink.Attributes["href"] = "~/Secure/Stores/AccountDetails.aspx";
                }
            }
        }

        #endregion

        #region [ Button Handlers ]

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            AuthenticationService.ClearRoleCookie();
            Response.Redirect(FormsAuthentication.LoginUrl, true);
        }

        #endregion
    }
}