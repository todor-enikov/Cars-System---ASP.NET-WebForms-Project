﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarsSystem.WebForms.Client.Filters
{
    public partial class FilterByAnnualCheckUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.IsInRole("Admin"))
            {
                Response.Redirect("~/UnauthorizedAccess.aspx");
            }
        }
    }
}