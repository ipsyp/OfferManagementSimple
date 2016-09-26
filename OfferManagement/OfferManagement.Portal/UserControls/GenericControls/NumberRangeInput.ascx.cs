﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfferManagement.BusinessModel;
using OfferManagement.Portal.Controls;
using DevExpress.Web;
using OfferManagement.Portal.Utils;
using Imis.Domain;

namespace OfferManagement.Portal.UserControls.GenericControls
{
    public partial class NumberRangeInput : UserControl
    {
        #region [ Extract - Bind ]

        public List<int?> GetNumbers()
        {
            List<int?> numbers = new List<int?>();

            numbers.Add(txtNumberFrom.GetInteger());
            numbers.Add(txtNumberTo.GetInteger());

            return numbers;
        }

        public void Bind(int? numberFrom, int? numberTo)
        {
            txtNumberFrom.Value = numberFrom;
            txtNumberTo.Value = numberTo;
        }

        #endregion

        #region [ Validation ]

        public string ValidationGroup
        {
            get { return txtNumberFrom.ValidationSettings.ValidationGroup; }
            set
            {
                txtNumberFrom.ValidationSettings.ValidationGroup = value;
            }
        }

        #endregion
    }
}